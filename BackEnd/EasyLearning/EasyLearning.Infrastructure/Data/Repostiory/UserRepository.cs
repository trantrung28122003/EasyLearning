namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class UserRepository
    {
        private string _user { set; get; } = string.Empty;
        public string getCurrrentUser()
        {
            return _user;
        }
        public void setUser(string user)
        {
            _user = user;
        }
    }
}
