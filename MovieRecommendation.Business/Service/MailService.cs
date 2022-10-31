using Microsoft.Extensions.Configuration;
using MovieRecommendation.Business.Service.Interface;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MovieRecommendation.Business.Service
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMail(string movieName, string mailAddress)
        {
            var apiKey = _configuration.GetValue<string>("SendGrid:APIKey");
            var subject = _configuration.GetValue<string>("SendGrid:DefaultSubject") + movieName;
            var message = _configuration.GetValue<string>("SendGrid:DefaultMessage");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("emresisman53@gmail.com", "MovieRecommendation");
            var to = new EmailAddress(mailAddress);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);
        }
    }
}