using LibraryManagementSystem.Data;   // <-- use your real namespace
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// 🔗 Database connection
builder.Services.AddDbContext<LibraryManagementSyatemContext>(options =>
    options.UseSqlServer(
        "Server=localhost\\SQLEXPRESS;" +
        "Database=LibraryManagementSystem;" +
        "Trusted_Connection=True;" +
        "TrustServerCertificate=True;"
    )
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
