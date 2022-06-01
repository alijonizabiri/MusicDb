using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connection));

// Mapper Config
builder.Services.AddAutoMapper(typeof(ProfileService));

builder.Services.AddScoped<AlbumServices>();
builder.Services.AddScoped<ArtistServices>();
builder.Services.AddScoped<TrackServices>();
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
