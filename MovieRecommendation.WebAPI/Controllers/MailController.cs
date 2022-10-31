using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendation.Business.Repository;
using MovieRecommendation.Business.Service.Interface;
using MovieRecommendation.Entities;

namespace MovieRecommendation.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMailService _mailService;

        public MailController(IMailService mailService, IMovieService movieService)
        {
            _mailService = mailService;
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult SendMail(int movieId, string mailAddress)
        {
            var movieName = _movieService.GetById(movieId).Title;
            _mailService.SendMail(movieName, mailAddress);
            return Ok();
        }
    }
    
}
