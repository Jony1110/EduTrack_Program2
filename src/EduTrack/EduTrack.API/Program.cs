using EduTrack.Domain;
using EduTrack.Infraestructure.Repositories;
using EduTrack.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EduTrackDbContext>(p =>
    p.UseSqlServer(builder.Configuration.GetConnectionString("EduTrackStrConnection"))
     .LogTo(Console.WriteLine, LogLevel.Information) // Agrega el logging de consultas aquí
     .EnableSensitiveDataLogging() // Habilita el registro de datos sensibles (opcional para depuración)
);

builder.Services.AddTransient<ProfesorRepository>();

builder.Services.AddTransient<EstudianteRepository>();

builder.Services.AddTransient<ClaseRepository>();

builder.Services.AddTransient<AsistenciaRepository>();

builder.Services.AddTransient<UsuarioRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin() // Permite cualquier origen
              .AllowAnyHeader() // Permite cualquier encabezado
              .AllowAnyMethod(); // Permite cualquier método HTTP
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilita CORS
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
