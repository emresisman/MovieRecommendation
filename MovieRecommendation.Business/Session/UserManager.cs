using MovieRecommendation.Business.Session;

namespace MovieRecommendation.Business.Interface
{
    public class UserManager : IUserManager
    {
        private UserModel UserModel { get; set; }

        public void SetAuthenticateUser(UserModel userModel)
        {
            this.UserModel = userModel;
        }

        public UserModel GetAuthenticatedUser()
        {
            return this.UserModel;
        }
    }
}
