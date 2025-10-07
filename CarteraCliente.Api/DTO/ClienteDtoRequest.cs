using System.ComponentModel.DataAnnotations;

namespace CarteraCliente.Api.DTO;

public class ClienteDtoRequest
{
    [Required]
    [StringLength(maximumLength:300, MinimumLength = 1)]
    public string Nombre { get; set; }
    [Required]
    [StringLength(maximumLength:250, MinimumLength = 1)]
    public string PrimerApellido { get; set; }
    [Required]
    [StringLength(maximumLength:250, MinimumLength = 1)]
    public string SegundoApellido { get; set; }
    [Required]
    [StringLength(maximumLength:3, MinimumLength = 3)]
    public string CodigoPais { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [Phone]
    public string Telefono { get; set; }
    [Required]
    [StringLength(maximumLength:1000, MinimumLength = 1)]
    public string Direccion { get; set; }
    
}