using EasyLearning.Infrastructure.Data;
using EasyLearning.Infrastructure.Data.Repostiory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyLearning.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<CourseRepository, CourseRepository>();
            services.AddDbContext<EasyLearningDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetSection("Database:ConectionString").Value);
            });
        }
    }
}
