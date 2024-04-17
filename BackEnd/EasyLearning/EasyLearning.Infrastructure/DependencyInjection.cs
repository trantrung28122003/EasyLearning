using EasyLearing.Infrastructure.Data.Entities;
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
            services.AddSingleton<UserRepository, UserRepository>();
            services.AddScoped<CourseRepository, CourseRepository>();
            services.AddScoped<CategoryRepository, CategoryRepository>();
            services.AddScoped<CourseDetailRepository, CourseDetailRepository>();
            services.AddScoped<CourseEventRepository, CourseEventRepository>();
            services.AddScoped<TranningPartRepository, TranningPartRepository>();
            services.AddScoped<ShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<ShoppingCartItemRepository, ShoppingCartItemRepository>();
            services.AddScoped<TrainerDetailRepository, TrainerDetailRepository>();
            services.AddScoped<OrderRepository, OrderRepository>();
            services.AddScoped<OrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<FeedbackRepository, FeedbackRepository>();
            services.AddDbContext<EasyLearningDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetSection("Database:ConectionString").Value);
            });
        }
    }
}
