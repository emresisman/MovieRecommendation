using MovieRecommendation.Entities.Abstract;
using MovieRecommendation.Entities.Interface;

namespace MovieRecommendation.Entities
{
    public class MovieNotes : BaseEntity , IEntity
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public Movies Movie { get; set; }
        public string Notes { get; set; }
    }
}