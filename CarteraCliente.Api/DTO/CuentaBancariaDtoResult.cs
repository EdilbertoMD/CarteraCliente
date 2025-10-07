namespace CarteraCliente.Api.DTO;

public class CuentaBancariaDtoResult
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string NumeroCuenta { get; set; }
    public string TipoCuenta { get; set; }
    public string Banco { get; set; }
    public bool Activo { get; set; }
}