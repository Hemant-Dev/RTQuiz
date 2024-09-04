using AutoMapper;
using Helpers;
using Microsoft.EntityFrameworkCore;
using RTQuiz.Data;
using RTQuiz.DTO;
using RTQuiz.IServices;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Services
{
    public class AuthService : IAuthService
    {
        private readonly QuizDBContext _quizDBContext;
        private readonly JWTService _jwtService;
        private readonly IMapper _mapper;

        public AuthService(QuizDBContext quizDBContext, JWTService jwtService, IMapper mapper)
        {
            _quizDBContext = quizDBContext;
            _jwtService = jwtService;
            _mapper = mapper;
        }
        public async Task<GetTokenDTO> Authenticate(LoginDTO loginDTO)
        {
            // Verify User Exists
            var user =  await  _quizDBContext.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == loginDTO.Email);
            if (user == null)
                return null; // Return that user doesn't exist
            // verify Password Hash 
            if (!PasswordHasherHelper.VerifyHashedPassword(loginDTO.Password, user.PasswordHash))
                return null; // Return Invalid

            // Generate JWT
            var accessToken = _jwtService.CreateJWT(user);
            var refreshToken = _jwtService.CreateRefreshToken();
            // Check if refreshToken exists else create new one
            var oldToken = await _quizDBContext.Tokens.AsNoTracking()
                .FirstOrDefaultAsync(t => t.UserId == user.Id);
            

            while (oldToken.RefreshToken == refreshToken)
            {
                refreshToken = _jwtService.CreateRefreshToken();
            }

            var newToken = new Token()
            {
                Id = oldToken.Id,
                UserId = user.Id,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                RefreshTokenExpiry = DateTime.Now.AddDays(5).ToUniversalTime(),
            };
            // Save JWT
            _quizDBContext.Tokens.Update(newToken);
            await _quizDBContext.SaveChangesAsync();

            // Return Token
            var token = new GetTokenDTO(accessToken, refreshToken);
            return token;
        }

        public async Task<GetUserDTO> RegisterUser(CreateUserDTO createUserDTO)
        {
            var hashedPassword = PasswordHasherHelper.PasswordHasher(createUserDTO.PasswordHash);
            var newUser = new User()
            {
                Username = createUserDTO.Username,
                Email = createUserDTO.Email,
                PasswordHash = hashedPassword
            };
            var savedUserEntity = await _quizDBContext.Users.AddAsync(newUser);
            await _quizDBContext.SaveChangesAsync();
            // Add Dummy Token too so that on login we create a new token and save it
            var newToken = new Token()
            {
                UserId = savedUserEntity.Entity.Id,
                AccessToken = "Access",
                RefreshToken = "Refresh",
                RefreshTokenExpiry = DateTime.Now.AddDays(1).ToUniversalTime(),
            };
            await _quizDBContext.Tokens.AddAsync(newToken);
            await _quizDBContext.SaveChangesAsync();

            var savedUserDTO = new GetUserDTO(savedUserEntity.Entity.Id, savedUserEntity.Entity.Email, null, null, null);
            return savedUserDTO;
        }
    }
}
