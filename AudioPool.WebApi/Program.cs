using AudioPool.Repository.Contexts;
using AudioPool.Repository.Implimentations;
using AudioPool.Services.Implimentations;
using AudioPool.WebApi.Implimentations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Repositories
builder.Services.AddTransient<GenreRepository>();
builder.Services.AddTransient<ArtistRepository>();
builder.Services.AddTransient<AlbumRepository>();
builder.Services.AddTransient<SongRepository>();
// Services
builder.Services.AddTransient<GenreService>();
builder.Services.AddTransient<ArtistService>();
builder.Services.AddTransient<AlbumService>();
builder.Services.AddTransient<SongService>();
// Controllers
builder.Services.AddTransient<GenreController>();
builder.Services.AddTransient<ArtistController>();
builder.Services.AddTransient<AlbumController>();
builder.Services.AddTransient<SongController>();

// Here we have the connection to the Sqlite database
builder.Services.AddDbContext<MusicDbContext>(options =>
{
    // Package that gives us access to Sqlite. Now we can inject MusicDbContext
    // everywhere in our application.
    options.UseSqlite(builder.Configuration.GetConnectionString("MusicDbConnection"), b => b.  // "MusicDbConnection" is a key in appsettings.json that gives us access to the "MusicDbConnection" key
    MigrationsAssembly("AudioPool.WebApi")); // Save the Migrations folder in MusicCaCaly.WebApi/ folder
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
