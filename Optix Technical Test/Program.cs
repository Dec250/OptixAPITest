using Optix_Technical_Test.Infastruture;
using Microsoft.EntityFrameworkCore;
using Optix_Technical_Test.Application.Interfaces;
using Optix_Technical_Test.Infastruture.Repositories;
using Optix_Technical_Test.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Database Connection string
var connectionString = builder.Configuration.GetConnectionString("MoviesDatabase");

//Database Connection to DB Context
builder.Services.AddDbContext<MoviesDbContext>(options =>


options.UseSqlServer(connectionString, sqlOptions =>

  sqlOptions.EnableRetryOnFailure(
        maxRetryCount: 5,      // Number of retries before failing
        maxRetryDelay: TimeSpan.FromSeconds(10), // Delay between retries
        errorNumbersToAdd: null  // List of SQL error numbers to consider transient (null = default)
    )
));

//DI Injection
//AddScoped => one instance per HTTP request.
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MoviesService>();

builder.Services.AddControllersWithViews(); // MVC services


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllers(); // This enables API routing

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
