namespace CarteraCliente.Api.DTO;

public class ClienteDtoResult
{
    public int Id { get; private set; }
    public string Nombre { get; private set; }
    public string PrimerApellido { get; private set; }
    public string SegundoApellido { get; private set; }
    
    public string CodigoPais { get; private set; }
    
    public string Email { get; private set; }
    
    public string Telefono { get; private set; }
    
    public string Direccion { get; private set; }
    
    public bool Activo { get; private set; }
    
}