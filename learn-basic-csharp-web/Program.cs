using learn_basic_csharp_web.Models.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Create connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Connect to database
builder.Services.AddDbContext<ModelContext>(options =>
{
    options.UseNpgsql(connectionString);
});

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

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
    pattern: "{controller=Auth}/{action=Login}/");

app.Run();
