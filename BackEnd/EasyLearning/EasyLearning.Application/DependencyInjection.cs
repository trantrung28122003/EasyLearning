﻿using EasyLearning.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyLearning.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseDetailService, CourseDetailService>();
            services.AddScoped<ICourseEventService, CourseEventService>();
            services.AddScoped<ITranningPartService, TranningPartService>();
        }
    }
}
