using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.DTO
{
    public record LoginDTO(string Email, string Password);
    public record GetTokenDTO(string AccessToken, string RefreshToken);
    public record RegisterDTO(string Email, string Username, string Password);
}
