using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data
{
    public class EasyLearningDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }
   
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<TrainingPart> TrainingParts { get; set; }
        public DbSet<TrainerDetail> TrainerDetails { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CourseEvent> CourseEvents { get; set; }
        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<UserTrainingProgress> UserTrainingProgresss { get; set; }
        public DbSet<ExerciseQuestion> ExerciseQuestions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<UserNote> UserNotes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<OrderDiscount> OrderDiscounts { get; set; }
        public DbSet<CourseDiscount> CourseDiscounts { get; set; }
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
            //optionsBuilder.UseSqlServer("Data Source=TRANTRUNG\\SQLEXPRESS; Initial Catalog=EasyLearningTest; Trusted_Connection=True; TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer("Data Source=LAPTOP-061GCJC2\\NHP28102810; Initial Catalog=EasyLearning; Trusted_Connection=True; TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=EasyLearning; User Id = sa; pwd = Password@1234; Trusted_Connection=True; TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer("Server=tcp:easy-learning-dev.database.windows.net,1433;Initial Catalog=easy-learning;Persist Security Info=False;User ID=supper-admin;Password=Password@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }
    }
}
