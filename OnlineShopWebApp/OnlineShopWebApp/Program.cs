using OnlineShopWebApp;
using Serilog;
using Serilog.Core;
using Serilog.Events;


Log.Logger = new LoggerConfiguration()
    
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", "Online Shop")
                .WriteTo.Console()
                .CreateLogger();

Log.Information("Starting web application");
var builder = WebApplication.CreateBuilder(args);

//add logging
builder.Services.AddSerilog((services, lc) => lc
    .ReadFrom.Configuration(builder.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console());


// Add services to the container.
builder.Services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
builder.Services.AddSingleton<IProductsRepository ,ProductsInMemoryRepository>();
builder.Services.AddSingleton<ICartsRepository ,CartsInMemoryRepository>();
builder.Services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogRequestLogging();
//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
