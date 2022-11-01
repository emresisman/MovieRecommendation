using System.ComponentModel.DataAnnotations;
using System;
using MovieRecommendation.Entities.Abstract;
using MovieRecommendation.Entities.Interface;

namespace MovieRecommendation.Entities
{
    public class MovieRatings : BaseEntity , IEntity
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public Movies Movie { get; set; }

        [Range(0,10)]
        public int Rating { get; set; }
    }
}