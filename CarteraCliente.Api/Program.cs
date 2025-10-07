using CarteraCliente.Api.Mappers;
using CarteraCliente.Datos;
using CarteraCliente.Datos.Data;
using CarteraCliente.Funcionalidad.ClientesFuncionalidad;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Añadir el DbContext y configurarlo para usar SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlite(connectionString));
// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

//Inyecta funcionalidad
builder.Services.AddScoped<IClienteFacade, ClienteFacade>(); 


builder.Services.AddControllers();

// 1. Añadir el generador de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        // Define el endpoint para la especificación JSON
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API de Clientes y Cuentas V1");
        // Establece la ruta raíz del Swagger UI
        c.RoutePrefix = string.Empty; 
    });
}



app.UseRouting();

app.UseHttpsRedirection();

// las rutas a los controladores definidos con [Route("...")]
app.MapControllers();

app.Run();

