using Cinema_API.Repositories;
using Cinema_API.Configuration;
using Cinema_API.Logic;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("cors_policy_allow_all", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddSingleton<ICinemaRepository,CinemaRepository_SQL>();
builder.Services.AddSingleton<ICinemaLogic,CinemaLogic>();
builder.Services.Configure<ValidationConfiguration>(builder.Configuration.GetSection("Validation"));
builder.Services.Configure<DBConfiguration>(builder.Configuration.GetSection("Database"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("cors_policy_allow_all");

app.MapControllers();

app.Run();
