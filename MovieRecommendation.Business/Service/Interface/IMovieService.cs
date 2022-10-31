using MovieRecommendation.Business.Request.Pagination;
using MovieRecommendation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Business.Service.Interface
{
    public interface IMovieService
    {
        List<Movies> GetAllMovies(PaginationParameters filter);
        List<Movies> GetAllMovies();
        Movies GetById(int movieId);
    }
}