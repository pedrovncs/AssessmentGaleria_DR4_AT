using AssessmentGaleria;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options => 
{
    options.LoginPath = "/Usuario/Login"; 
    options.AccessDeniedPath = "/Usuario/AccessDenied";
});

builder.Services.AddDbContext<GaleriaDBContext>(c =>
{
    var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True; Initial Catalog=AssesmentGaleriaDatabase";
    c.UseSqlServer(connectionString);
}
);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
