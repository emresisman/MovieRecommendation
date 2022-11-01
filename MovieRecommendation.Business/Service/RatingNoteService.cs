using MovieRecommendation.Business.Repository;
using MovieRecommendation.Business.Request;
using MovieRecommendation.Business.Service.Interface;
using MovieRecommendation.Entities;
using System.Linq;

namespace MovieRecommendation.Business.Service
{
    public class RatingNoteService : IRatingNoteService
    {
        private readonly IGenericRepository<MovieRatings> _ratingRepository;
        private readonly IGenericRepository<MovieNotes> _notesRepository;

        public RatingNoteService(IGenericRepository<MovieRatings> ratingRepository, IGenericRepository<MovieNotes> notesRepository)
        {
            _ratingRepository = ratingRepository;
            _notesRepository = notesRepository;
        }

        public void SetRatingToMovie(RatingRequest ratingRequest)
        {
            var entity = new MovieRatings
            {
                MovieId = ratingRequest.MovieId,
                Rating = ratingRequest.Rating,
                UserId = 2
            };
            var dbEntity = _ratingRepository.GetQueryable().Where(x => x.UserId == entity.UserId && x.MovieId == entity.MovieId).FirstOrDefault();
            if (dbEntity != null)
            {
                _ratingRepository.Update(entity);
            }
            else
            {
                _ratingRepository.Add(entity);
            }
            _ratingRepository.SaveChangesAsync();
        }
        public void SetNoteToMovie(NoteRequest noteRequest)
        {
            var entity = new MovieNotes
            {
                MovieId = noteRequest.MovieId,
                Notes = noteRequest.Note,
                UserId = 1
            };
            _notesRepository.Add(entity);
            _notesRepository.SaveChangesAsync();
        }
    }
}