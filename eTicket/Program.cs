using eTicket.Data;
using eTicket.Data.Cart;
using eTicket.Data.Services;
using eTicket.Data.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

//Add logger (Serilog) 
builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));
try
{
    // Add services to the container.
    builder.Services.AddControllersWithViews();
    // Database configure
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

    //Configure Services Dependency Injections
    builder.Services.AddScoped<IActorsService, ActorsService>();
    builder.Services.AddScoped<IProducersService, ProducersService>();
    builder.Services.AddScoped<ICinemaService, CinemaService>();
    builder.Services.AddScoped<IMoviesService, MoviesService>();
    builder.Services.AddScoped<IOrdersService, OrdersService>();

    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

    builder.Services.AddSession();

    builder.Services.AddControllersWithViews();

    var app = builder.Build();


    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseSession();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Movies}/{action=Index}/{id?}");

    //Seed Database
    AppDbInitializer.Seed(app);
    AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

    app.Run();

    Log.Information("Application Starting...");
}
catch (Exception ex)
{
    Log.Fatal(ex, "Failed to start application.");
}
finally
{
    Log.CloseAndFlush();
}
