using Lab6.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var databaseType = builder.Configuration["DatabaseType"] ?? "SqlServer";
switch (databaseType)
{
    case "Postgres":
        builder.Services.AddDbContext<Lab6DbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
        break;
    case "SQLite":
        builder.Services.AddDbContext<Lab6DbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("SQLite")));
        break;
    case "InMemory":
        builder.Services.AddDbContext<Lab6DbContext>(options =>
            options.UseInMemoryDatabase("Lab6Db"));
        break;
    default:
        builder.Services.AddDbContext<Lab6DbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
        break;
}

builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients) 
    .AddInMemoryApiScopes(Config.ApiScopes) 
    .AddDeveloperSigningCredential(); 


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab6 API v1");
});

app.UseIdentityServer();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "IdentityServer is running");

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
