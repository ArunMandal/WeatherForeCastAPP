using WeatherForecastBusiness.Services;
using WeatherForecastBusiness.Services.LogService;
using WeatherForecastBusiness.Services.WeatherServices;
using WeatherForecastData.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWebRequestLogService<WebRequestLog>, WebRequestLogService>();

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
    pattern: "{controller=weather}/{action=Index}/{id?}");

app.Run();
