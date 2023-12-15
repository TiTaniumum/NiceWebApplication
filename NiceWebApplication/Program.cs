using MySqlConnector;
using NiceWebApplication.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//had to install additional package to fix the problem with views/shared/index
//builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

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