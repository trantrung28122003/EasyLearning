using EasyLearning.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data.Repository
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
        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            using (var context = new EasyLearningDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }
    }
}
