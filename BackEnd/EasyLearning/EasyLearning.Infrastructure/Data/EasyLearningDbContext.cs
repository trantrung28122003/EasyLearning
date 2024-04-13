using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data
{
    public class EasyLearningDbContext : IdentityDbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }
        public DbSet<TrannerDetail> TrannerDetails { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<TranningPart> TranningParts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CourseEvent> CourseEvents { get; set; }
        public DbSet<AddOn> AddOns { get; set; }
        public EasyLearningDbContext()
        {
        }
        public EasyLearningDbContext(DbContextOptions<EasyLearningDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName() ?? "";
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=TRANTRUNG\\SQLEXPRESS; Initial Catalog=EasyLearning; Trusted_Connection=True; TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=EasyLearning; User Id = sa; pwd = Password@1234; Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}
