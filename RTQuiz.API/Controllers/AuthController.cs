﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTQuiz.Data;
using RTQuiz.DTO;
using RTQuiz.IServices;
using RTQuiz.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RTQuiz.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly JWTService _jwtService;
        private readonly QuizDBContext _quizDBContext;

        public AuthController(IAuthService authService, JWTService jWTService, QuizDBContext quizDBContext)
        {
            _authService = authService; 
            _jwtService = jWTService;
            _quizDBContext = quizDBContext;
        }
        // GET: api/<AuthController>
        [HttpPost("authenticate")]
        public async Task<GetTokenDTO> Authenticate(LoginDTO loginDTO)
        {
            var res = await _authService.Authenticate(loginDTO);
            return res;
        }
        [HttpPost("register")]
        public async Task<GetUserDTO> Register(CreateUserDTO createUserDTO)
        {
            var res = await _authService.RegisterUser(createUserDTO);
            return res;
        }

    }
}
