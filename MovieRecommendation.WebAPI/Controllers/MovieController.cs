﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendation.Business.Request.Pagination;
using MovieRecommendation.Business.Service.Interface;

namespace MovieRecommendation.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("GetAllMovies")]
        [AllowAnonymous]
        public IActionResult GetAllMovies()
        {
            var result = _movieService.GetAllMovies();
            return Ok(result);
        }        
        
        [HttpGet]
        [Route("GetAllMoviesWithPage")]
        [AllowAnonymous]
        public IActionResult GetAllMoviesWithPage([FromQuery] PaginationParameters filter)
        {
            var result = _movieService.GetAllMovies(filter);
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
