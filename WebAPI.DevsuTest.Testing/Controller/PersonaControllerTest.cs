using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using System.Text.RegularExpressions;
using System.Threading;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.Controllers;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.DTOs.Persona;
using WebAPI.DevsuTest.Interfaces.Services;

namespace WebAPI.DevsuTest.Testing.Controller
{
    public class PersonaControllerTest
    {
        private readonly IPersonaService l_PersonaService;
        private readonly IClienteService l_ClienteService;
        private readonly ICapaActualService l_CapaActualService;
        private CancellationToken l_CancellationToken;

        public PersonaControllerTest() 
        {
            l_PersonaService = A.Fake<IPersonaService>();
            l_ClienteService = A.Fake<IClienteService>();
            l_CapaActualService = A.Fake<ICapaActualService>();
        }

        [Fact]
        public void PersonaController_PersonaListar_ReturnOK()
        {
            //Arrange
            var objController = new ClienteController(l_CapaActualService, l_PersonaService, l_ClienteService);

            l_CancellationToken = new CancellationToken();
            var lstResult = objController.PersonaListar(l_CancellationToken);

            //Assert
            lstResult.Should().NotBeNull();
            lstResult.Should().BeOfType(typeof(Task<DToResponse<List<DToPersona>>>));
        }

        [Fact]
        public void PersonaController_PersonaInsertar_ReturnOK()
        {
            //Arrange
            var objDToPersona = A.Fake<DToPersona>();

            objDToPersona.strIdentificacion = "47484943";
            objDToPersona.strNombre = "Prueba desde Proyecto Testing";
            objDToPersona.bytGenero = 1;
            objDToPersona.intEdad = 99;
            objDToPersona.strDireccion = "Direccion Testing";
            objDToPersona.strTelefono = "949784858";

            var lstPersona = A.Fake<List<DToPersona>>();
            var objController = new ClienteController(l_CapaActualService, l_PersonaService, l_ClienteService);

            //Act
            l_CancellationToken = new CancellationToken();
            var lstResult = objController.PersonaInsertar(objDToPersona, l_CancellationToken);

            //Assert
            lstResult.Should().NotBeNull();
            lstResult.Should().BeOfType(typeof(Task<DToResponse<int>>));
        }
    }
}
