using CarteraCliente.Datos.Data;
using CarteraCliente.Datos.Modelos;

namespace CarteraCliente.Funcionalidad.ClientesFuncionalidad;

public class CuentaBancariaFacade(ApplicationDbContext context, IClienteFacade clienteFacade):ICuentaBancariaFacade
{
    public async Task<CuentaBancaria> GuardarAsync(int clienteId, string numeroCuenta, string tipoCuenta, string banco)
    {
        var cliente = await clienteFacade.ObtenerPorIdAsync(clienteId);
        // Creamos la cuenta bancaria
        var cuentaBancaria = new CuentaBancaria(
            clienteId: clienteId,
            numeroCuenta: numeroCuenta,
            tipoCuenta: tipoCuenta,
            banco: banco);
        // Agregamos la cuenta bancaria al cliente
        cliente.AgregarCuentaBancaria(cuentaBancaria);
        // Guardamos los cambios
        await context.SaveChangesAsync();
        // Retorno de la cuenta bancaria
        return cuentaBancaria;
    }

    public async Task<List<CuentaBancaria>> ObtenerTodosAsync(int clienteId)
    {
        // Obtener cliente por id
        var cliente = await clienteFacade.ObtenerPorIdAsync(clienteId);
        // Retorno de todas las cuenta bancarias
        return cliente.CuentaBancarias;
    }

    public async Task<CuentaBancaria> ObtenerPorIdAsync(int clienteId, int cuentaBancariaId)
    {
        var cliente = await clienteFacade.ObtenerPorIdAsync(clienteId);
        var cuentaBancaria =  cliente.CuentaBancarias.FirstOrDefault(x=>x.Id == cuentaBancariaId);
        if (cuentaBancaria == null)
            throw new Exception($"La cuenta bancaria no existe para el cliente {cliente.NombreCompleto}");
        return cuentaBancaria;
    }

    public async Task<CuentaBancaria> ActualizarAsync(int clienteId, int cuentaBancariaId, string numeroCuenta, string tipoCuenta, string banco)
    {
        var cuentaBancaria = await ObtenerPorIdAsync(clienteId: clienteId, cuentaBancariaId: cuentaBancariaId);
        // Valida si esta activa
        ValidarCuentaBancaraActiva(cuentaBancaria: cuentaBancaria);
        cuentaBancaria.ActualizarCuentaBancaria(numeroCuenta, tipoCuenta, banco);
        await context.SaveChangesAsync();
        return cuentaBancaria;
    }

    public async Task<CuentaBancaria> EliminarAsync(int clienteId, int cuentaBancariaId)
    {
        var cuentaBancaria = await ObtenerPorIdAsync(clienteId: clienteId, cuentaBancariaId: cuentaBancariaId);
        // Valida si esta activa
        ValidarCuentaBancaraActiva(cuentaBancaria: cuentaBancaria);
        cuentaBancaria.DesactivarCuentaBancaria();
        await context.SaveChangesAsync();
        return cuentaBancaria;
    }

    public async Task<CuentaBancaria> ActivarAsync(int clienteId, int cuentaBancariaId)
    {
        var cuentaBancaria = await ObtenerPorIdAsync(clienteId: clienteId, cuentaBancariaId: cuentaBancariaId);
        cuentaBancaria.ActivarCuentaBancaria();
        await context.SaveChangesAsync();
        return cuentaBancaria;
    }

    private void ValidarCuentaBancaraActiva(CuentaBancaria cuentaBancaria)
    {
        if (!cuentaBancaria.Activo)
            throw new Exception("La cuenta bancaria no esta activa");
    }
}