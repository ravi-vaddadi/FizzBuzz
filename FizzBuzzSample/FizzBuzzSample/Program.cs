using FizzBuzzSample.Mappers.Impl;
using FizzBuzzSample.Mappers.Interfaces;
using FizzBuzzSample.Services.Contracts;
using FizzBuzzSample.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IFizzBuzzService, FizzBuzzService>();
builder.Services.AddSingleton<IFizzBuzzViewModelMapper, FizzBuzzViewModelMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
