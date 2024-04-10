using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EasyLearning.Infrastructure.Data
{
    public class EasyLearningDbContext : IdentityDbContext
    {
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
            optionsBuilder.UseSqlServer(@"Data Source=localhost; Initial Catalog=EasyCommerceShop; User ID=sa; pwd=Password@1234; MultipleActiveResultSets = True; TrustServerCertificate = True");
        }
    }
}
