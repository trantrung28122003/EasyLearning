using EasyLearning.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class UserRepository
    {
        private string _user { set; get; } = string.Empty;
        public void setUser(string user)
        {
            _user = user;
        }
        public string getCurrrentUser()
        {
            return _user;
        }

        public async Task<string> getCurrrentUserFullNameAsync()
        {
            using (var context = new EasyLearningDbContext())
            {
                var userFullName = await context.Users.FirstOrDefaultAsync(x => x.Id == _user);
                return userFullName.FullName;
            }   
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
