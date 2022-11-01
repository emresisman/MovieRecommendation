using System.ComponentModel.DataAnnotations;

namespace MovieRecommendation.Business.Request
{
    public class MailRequest
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Email { get; set; }
    }
}