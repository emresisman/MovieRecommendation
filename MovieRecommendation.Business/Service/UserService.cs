using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieRecommendation.Business.Repository;
using MovieRecommendation.Business.Request;
using MovieRecommendation.Business.Response;
using MovieRecommendation.Business.Service.Interface;
using MovieRecommendation.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MovieRecommendation.Business.Service
{
    public class UserService : IUserService
    {
        private IRepository<Users> _repository;
        private readonly IConfiguration _configuration;

        public UserService(IRepository<Users> repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _repository.GetWhere(x => x.UserName == model.Username && x.Password == model.Password).FirstOrDefault();

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<Users> GetAll()
        {
            return _repository.Get();
        }

        public Users GetById(int id)
        {
            return _repository.GetById(id);
        }

        // helper methods

        private string generateJwtToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
