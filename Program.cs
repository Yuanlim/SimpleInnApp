using SimpleInnApp.Application.Bookings.Commands;
using SimpleInnApp.Application.Rooms.Commands;
using SimpleInnApp.Application.Rooms.Query;
using SimpleInnApp.EndPoints;
using SimpleInnApp.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Database
var connString = builder.Configuration.GetConnectionString("SimpleInnDB");
builder.Services.AddSqlite<ApplicationDbContext>(connString);

// Dependency Injection registration
builder.Services.AddTransient<CreateRoomValidator>();
builder.Services.AddTransient<PatchRoomValidator>();
builder.Services.AddTransient<CreateBookingValidator>();
builder.Services.AddScoped<RoomSearchQuery>();

var app = builder.Build();

app.MapGet("/", () => "Alive!");

app.BookingEndpoints();
app.RoomsEndpoints();

app.Run();
