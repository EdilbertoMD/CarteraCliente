using System.ComponentModel.DataAnnotations;

namespace CarteraCliente.Api.DTO;

public class CuentaBancariaDtoRequest
{
    [Required]
    [StringLength(maximumLength:16, MinimumLength = 10)]
    public string NumeroCuenta { get; set; }
    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 1)]
    public string TipoCuenta { get; set; }
    [Required]
    [StringLength(maximumLength: 200, MinimumLength = 1)]
    public string Banco { get; set; }
}