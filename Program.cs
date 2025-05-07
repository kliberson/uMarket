using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.EntityFrameworkCore;
using uMarket.Data;
using uMarket.Repository;
using uMarket.Services;
using uMarket.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MarketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// repisitories 
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IListingRepository, ListingRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//services layer
builder.Services.AddScoped<IUserService, UserService>();

// walidacja
builder.Services.AddFluentValidationClientsideAdapters();               // dla walidacji po stronie klienta
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>(); // rejestruje wszystkie walidatory z tego samego assembly


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

