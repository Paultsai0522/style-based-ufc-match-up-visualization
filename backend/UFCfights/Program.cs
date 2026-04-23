using Microsoft.EntityFrameworkCore;
using UFCfights.Data;
using UFCfights.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// builder.Services.AddDbContext<FightsContext> (options => 
//     options.UseSqlite("Data Source = fights.db")
// );
builder.Services.AddDbContext<FightsContext> (options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"))
);

builder.Services.AddScoped<FightsService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendApp", policy =>
    {
        policy.WithOrigins("http://localhost:8000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.MapControllers();
app.UseCors("FrontendApp");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FightsContext>();
    await db.Database.MigrateAsync();
    await CsvImporter.ImportFightsAsync(db, "./Data/data.csv");
}

app.Run();