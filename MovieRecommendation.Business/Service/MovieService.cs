using MovieRecommendation.Business.Repository;
using MovieRecommendation.Business.Request.Pagination;
using MovieRecommendation.Business.Service.Interface;
using MovieRecommendation.Entities;
using System.Collections.Generic;

namespace MovieRecommendation.Business.Service
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movies> _repository;

        public MovieService(IRepository<Movies> repository)
        {
            _repository = repository;
        }

        public List<Movies> GetAllMovies(PaginationParameters filter)
        {
            return _repository.GetWithPagination<Movies>(filter);
        }        
        
        public List<Movies> GetAllMovies()
        {
            return _repository.Get();
        }

        public Movies GetById(int movieId)
        {
            return _repository.GetById(movieId);
        }
    }
}
