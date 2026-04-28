using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
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

// 🔐 Authentication
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.Cookie.Name = "LibraryAuthCookie";
        options.LoginPath = "/Account/Login";
    });

var app = builder.Build();

// 🚀 Database Initialization & Seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<LibraryManagementSyatemContext>();
        
        // This will create the database and tables if they don't exist
        context.Database.EnsureCreated();

        // Seed an Admin user if none exists
        if (!context.Users.Any())
        {
            context.Users.Add(new User
            {
                Username = "admin",
                Password = "password123",
                Role = "Admin",
                FullName = "System Administrator",
                Email = "admin@library.com",
                Phone = "1234567890"
            });
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
