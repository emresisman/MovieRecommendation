using MovieRecommendation.Entities;

namespace MovieRecommendation.Business.Response
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(Users user, string token)
        {
            Id = user.Id;
            UserName = user.UserName;
            Token = token;
        }
    }
}