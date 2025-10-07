using System.ComponentModel.DataAnnotations;

namespace CarteraCliente.Datos.Modelos;

public class Cliente
{
    public Cliente(string nombre, string primerApellido, string segundoApellido, string codigoPais, string email, string telefono, string direccion)
    {
        // Validaciones
        ValidarDatos(nombre: nombre,
            primerApellido: primerApellido,
            segundoApellido: segundoApellido,
            codigoPais: codigoPais,
            email: email,
            telefono: telefono,
            direccion: direccion);
        // Seteo de valores
        Nombre = nombre;
        PrimerApellido = primerApellido;
        SegundoApellido = segundoApellido;
        CodigoPais = codigoPais;
        Email = email;
        Telefono = telefono;
        Direccion = direccion;
        Activo = true;
    }
    
    [Key]
    public int  Id { get; private set; }
    [Required]
    [StringLength(maximumLength:300, MinimumLength = 1)]
    public string Nombre { get; private set; }
    [Required]
    [StringLength(maximumLength:250, MinimumLength = 1)]
    public string PrimerApellido { get; private set; }
    [Required]
    [StringLength(maximumLength:250, MinimumLength = 1)]
    public string SegundoApellido { get; private set; }
    [StringLength(maximumLength:3, MinimumLength = 3)]
    public string CodigoPais { get; private set; }
    [EmailAddress]
    public string Email { get; private set; }
    [Phone]
    public string Telefono { get; private set; }
    [StringLength(maximumLength:1000, MinimumLength = 1)]
    public string Direccion { get; private set; }
    
    public bool Activo { get; private set; }

    public List<CuentaBancaria> CuentaBancarias { get; private set; } = new();

    #region Metodos publicos

    

    
    public void ActualizarCliente(string nuevoNombre, string nuevoPrimerApellido, string nuevoSegundoApellido, string nuevoCodigoPais, string nuevoEmail, string nuevoTelefono, string nuevoDireccion)
    {
        ValidarDatos(nombre: nuevoNombre,
            primerApellido: nuevoPrimerApellido,
            segundoApellido: nuevoSegundoApellido,
            codigoPais: nuevoCodigoPais,
            email: nuevoEmail,
            telefono: nuevoTelefono,
            direccion: nuevoDireccion);
        // Seteo de nuevos valores
        Nombre = nuevoNombre;
        PrimerApellido = nuevoPrimerApellido;
        SegundoApellido = nuevoSegundoApellido;
        CodigoPais = nuevoCodigoPais;
        Email = nuevoEmail;
        Telefono = nuevoTelefono;
        Direccion = nuevoDireccion;
    }

    public void ActivarCliente()
    {
        Activo = true;
    }
    
    public void DesactivarCliente()
    {
        Activo = false;
    }
    
    public void AgregarCuentaBancaria(CuentaBancaria cuentaBancaria)
    {
        if (cuentaBancaria == null)
            throw new Exception("La cuenta bancaria es requerida");
        if (CuentaBancarias.Any(x=>x.NumeroCuenta == cuentaBancaria.NumeroCuenta && x.TipoCuenta == cuentaBancaria.TipoCuenta))
            throw new Exception("Ya existe una cuenta bancaria con el mismo numero y tipo de cuenta");
        CuentaBancarias.Add(cuentaBancaria);
    }
    #endregion
    
    #region Metodos privados
    private void ValidarDatos(string nombre, string primerApellido, string segundoApellido, string codigoPais, string email, string telefono, string direccion)
    {
        // Validaciones
        if (string.IsNullOrWhiteSpace(nombre))
            throw new Exception("El nombre es requerido");
        if (string.IsNullOrWhiteSpace(primerApellido))
            throw new Exception("El primer apellido es requerido");
        if (string.IsNullOrWhiteSpace(segundoApellido))
            throw new Exception("El segundo apellido es requerido");
        if (string.IsNullOrWhiteSpace(codigoPais))
            throw new Exception("El codigo pais es requerido");
        if (string.IsNullOrWhiteSpace(email))
            throw new Exception("El email es requerido");
        if (string.IsNullOrWhiteSpace(telefono))
            throw new Exception("El telefono es requerido");
        if (string.IsNullOrWhiteSpace(direccion))
            throw new Exception("La direccion es requerida");
    }
    #endregion
    
}