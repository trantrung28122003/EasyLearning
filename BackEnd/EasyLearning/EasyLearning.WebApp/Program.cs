using EasyLearning.Application;
using EasyLearning.Infrastructure;
using EasyLearning.Infrastructure.Data;
using EasyLearning.WebApp.Helper;
using Microsoft.AspNetCore.Identity;

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
services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<EasyLearningDbContext>()
    .AddDefaultTokenProviders();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=ProductManager}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.UseRouting();

app.Run();
