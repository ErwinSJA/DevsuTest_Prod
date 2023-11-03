using AutoMapper;
using WebAPI.DevsuTest.DTOs.Cliente;
using WebAPI.DevsuTest.DTOs.Cuenta;
using WebAPI.DevsuTest.DTOs.Movimiento;
using WebAPI.DevsuTest.DTOs.Persona;
using WebAPI.DevsuTest.Models.Cliente;
using WebAPI.DevsuTest.Models.Cuenta;
using WebAPI.DevsuTest.Models.Movimiento;
using WebAPI.DevsuTest.Models.Persona;

namespace WebAPI.DevsuTest.Services.Class
{
    public class clsAutoMapperProfile : Profile
    {
        public clsAutoMapperProfile() 
        {
            // Persona
            CreateMap<DToPersona, ModelPersona>().ReverseMap();

            // Cliente
            CreateMap<DToCliente, ModelCliente>().ReverseMap();

            // Cuenta
            CreateMap<DToCuenta, ModelCuenta>().ReverseMap();

            // Movimiento
            CreateMap<DToMovimiento, ModelMovimiento>().ReverseMap();
        }
    }
}
