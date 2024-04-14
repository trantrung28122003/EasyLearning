﻿using EasyLearning.Infrastructure.Data;
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
            services.AddScoped<UserRepository, UserRepository>();
            services.AddScoped<CourseRepository, CourseRepository>();
            services.AddScoped<CategoryRepository, CategoryRepository>();
            services.AddScoped<CourseDetailRepository, CourseDetailRepository>();
            services.AddScoped<CourseEventRepository, CourseEventRepository>();
            services.AddScoped<TranningPartRepository, TranningPartRepository>();
            services.AddDbContext<EasyLearningDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetSection("Database:ConectionString").Value);
            });
        }
    }
}
