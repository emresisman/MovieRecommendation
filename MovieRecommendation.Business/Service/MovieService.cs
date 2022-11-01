using Microsoft.EntityFrameworkCore;
using MovieRecommendation.Business.Repository;
using MovieRecommendation.Business.Request.Pagination;
using MovieRecommendation.Business.Service.Interface;
using MovieRecommendation.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRecommendation.Business.Service
{
    public class MovieService : IMovieService
    {
        private readonly IGenericRepository<Movies> _repository;

        public MovieService(IGenericRepository<Movies> repository)
        {
            _repository = repository;
        }

        public List<Movies> GetAllMovies(PaginationParameters filter)
        {
            return _repository.GetWithPagination<Movies>(filter);
        }        
        
        public List<Movies> GetAllMovies()
        {
            return _repository.GetQueryable().ToList();
        }

        public Movies GetById(int movieId)
        {
            return _repository.GetQueryable().Include(x => x.MovieNotes).ThenInclude(x=> x.User).Include(x => x.MovieRatings).ThenInclude(x => x.User).Where(x => x.Id == movieId).FirstOrDefault();
        }
    }
}
