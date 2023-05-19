using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VideoGamesManager.DataAccess.EfModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.AddDbContext<VideoGamesContext>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<VideoGamesContext>()
    .AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "purchase",
    pattern: "Purchase/{action=Buy}/",
    defaults: new { controller = "Purchase" });

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
