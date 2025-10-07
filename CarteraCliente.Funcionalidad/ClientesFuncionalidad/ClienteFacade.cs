using CarteraCliente.Datos.Data;
using CarteraCliente.Datos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CarteraCliente.Funcionalidad.ClientesFuncionalidad;

public class ClienteFacade(ApplicationDbContext context):IClienteFacade
{
    public async Task<Cliente> GuardarAsync(string nombre, string primerApellido, string segundoApellido, string codigoPais, string email, string telefono, string direccion)
    {
        // Validaciones
        ValidarClienteDuplicadoAsync(email);
        // Nuevo cliente
        var cliente = new Cliente(nombre, primerApellido, segundoApellido, codigoPais, email, telefono, direccion);
        // Agrega al contexto
        await context.AddAsync(cliente);
        // Guardar en la base de datos
        await context.SaveChangesAsync();
        // Retorno del cliente
        return cliente;
    }

    public async Task<List<Cliente>> ObtenerTodosAsync()
    {
        // Obtener todos los clientes
        var clientes = await context.Clientes.Include(x=>x.CuentaBancarias).ToListAsync();
        // Retorno de los clientes
        return clientes;
    }

    public async Task<Cliente> ObtenerPorIdAsync(int id)
    {
        // Obtener cliente por id
        var cliente = await context.Clientes.Include(x=>x.CuentaBancarias).FirstOrDefaultAsync(x=>x.Id == id);
        //Validar si existe el cliente
        if (cliente == null)
            throw new Exception("El cliente no existe");
        // Retorno del cliente
        return cliente;
    }

    public async Task<Cliente> ActualizarAsync(int id, string nombre, string primerApellido, string segundoApellido, string codigoPais, string email, string telefono, string direccion)
    {
        // Obtener cliente por id
        var cliente = await ObtenerPorIdAsync(id: id);
        // Actualizar cliente
        cliente.ActualizarCliente(
            nuevoNombre: nombre,
            nuevoPrimerApellido: primerApellido,
            nuevoSegundoApellido: segundoApellido,
            nuevoCodigoPais: codigoPais,
            nuevoEmail: email,
            nuevoTelefono: telefono,  
            nuevoDireccion: direccion);
        // Guardar en la base de datos
        await context.SaveChangesAsync();
        // Retorno del cliente
        return cliente;
        
        
    }

    public async Task<Cliente> EliminarAsync(int id)
    {
        var cliente = await ObtenerPorIdAsync(id);
        cliente.DesactivarCliente();
        await context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> ActivarAsync(int id)
    {
        var cliente = await ObtenerPorIdAsync(id);
        cliente.ActivarCliente();
        await context.SaveChangesAsync();
        return cliente;
    }
    
    private void ValidarClienteDuplicadoAsync(string email)
    {
        // Validar si existe un cliente con el mismo email
        var cliente = context.Clientes.FirstOrDefaultAsync(x=>x.Email == email);
        // Si existe un cliente con el mismo email, lanzar excepcion
        if (cliente != null)
            throw new Exception($"Ya existe un cliente con el {email} ");
    }
}