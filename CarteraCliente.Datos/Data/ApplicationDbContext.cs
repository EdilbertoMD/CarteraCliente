using CarteraCliente.Datos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CarteraCliente.Datos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CuentaBancaria> CuentasBancarias { get; set; }
    }

}