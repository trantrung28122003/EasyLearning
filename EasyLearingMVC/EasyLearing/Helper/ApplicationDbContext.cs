using EasyLearing.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyLearing.Helper
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) 
        { 
        }
        public DbSet<Courses> Courses { get; set; }


    }
}
