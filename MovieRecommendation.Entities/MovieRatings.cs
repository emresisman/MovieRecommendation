using System.ComponentModel.DataAnnotations;
using System;

namespace MovieRecommendation.Entities
{
    public class MovieRatings
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movies Movie { get; set; }

        [Range(0,10)]
        public int Rating { get; set; }
    }
}