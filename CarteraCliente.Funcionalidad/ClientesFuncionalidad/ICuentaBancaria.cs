using CarteraCliente.Datos.Modelos;

namespace CarteraCliente.Funcionalidad.ClientesFuncionalidad;

public interface ICuentaBancaria
{
    public Task<CuentaBancaria> GuardarAsync(int clienteId, string numeroCuenta, string tipoCuenta, string banco);
    public Task<List<CuentaBancaria>> ObtenerTodosAsync(int clienteId);
    public Task<CuentaBancaria> ObtenerPorIdAsync(int id);
    public Task<CuentaBancaria> ActualizarAsync(int clienteId, int id, string numeroCuenta, string tipoCuenta, string banco);
    public Task<CuentaBancaria> EliminarAsync(int id);
    public Task<CuentaBancaria> ActivarAsync(int id);
}