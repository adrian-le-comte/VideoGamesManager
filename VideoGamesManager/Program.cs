using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VideoGamesManager.DataAccess.EfModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("ADMIN"));
    options.AddPolicy("NonAdminOnly", policy =>
    {
        policy.RequireAssertion(context =>
            !context.User.IsInRole("ADMIN"));
    });
});
builder.Services.AddDbContext<VideoGamesContext>();
builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<VideoGamesContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAutoMapper(typeof(VideoGamesManager.DataAccess.AutomapperProfiles));
builder.Services.AddTransient<IVideoGamesRepository, VideoGamesRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IStudioRepository, StudioRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();

builder.Services.AddLogging();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "refill",
    pattern: "Stock/{action=Refill}/",
    defaults: new { controller = "Stock" });

app.MapControllerRoute(
    name: "generatebill",
    pattern: "Destock/{action=GenerateBill}",
    defaults: new { controller = "Destock" });

app.MapControllerRoute(
    name: "categoryadd",
    pattern: "Category/{action=CategoryAdd}",
    defaults: new { controller = "Category" });

app.MapControllerRoute(
    name: "selleradd",
    pattern: "Sellers/{action=SellerAdd}",
    defaults: new { controller = "Sellers" });

app.MapControllerRoute(
    name: "login",
    pattern: "Account/{action=Login}/",
    defaults: new { controller = "Account" });

app.Run();
