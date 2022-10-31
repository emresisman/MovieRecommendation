using MovieRecommendation.Business.Request;
using MovieRecommendation.Business.Response;
using MovieRecommendation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Business.Service.Interface
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        IEnumerable<Users> GetAll();

        Users GetById(int id);
    }
}