using CarteraCliente.Datos.Data;
using CarteraCliente.Datos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CarteraCliente.Funcionalidad.ClientesFuncionalidad;

public class ClienteFacade(ApplicationDbContext context):IClienteFacade
{
    public async Task<Cliente> GuardarAsync(string nombre, string primerApellido, string segundoApellido, string codigoPais, string email, string telefono, string direccion)
    {
        // Validaciones
        await ValidarClienteDuplicadoAsync(email, telefono);
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
        // Validar si el cliente esta activo 
        ValidarClienteActivo(cliente: cliente);
        // Validar si existe un cliente con el mismo email y telefono
        await ValidarClienteDuplicadoAsync(email, telefono, cliente.Id);
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
        ValidarClienteActivo(cliente: cliente);
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
    
    private async Task ValidarClienteDuplicadoAsync(string email, string telefono, int? id = 0)
    {
        // Validar si existe un cliente con el mismo email
        var cliente = await context.Clientes.FirstOrDefaultAsync(x=>(x.Email == email || x.Telefono == telefono) && x.Id != id);
        // Si existe un cliente con el mismo email, lanzar excepcion
        if (cliente?.Email == email)
            throw new Exception($"Ya existe un cliente con el email {email}");
        else if (cliente?.Telefono == telefono)
            throw new Exception($"Ya existe un cliente con el telefono {telefono}");
    }
    private void ValidarClienteActivo(Cliente cliente)
    {
        if (!cliente.Activo)
            throw new Exception("El cliente no esta activo");   
    }
}