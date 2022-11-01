using MovieRecommendation.Business.Interface;
using MovieRecommendation.Business.Repository;
using MovieRecommendation.Business.Request;
using MovieRecommendation.Business.Service.Interface;
using MovieRecommendation.Entities;
using System.Linq;
using System;

namespace MovieRecommendation.Business.Service
{
    public class RatingNoteService : IRatingNoteService
    {
        private readonly IGenericRepository<MovieRatings> _ratingRepository;
        private readonly IGenericRepository<MovieNotes> _notesRepository;
        private readonly IGenericRepository<Movies> _moviesRepository;
        private readonly IUserManager _userManager;

        public RatingNoteService(IGenericRepository<MovieRatings> ratingRepository, IGenericRepository<MovieNotes> notesRepository, IUserManager userManager, IGenericRepository<Movies> moviesRepository)
        {
            _ratingRepository = ratingRepository;
            _notesRepository = notesRepository;
            _moviesRepository = moviesRepository;
            _userManager = userManager;
        }

        public void SetRatingToMovie(RatingRequest ratingRequest)
        {
            if (!_moviesRepository.GetQueryable().Where(x => x.Id == ratingRequest.MovieId).Any())
            {
                throw new Exception("Movie not found.");
            }
            var entity = new MovieRatings
            {
                MovieId = ratingRequest.MovieId,
                Rating = ratingRequest.Rating,
                UserId = _userManager.GetAuthenticatedUser().Id
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
            if (!_moviesRepository.GetQueryable().Where(x => x.Id == noteRequest.MovieId).Any())
            {
                throw new Exception("Movie not found.");
            }
            var entity = new MovieNotes
            {
                MovieId = noteRequest.MovieId,
                Notes = noteRequest.Note,
                UserId = _userManager.GetAuthenticatedUser().Id
            };
            _notesRepository.Add(entity);
            _notesRepository.SaveChangesAsync();
        }
    }
}