using MovieRecommendation.Business.Session;

namespace MovieRecommendation.Business.Interface
{
    public interface IUserManager
    {
        public UserModel GetAuthenticatedUser();
        void SetAuthenticateUser(UserModel userModel);
    }
}
