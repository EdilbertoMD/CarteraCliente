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
    public async Task<ActionResult<ClienteDtoResult>> Post(ClienteDtoRequest body)
    {
        try
        {
            // Guardar cliente
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
            return CreatedAtAction(
                actionName: "Get", 
                routeValues: new { id = result.Id }, // Parámetros para la URL GET
                value: result // El cuerpo del recurso recién creado
            );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(error: e.Message);
        }
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<ClienteDtoResult>> Put(ClienteDtoRequest body, int id)
    {
        try
        {
            // Actualizar cliente
            var cliente = await facade.ActualizarAsync(
                id: id,
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
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(error: e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClienteDtoResult>> Get(int id)
    {
        try
        {
            // Obtener cliente por id
            var cliente = await facade.ObtenerPorIdAsync(id);
            // Mapeo
            ClienteDtoResult result = mapper.Map<ClienteDtoResult>(cliente);
            // Return
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(error: e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ClienteDtoResult>>> GetAll()
    {
        try
        {
            // Obtener cliente por id
            var clientes = await facade.ObtenerTodosAsync();
            // Mapeo
            List<ClienteDtoResult> results = mapper.Map<List<ClienteDtoResult>>(clientes);
            // Return
            return Ok(results);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(error: e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ClienteDtoResult>> Delete(int id)
    {
        try
        {
            // Obtener cliente por id
            var cliente = await facade.EliminarAsync(id);
            // Mapeo
            ClienteDtoResult result = mapper.Map<ClienteDtoResult>(cliente);
            // Return
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(error: e.Message);
        }
    }
    
    [HttpPut("{id}/Activar")]
    public async Task<ActionResult<ClienteDtoResult>> Activar(int id)
    {
        try
        {
            // Obtener cliente por id
            var cliente = await facade.ActivarAsync(id);
            // Mapeo
            ClienteDtoResult result = mapper.Map<ClienteDtoResult>(cliente);
            // Return
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(error: e.Message);
        }
    }
    
    
}