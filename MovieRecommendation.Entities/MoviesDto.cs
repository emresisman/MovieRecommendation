using System;
using System.Collections.Generic;

namespace MovieRecommendation.Entities
{
    public class MoviesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public DateTime? Release_Date { get; set; }
        public float? Vote_Average { get; set; }
        public int? Vote_Count { get; set; }
        public string Status { get; set; }
    }
}