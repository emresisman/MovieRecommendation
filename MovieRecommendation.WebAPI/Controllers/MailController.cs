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
        private IRepository<Movies> _repository;

        private readonly IMailService _mailService;

        public MailController(IMailService mailService, IRepository<Movies> repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult SendMail(int movieId, string mailAddress)
        {
            var movieName = _repository.GetById(movieId).Title;
            _mailService.SendMail(movieName, mailAddress);
            return Ok();
        }
    }
    
}
