﻿using EasyLearing.Infrastructure.Data.Entities;
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
        public DbSet<TrainerDetail> TrannerDetails { get; set; }
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
            modelBuilder.Entity<ApplicationUser>(e => { e.ToTable("Users"); });

            modelBuilder.Entity<ApplicationRole>()
            .HasData(
                new ApplicationRole { Name = "Admin", NormalizedName = "ADMINISTRATOR" }, // Predefined ID
                new ApplicationRole { Name = "User", NormalizedName = "USER" },
                new ApplicationRole { Name = "Trainer", NormalizedName = "TRAINER" } // Predefined ID
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Data Source=TRANTRUNG\\SQLEXPRESS; Initial Catalog=EasyLearning; Trusted_Connection=True; TrustServerCertificate=True");
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-061GCJC2\\NHP28102810; Initial Catalog=EasyLearning; Trusted_Connection=True; TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer("Data Source=LAPTOP-79O7GIJ9\\SQLEXPRESS; Initial Catalog=EasyLearning; User Id = sa; pwd = Password@1234; Trusted_Connection=True; TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer("Server=tcp:easy-learning-dev.database.windows.net,1433;Initial Catalog=easy-learning;Persist Security Info=False;User ID=supper-admin;Password=Password@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }
    }
}
