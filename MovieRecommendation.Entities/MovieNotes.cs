﻿namespace MovieRecommendation.Entities
{
    public class MovieNotes
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movies Movie { get; set; }
        public string Notes { get; set; }
    }
}