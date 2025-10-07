using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarteraCliente.Datos.Data
{
    // Implementa la interfaz IDesignTimeDbContextFactory
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // 1. Configura el DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // 2. Le indicas a EF Core que use SQLite y le das una cadena de conexión Dummy.
            //    La cadena de conexión real se usará en Program.cs en tiempo de ejecución.
            //    Aquí solo necesitamos una válida para que la herramienta funcione.
            optionsBuilder.UseSqlite("DataSource=CarteraCliente.db");

            // 3. Devuelve una instancia del Contexto
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}