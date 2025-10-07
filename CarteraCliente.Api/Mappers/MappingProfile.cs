using AutoMapper;
using CarteraCliente.Api.DTO;
using CarteraCliente.Datos.Modelos;

namespace CarteraCliente.Api.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapea el cliente
        CreateMap<Cliente, ClienteDtoResult>();
        
        // Mapea la cuenta bancaria
        CreateMap<CuentaBancaria, CuentaBancariaDtoResult>();
        
        
    }
}