using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRecommendation.Business.Request
{
    public class RatingRequest
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        [Range(0,10)]
        public int Rating { get; set; }
    }
}