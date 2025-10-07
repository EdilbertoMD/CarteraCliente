using CarteraCliente.Datos.Modelos;

namespace CarteraCliente.Funcionalidad.ClientesFuncionalidad;

public interface IClienteFacade
{
    public Task<Cliente> GuardarAsync(string nombre, string primerApellido, string segundoApellido, string codigoPais, string email, string telefono, string direccion);
    public Task<List<Cliente>> ObtenerTodosAsync();
    public Task<Cliente> ObtenerPorIdAsync(int id);
    public Task<Cliente> ActualizarAsync(int id, string nombre, string primerApellido, string segundoApellido, string codigoPais, string email, string telefono, string direccion);
    public Task<Cliente> EliminarAsync(int id);
    public Task<Cliente> ActivarAsync(int id);
    
}