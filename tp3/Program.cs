using Microsoft.EntityFrameworkCore;
using tp3.Models.Data;
using tp3.Models.DataManager;
using tp3.Models.EntityFramework;
using tp3.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Ajouter une politique CORS pour autoriser les requêtes depuis l'application Blazor
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy => policy
            .WithOrigins("http://localhost:5000") // Remplacez par l'URL de l'application Blazor
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(e =>
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

// Activer CORS en appliquant la politique définie
app.UseCors("AllowBlazorClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
