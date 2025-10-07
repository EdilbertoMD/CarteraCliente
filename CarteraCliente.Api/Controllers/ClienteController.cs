using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using CarteraCliente.Api.DTO;
using CarteraCliente.Funcionalidad.ClientesFuncionalidad;
using Microsoft.AspNetCore.Mvc;

namespace CarteraCliente.Api.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class ClienteController(IClienteFacade facade, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ClienteDtoResult> Post(ClienteDtoRequest body)
    {
        try
        {
            var cliente = await facade.GuardarAsync(
                nombre: body.Nombre,
                primerApellido: body.PrimerApellido,
                segundoApellido: body.SegundoApellido,
                codigoPais: body.CodigoPais,
                email: body.Email,
                telefono: body.Telefono,
                direccion: body.Direccion
            );
            // Mapeo del cliente
            ClienteDtoResult result = mapper.Map<ClienteDtoResult>(cliente);
            // Retorno del cliente
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


}