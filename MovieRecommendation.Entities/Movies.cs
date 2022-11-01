using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using MovieRecommendation.Entities.Abstract;
using MovieRecommendation.Entities.Interface;

namespace MovieRecommendation.Entities
{
    public class Movies : BaseEntity, IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("id")]
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