using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendation.Business.Request;
using MovieRecommendation.Business.Request.Pagination;
using MovieRecommendation.Business.Service.Interface;

namespace MovieRecommendation.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class RatingNoteController : Controller
    {
        private readonly IRatingNoteService _ratingNoteService;

        public RatingNoteController(IRatingNoteService ratingNoteService)
        {
            _ratingNoteService = ratingNoteService;
        }

        [HttpPost]
        [Route("SetRatingToMovie")]
        [AllowAnonymous]
        public IActionResult SetRatingToMovie(RatingRequest filter)
        {
            _ratingNoteService.SetRatingToMovie(filter);
            return Ok();
        }
        
        [HttpPost]
        [Route("SetNotesToMovie")]
        [AllowAnonymous]
        public IActionResult SetNotesToMovie(NoteRequest filter)
        {
            _ratingNoteService.SetNoteToMovie(filter);
            return Ok();
        }

    }
}