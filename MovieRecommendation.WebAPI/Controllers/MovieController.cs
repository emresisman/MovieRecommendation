using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendation.Business.Request.Pagination;
using MovieRecommendation.Business.Service.Interface;
using MovieRecommendation.Entities;
using System.Collections.Generic;

namespace MovieRecommendation.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllMovies")]
        [AllowAnonymous]
        public IActionResult GetAllMovies()
        {
            var movies =  _movieService.GetAllMovies();
            var result = _mapper.Map<List<Movies>, List<MoviesDto>>(movies);
            return Ok(result);
        }        
        
        [HttpGet]
        [Route("GetAllMoviesWithPage")]
        [AllowAnonymous]
        public IActionResult GetAllMoviesWithPage([FromQuery] PaginationParameters filter)
        {
            var movies = _movieService.GetAllMovies(filter);
            var result = _mapper.Map<List<Movies>, List<MoviesDto>>(movies);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("GetMovieById")]
        [AllowAnonymous]
        public IActionResult GetMovieById(int id)
        {
            var result = _movieService.GetById(id);
            return Ok(result);
        }
    }
}
