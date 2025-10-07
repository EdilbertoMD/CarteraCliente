using AutoMapper;
using CarteraCliente.Api.DTO;
using CarteraCliente.Funcionalidad.ClientesFuncionalidad;
using Microsoft.AspNetCore.Mvc;

namespace CarteraCliente.Api.Controllers;

[ApiController]
[Route("api/Cliente/{clienteId}/[controller]")]
public class CuentaBancariaController(ICuentaBancariaFacade facade, IMapper mapper):ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CuentaBancariaDtoResult>> Post(CuentaBancariaDtoRequest body, int clienteId)
    {
        try
        {
            // Guardar cuenta bancaria
            var cuentaBancaria = await facade.GuardarAsync(
                clienteId: clienteId,
                numeroCuenta: body.NumeroCuenta,
                tipoCuenta: body.TipoCuenta,
                banco: body.Banco
            );
            // Mapeo 
            var result = mapper.Map<CuentaBancariaDtoResult>(cuentaBancaria);
            // Retorno del cuenta bancaria
            return CreatedAtAction(
                actionName: "Get", 
                routeValues: new { clienteId = clienteId, cuentaBancariaId = result.Id }, // Parámetros para la URL GET
                value: result // El cuerpo del recurso recién creado
            );
        }
        catch (Exception e)
        {
            return BadRequest(error: e.Message);
        }
    }
    [HttpPut("{cuentaBancariaId}")]
    public async Task<ActionResult<CuentaBancariaDtoResult>> Put(CuentaBancariaDtoRequest body, int clienteId, int cuentaBancariaId)
    {
        try
        {
            // Actualizar cuenta bancaria
            var cuentaBancaria = await facade.ActualizarAsync(
                clienteId: clienteId,
                cuentaBancariaId: cuentaBancariaId, 
                numeroCuenta: body.NumeroCuenta,
                tipoCuenta: body.TipoCuenta,
                banco: body.Banco
            );
            // Mapeo 
            var result = mapper.Map<CuentaBancariaDtoResult>(cuentaBancaria);
            // Retorno del result
            return Ok(result);
        }
        catch (Exception e)
        {
            if (e.Message.Contains("no existe"))
            {
                return NotFound(e.Message);
            }
            return BadRequest(error: e.Message);
        }
    }

    [HttpGet("{cuentaBancariaId}")]
    public async Task<ActionResult<CuentaBancariaDtoResult>> Get(int clienteId, int cuentaBancariaId)
    {
        try
        {
            // Obtener cuenta bancaria por id
            var cuentaBancaria = await facade.ObtenerPorIdAsync(clienteId: clienteId, cuentaBancariaId: cuentaBancariaId);
            // Mapeo
            var result = mapper.Map<CuentaBancariaDtoResult>(cuentaBancaria);
            // Return
            return Ok(result);
        }
        catch (Exception e)
        {
            if (e.Message.Contains("no existe"))
            {
                return NotFound(e.Message);
            }
            return BadRequest(error: e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<List<CuentaBancariaDtoResult>>> GetAll(int clienteId)
    {
        try
        {
            // Obtener todaas las cuenta bancaria por id cliente
            var cuentaBancarias = await facade.ObtenerTodosAsync(clienteId: clienteId);
            // Mapeo
            var results = mapper.Map<List<CuentaBancariaDtoResult>>(cuentaBancarias);
            // Return
            return Ok(results);
        }
        catch (Exception e)
        {
            return BadRequest(error: e.Message);
        }
    }

    [HttpDelete("{cuentaBancariaId}")]
    public async Task<ActionResult<CuentaBancariaDtoResult>> Delete(int clienteId, int cuentaBancariaId)
    {
        try
        {
            // Eliminar cuenta por id
            var cuentaBancaria = await facade.EliminarAsync(clienteId: clienteId, cuentaBancariaId: cuentaBancariaId);
            // Mapeo
            var result = mapper.Map<CuentaBancariaDtoResult>(cuentaBancaria);
            // Return
            return Ok(result);
        }
        catch (Exception e)
        {
            if (e.Message.Contains("no existe"))
            {
                return NotFound(e.Message);
            }
            return BadRequest(error: e.Message);
        }
    }
    
    [HttpPut("{cuentaBancariaId}/Activar")]
    public async Task<ActionResult<CuentaBancariaDtoResult>> Activar(int clienteId, int cuentaBancariaId)
    {
        try
        {
            // Activar cuenta por id
            var cuentaBancaria = await facade.ActivarAsync(clienteId: clienteId, cuentaBancariaId: cuentaBancariaId);
            // Mapeo
            var result = mapper.Map<CuentaBancariaDtoResult>(cuentaBancaria);
            // Return
            return Ok(result);
        }
        catch (Exception e)
        {
            if (e.Message.Contains("no existe"))
            {
                return NotFound(e.Message);
            }
            return BadRequest(error: e.Message);
        }
    }
}