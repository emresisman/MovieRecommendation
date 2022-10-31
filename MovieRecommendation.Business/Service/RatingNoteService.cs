using MovieRecommendation.Business.Repository;
using MovieRecommendation.Business.Request;
using MovieRecommendation.Business.Service.Interface;
using MovieRecommendation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Business.Service
{
    public class RatingNoteService : IRatingNoteService
    {
        private readonly IRepository<MovieRatings> _ratingRepository;
        private readonly IRepository<MovieNotes> _notesRepository;

        public RatingNoteService(IRepository<MovieRatings> ratingRepository, IRepository<MovieNotes> notesRepository)
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
            var dbEntity = _ratingRepository.Get<MovieRatings>().Where(x => x.UserId == entity.UserId && x.MovieId == entity.MovieId).FirstOrDefault();
            if (dbEntity != null)
            {
                _ratingRepository.Update(entity, dbEntity.Id);
            }
            else
            {
                _ratingRepository.Add(entity);
            }
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
        }
    }
}