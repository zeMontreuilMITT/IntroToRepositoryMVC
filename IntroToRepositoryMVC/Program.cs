using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IntroToRepositoryMVC.Data;
using IntroToRepositoryMVC.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<IntroToRepositoryMVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IntroToRepositoryMVCContext") ?? throw new InvalidOperationException("Connection string 'IntroToRepositoryMVCContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<Movie>), typeof(MovieRepository));
builder.Services.AddScoped(typeof(IRepository<Actor>), typeof(ActorRepository));
builder.Services.AddScoped(typeof(IRepository<Role>), typeof(RoleRepository));

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
