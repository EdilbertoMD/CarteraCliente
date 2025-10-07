using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarteraCliente.Datos.Modelos;

public class CuentaBancaria
{
    public CuentaBancaria(int clienteId, string numeroCuenta, string tipoCuenta, string banco)
    {
        if (string.IsNullOrWhiteSpace(numeroCuenta))
            throw new Exception("El numero de cuenta es requerido");
        if (string.IsNullOrWhiteSpace(tipoCuenta))
            throw new Exception("El tipo de cuenta es requerido");
        if (string.IsNullOrWhiteSpace(banco))
            throw new Exception("El banco es requerido");
        ClienteId = clienteId;
        NumeroCuenta = numeroCuenta;
        TipoCuenta = tipoCuenta;
        Banco = banco;
        Activo = true;
    }
    
    [Key]
    public int Id { get; private set; }
    // Relacion con un cliente
    public int ClienteId { get; private set; }
    public string NumeroCuenta { get; private set; }
    public string TipoCuenta { get; private set; }
    public string Banco { get; private set; }
    public bool Activo { get; private set; }
}