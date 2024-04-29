using EasyLearning.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyLearning.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFileService, FileService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseDetailService, CourseDetailService>();
            services.AddScoped<ICourseEventService, CourseEventService>();
            services.AddScoped<ITrainingPartService, TrainingPartService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IShoppingCartItemService, ShoppingCartItemService>();
            services.AddScoped<ITrainerDetailService, TrainerDetailService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
