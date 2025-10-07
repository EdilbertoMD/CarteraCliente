using CarteraCliente.Datos.Modelos;

namespace CarteraCliente.Funcionalidad.ClientesFuncionalidad;

public interface ICuentaBancariaFacade
{
    public Task<CuentaBancaria> GuardarAsync(int clienteId, string numeroCuenta, string tipoCuenta, string banco);
    public Task<List<CuentaBancaria>> ObtenerTodosAsync(int clienteId);
    public Task<CuentaBancaria> ObtenerPorIdAsync(int clienteId, int cuentaBancariaId);
    public Task<CuentaBancaria> ActualizarAsync(int clienteId, int cuentaBancariaId, string numeroCuenta, string tipoCuenta, string banco);
    public Task<CuentaBancaria> EliminarAsync(int clienteId, int cuentaBancariaId);
    public Task<CuentaBancaria> ActivarAsync(int clienteId, int cuentaBancariaId);
}