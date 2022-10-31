using System.ComponentModel.DataAnnotations;

namespace MovieRecommendation.Business.Request
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
