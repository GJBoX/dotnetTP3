using Microsoft.EntityFrameworkCore;
using tp3.Models.Data;
using tp3.Models.DataManager;
using tp3.Models.EntityFramework;
using tp3.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(e=>
    e.UseNpgsql(builder.Configuration.GetConnectionString("SeriesDbContextPgsql")));
builder.Services.AddScoped<IDataRepository<Utilisateur>, UtilisateurManager>();
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
