using MovieRecommendation.Business.Request;
using MovieRecommendation.Business.Response;
using MovieRecommendation.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRecommendation.Business.Service.Interface
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        IEnumerable<Users> GetAll();

        Task<Users> GetById(int id);
    }
}