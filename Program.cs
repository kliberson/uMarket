using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using uMarket.Data;
using uMarket.Repository;
using uMarket.Services;
using uMarket.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using uMarket.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IListingRepository, ListingRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();

// Validation
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddDbContext<MarketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<MarketContext>();

builder.Services.AddRazorPages();

// Konfiguracja cookies dla Identity 
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Identity/Account/Login";
//    options.LogoutPath = "/Identity/Account/Logout";
//    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
//    options.SlidingExpiration = true;
//});



var app = builder.Build();

//middleware pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
