using DotNetEnv;
using trekdle.DB_Context;
using Microsoft.EntityFrameworkCore;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var Connection_String = $"server={Environment.GetEnvironmentVariable("DB_SERVER")};" +
                        $"port={Environment.GetEnvironmentVariable("DB_PORT")};" +
                        $"database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                        $"user={Environment.GetEnvironmentVariable("DB_USER")};" +
                        $"password={Environment.GetEnvironmentVariable("DB_PASSWORD")};";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DBContext>(options =>
  options.UseMySql(Connection_String, ServerVersion.AutoDetect(Connection_String)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DBContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}


app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
