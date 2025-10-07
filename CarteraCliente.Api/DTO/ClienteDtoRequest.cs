using System.ComponentModel.DataAnnotations;

namespace CarteraCliente.Api.DTO;

public class ClienteDtoRequest
{
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    [StringLength(maximumLength:3, MinimumLength = 3)]
    public string CodigoPais { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    
}