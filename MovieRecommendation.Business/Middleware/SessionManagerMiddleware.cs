using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MovieRecommendation.Business.Interface;
using MovieRecommendation.Business.Session;

namespace MovieRecommendation.Business.Middleware
{
    public class SessionManagerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public SessionManagerMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext, IUserManager loginUser)
        {
            if (httpContext.User.Claims.FirstOrDefault(i => i.Type == "userId") != null)
            {
                loginUser.SetAuthenticateUser(new UserModel()
                {
                    Id = Convert.ToInt32(httpContext.User.Claims.First(x => x.Type == "userId").Value),
                    UserName = httpContext.User.Claims.First(x => x.Type == "userName").Value
                });
            }
            await _next.Invoke(httpContext);
        }
    }
}