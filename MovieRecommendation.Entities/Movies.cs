using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace MovieRecommendation.Entities
{
    public class Movies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Poster_Path { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public DateTime? Release_Date { get; set; }
        public float? Vote_Average { get; set; }
        public int? Vote_Count { get; set; }
        public string Status { get; set; }
        public List<MovieRatings> MovieRatings { get; set; }
        public List<MovieNotes> MovieNotes { get; set; }
    }
}