using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Business.Service.Interface
{
    public interface IMailService
    {
        Task SendMail(string message, string mailAddress);
    }
}