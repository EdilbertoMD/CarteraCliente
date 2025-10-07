using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarteraCliente.Datos.Modelos;

public class CuentaBancaria
{
    public CuentaBancaria(int clienteId, string numeroCuenta, string tipoCuenta, string banco)
    {
        // Validaciones
        ValidarDatos(numeroCuenta, tipoCuenta, banco);
        // Seteo de valores
        ClienteId = clienteId;
        NumeroCuenta = numeroCuenta;
        TipoCuenta = tipoCuenta;
        Banco = banco;
        Activo = true;
    }
    
    [Key]
    public int Id { get; private set; }
    // Relacion con un cliente
    [Required]
    public int ClienteId { get; private set; }
    [Required]
    [StringLength(maximumLength:16, MinimumLength = 10)]
    public string NumeroCuenta { get; private set; }
    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 1)]
    public string TipoCuenta { get; private set; }
    [Required]
    [StringLength(maximumLength: 200, MinimumLength = 1)]
    public string Banco { get; private set; }
    [Required]
    public bool Activo { get; private set; }
    
    #region Metodos publicos
    public void ActualizarCuentaBancaria(string numeroCuenta, string tipoCuenta, string banco)
    {
        ValidarDatos(numeroCuenta, tipoCuenta, banco);
        // Seteo de nuevos valores
        NumeroCuenta = numeroCuenta;
        TipoCuenta = tipoCuenta;
        Banco = banco;
    }

    public void ActivarCuentaBancaria()
    {
        Activo = true;
    }
    
    public void DesactivarCuentaBancaria()
    {
        Activo = false;
    }
    #endregion
    
    #region Metodos privados
    private void ValidarDatos(string numeroCuenta, string tipoCuenta, string banco)
    {
        if (string.IsNullOrWhiteSpace(numeroCuenta))
            throw new Exception("El numero de cuenta es requerido");
        if (string.IsNullOrWhiteSpace(tipoCuenta))
            throw new Exception("El tipo de cuenta es requerido");
        if (string.IsNullOrWhiteSpace(banco))
            throw new Exception("El banco es requerido");
    }
    #endregion
}