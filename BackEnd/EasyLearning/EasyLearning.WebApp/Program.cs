using EasyLearning.Application;
using EasyLearning.Infrastructure;
using EasyLearning.WebApp.Helper;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllersWithViews();
services.AddInfrastructure(builder.Configuration);
services.AddApplication(builder.Configuration);
services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/account/login";
    options.LogoutPath = $"/account/logout";
    options.AccessDeniedPath = $"/account/accessDenied";
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(
    endpoints =>
    {
        endpoints.MapAreaControllerRoute(
            name: "admin",
            areaName: "admin",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );

        // other areas configurations go here 

        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    }
);

app.Run();
