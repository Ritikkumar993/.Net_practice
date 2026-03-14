using BusTicketingSys.Data;
using BusTicketingSys.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register Filters (Dependency Injection)
builder.Services.AddScoped<AuthFilter>();
builder.Services.AddScoped<PerformanceFilter>();
builder.Services.AddScoped<BookingLogFilter>();
builder.Services.AddScoped<GlobalExceptionFilter>();
builder.Services.AddScoped<ResponseWrapperFilter>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MVC and register some global filters
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<PerformanceFilter>();      // Resource Filter
    options.Filters.Add<GlobalExceptionFilter>();  // Exception Filter
    options.Filters.Add<ResponseWrapperFilter>();  // Result Filter
});

var app = builder.Build();


// -------- Endpoint Filter Example --------

app.MapPost("/bookSeat", (int seatNo) =>
{
    return Results.Ok($"Seat {seatNo} booked successfully");
})
.AddEndpointFilter(async (context, next) =>
{
    var seat = context.GetArgument<int>(0);

    if (seat <= 0 || seat > 40)
        return Results.BadRequest("Invalid seat number");

    return await next(context);
});


// -------- HTTP Pipeline --------

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
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
