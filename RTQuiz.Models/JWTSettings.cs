using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Models
{
    public class JWTSettings
    {
        public string Secret {  get; set; }
        public DateTime AccessTokenExpirationMinutes { get; set; }
        public DateTime RefreshTokenExpirationDays { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
