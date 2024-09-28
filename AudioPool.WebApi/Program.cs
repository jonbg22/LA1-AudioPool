using AudioPool.Repository.Contexts;
using AudioPool.Repository.Implimentations;
using AudioPool.Repository.Interfaces;
using AudioPool.Services.Implimentations;
using AudioPool.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Repositories
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<IArtistRepository, ArtistRepository>();
builder.Services.AddTransient<IAlbumRepository, AlbumRepository>();
builder.Services.AddTransient<ISongRepository, SongRepository>();
// Services
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<IAlbumService, AlbumService>();
builder.Services.AddTransient<ISongService, SongService>();


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
