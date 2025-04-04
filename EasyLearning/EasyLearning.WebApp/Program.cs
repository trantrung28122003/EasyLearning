using EasyLearning.Application;
using EasyLearning.Infrastructure;
using EasyLearning.Infrastructure.Data;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.WebApp.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllersWithViews();
services.AddInfrastructure(builder.Configuration);
services.AddApplication(builder.Configuration);
services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
services.AddDistributedMemoryCache();
// Configure session options

services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1); // Set session timeout
});

services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/account/login";
    options.LogoutPath = $"/account/logout";
    options.AccessDeniedPath = $"/account/accessDenied";
});
services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<EasyLearningDbContext>()
    .AddDefaultTokenProviders();
var clientId = builder.Configuration.GetSection("Authentication:ClientId").Value;
var clientSecret = builder.Configuration.GetSection("Authentication:ClientSecret").Value;
services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
    .AddCookie()
    .AddGoogle(options =>
    {
        options.ClientId = clientId;
        options.ClientSecret = clientSecret;
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSession();

app.Run();
