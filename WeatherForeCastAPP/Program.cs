using WeatherForeCastAPP.Context;
using WeatherForecastBusiness.Services;
using WeatherForecastBusiness.Services.LogService;
using WeatherForecastBusiness.Services.WeatherServices;
using WeatherForecastData.ConnectionString;
using WeatherForecastData.Model;
using WeatherForecastData.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWebRequestLogService<WebRequestLog>, WebRequestLogService>();
builder.Services.AddScoped<IWebRequestLogRepo, WebRequestLogRepo>();
builder.Services.AddScoped<IConnectionStringProvider, ConfigurationConnectionStringProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   // app.UseExceptionHandler("/Home/Error");
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=weather}/{action=Index}/{id?}");

app.Run();
