using System.ComponentModel.DataAnnotations;

namespace MovieRecommendation.Business.Request
{
    public class NoteRequest
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Note { get; set; }
    }
}