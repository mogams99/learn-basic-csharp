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


//SIAPKAN TERLEBIH DAHULU KONTOLFIGURASI SESSIONNYA
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".USER_SESSION";
    options.IdleTimeout = TimeSpan.FromMinutes(120); //JADI INI KALAU IDLE SELAMA 120 MENIT AUTO MATI SESSIONNYA
}); //WES SENG BASIC KONTOLFIGURASINE BASIC IKI SEK

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

//SETELAH MENYIAPKAN KONTOLFIGURASINYA LANGSUNG DI USE
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/");

app.Run();
