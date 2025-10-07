namespace CarteraCliente.Api.DTO;

public class ClienteDtoResult
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    
    public string CodigoPais { get; set; }
    
    public string Email { get; set; }
    
    public string Telefono { get; set; }
    
    public string Direccion { get; set; }
    
    public bool Activo { get; set; }
    
}