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

        public AuthService(QuizDBContext quizDBContext, JWTService jwtService)
        {
            _quizDBContext = quizDBContext;
            _jwtService = jwtService;
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
            //var oldToken = await _quizDBContext.Tokens.AsNoTracking()
            //    .FirstOrDefaultAsync(t => t.UserId == user.Id);
            //while(oldToken.RefreshToken == refreshToken)
            //{
            //    refreshToken = _jwtService.CreateRefreshToken();
            //}
            //var newToken = new Token()
            //{
            //    Id = oldToken.Id,
            //    UserId = user.Id,
            //    AccessToken = accessToken,
            //    RefreshToken = refreshToken,
            //    RefreshTokenExpiry = DateTime.Now.AddDays(5)
            //};
            // Save JWT
            

            // Return Token
            var token = new GetTokenDTO(accessToken, refreshToken);
            return token;
        }
    }
}
