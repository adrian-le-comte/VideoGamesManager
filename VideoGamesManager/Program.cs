using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VideoGamesManager.DataAccess.EfModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.DataAccess;
using Microsoft.AspNetCore.Hosting;
using static System.Formats.Asn1.AsnWriter;
using System.Security.Cryptography;

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

builder.Services.AddTransient<UserManager<User>>();

builder.Services.AddAutoMapper(typeof(VideoGamesManager.DataAccess.AutomapperProfiles));
builder.Services.AddTransient<IVideoGamesRepository, VideoGamesRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IStudioRepository, StudioRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
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
    pattern: "Sellers/{action=Seller}",
    defaults: new { controller = "Sellers" });

app.MapControllerRoute(
    name: "login",
    pattern: "Account/{action=Login}/",
    defaults: new { controller = "Account" });

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<VideoGamesContext>();

    var adminRoleExists = await roleManager.RoleExistsAsync("ADMIN");

    if (!adminRoleExists)
    {
        var adminRole = new IdentityRole<int>("ADMIN");
        await roleManager.CreateAsync(adminRole);
    }

    var adminUser = await userManager.FindByNameAsync("Admin");

    if (adminUser == null)
    {
        adminUser = new User
        {
            UserName = "Admin",
            Email = "admin@example.com",
            NormalizedUserName = "ADMIN",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            LockoutEnd = new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero),
            PasswordHash = "helo",
            PhoneNumber= "0606060606",
            Role = "Admin",
        };

        var result = await userManager.CreateAsync(adminUser, "Test123__");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "ADMIN");
            await dbContext.SaveChangesAsync();
        }
    }
}

app.Run();
