using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.DTOs.Cliente;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.DTOs.Persona;
using WebAPI.DevsuTest.Interfaces.Services;

namespace WebAPI.DevsuTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [SwaggerTag("API que expone métodos REST de Cliente.")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Indica obtención no válida.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "No autorizado.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status408RequestTimeout, "Excedió el Tiempo de espera.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error general", typeof(DToResponse<string>))]

    public class ClienteController : Controller
    {
        private readonly IPersonaService l_PersonaService;
        private readonly ICapaActualService l_CapaActualService;
        private readonly IClienteService l_ClienteService;

        public ClienteController(ICapaActualService pCapaActualService, IPersonaService pPersonaService, IClienteService pClienteService)
        {
            l_CapaActualService = pCapaActualService;
            l_PersonaService = pPersonaService;
            l_ClienteService = pClienteService;
            l_CapaActualService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaControlador);
        }

        [HttpPost]
        [Route("PersonaInsertar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Persona Insertar",
            Description = "Registra una nueva persona.",
            OperationId = "PersonaInsertar",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Inserción correcta de datos.", typeof(DToResponse<int>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Inserción no válida.", typeof(DToResponse<int>))]
        public async Task<DToResponse<int>> PersonaInsertar([FromBody, SwaggerRequestBody("Datos Persona", Required = true)] DToPersona pobjDToPersona, CancellationToken pCancellationToken)
        {
            return await l_PersonaService.SVPersonaInsertar(pobjDToPersona, pCancellationToken);
        }

        [HttpGet]
        [Route("PersonaObtener")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Persona Obtener",
            Description = "Obtiene los datos de una persona.",
            OperationId = "PersonaObtener",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Obtención correcta de datos.", typeof(DToResponse<DToPersona>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Obtención no válida.", typeof(DToResponse<DToPersona>))]
        public async Task<DToResponse<DToPersona>> PersonaObtener([FromQuery] string pstrIdentificacion, CancellationToken pCancellationToken)
        {
            return await l_PersonaService.SVPersonaObtener(pstrIdentificacion, pCancellationToken);
        }

        [HttpGet]
        [Route("PersonaListar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Persona Listar",
            Description = "Lista los datos de todas las personas.",
            OperationId = "PersonaListar",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Listado correcto de datos.", typeof(DToResponse<List<DToPersona>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Listado no válido.", typeof(DToResponse<List<DToPersona>>))]
        public async Task<DToResponse<List<DToPersona>>> PersonaListar(CancellationToken pCancellationToken)
        {
            return await l_PersonaService.SVPersonaListar( pCancellationToken);
        }

        [HttpPut]
        [Route("PersonaDatosModificar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Persona Modificar Datos",
            Description = "Modifica los datos de una persona.",
            OperationId = "PersonaDatosModificar",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Modificación correcta de datos.", typeof(DToResponse<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Modificación no válida.", typeof(DToResponse<bool>))]
        public async Task<DToResponse<bool>> PersonaDatosModificar([FromBody, SwaggerRequestBody("Datos Persona", Required = true)] DToPersona pobjDToPersona, CancellationToken pCancellationToken)
        {
            return await l_PersonaService.SVPersonaDatosModificar(pobjDToPersona, pCancellationToken);
        }

        [HttpPatch]
        [Route("PersonaDatosModificarParcial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Persona Modificar Parcial Datos",
            Description = "Modifica parcialmente los datos de una persona.",
            OperationId = "PersonaDatosModificarParcial",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Modificación parcial correcta de datos.", typeof(DToResponse<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Modificación parcial no válida.", typeof(DToResponse<bool>))]
        public async Task<DToResponse<bool>> PersonaDatosModificarParcial([FromQuery] string pstrIdentificacion, [FromBody, SwaggerRequestBody("Datos Persona", Required = true)] JsonPatchDocument<DToPersona> pobjDToPersona, CancellationToken pCancellationToken)
        {
            return await l_PersonaService.SVPersonaDatosModificarParcial(pstrIdentificacion, pobjDToPersona, pCancellationToken);
        }

        [HttpPost]
        [Route("ClienteInsertar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Cliente Insertar",
            Description = "Registra un nuevo cliente.",
            OperationId = "ClienteInsertar",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Inserción correcta de datos.", typeof(DToResponse<int>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Inserción no válida.", typeof(DToResponse<int>))]
        public async Task<DToResponse<int>> ClienteInsertar([FromBody, SwaggerRequestBody("Datos Cliente", Required = true)] DToClienteCreate pobjDToCliente, CancellationToken pCancellationToken)
        {
            return await l_ClienteService.SVClienteInsertar(pobjDToCliente, pCancellationToken);
        }

        [HttpGet]
        [Route("ClienteObtener")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Cliente Obtener",
            Description = "Obtiene los datos de un Cliente.",
            OperationId = "ClienteObtener",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Obtención correcta de datos.", typeof(DToResponse<DToCliente>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Obtención no válida.", typeof(DToResponse<DToCliente>))]
        public async Task<DToResponse<DToCliente>> ClienteObtener([FromQuery] int pintIdCliente, CancellationToken pCancellationToken)
        {
            return await l_ClienteService.SVClienteObtener(pintIdCliente, pCancellationToken);
        }

        [HttpGet]
        [Route("ClienteListar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Cliente Listar",
            Description = "Lista los datos de todas los clientes.",
            OperationId = "ClienteListar",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(StatusCodes.Status201Created, "Listado correcto de datos.", typeof(DToResponse<List<DToCliente>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Listado no válido.", typeof(DToResponse<List<DToCliente>>))]
        public async Task<DToResponse<List<DToCliente>>> ClienteListar(CancellationToken pCancellationToken)
        {
            return await l_ClienteService.SVClienteListar(pCancellationToken);
        }

        [HttpPut]
        [Route("ClientePasswordModificar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(
        Summary = "Cliente Password Modificar",
            Description = "Modifica la clave de un cliente.",
            OperationId = "ClientePasswordModificar",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Modificacion correcta de datos.", typeof(DToResponse<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Modificacion no válida.", typeof(DToResponse<bool>))]
        public async Task<DToResponse<bool>> ClientePasswordModificar([FromBody, SwaggerRequestBody("Datos Cliente", Description = "intIdCliente, strClave" , Required = true)] DToClienteUpdate pobjDToCliente, CancellationToken pCancellationToken)
        {
            return await l_ClienteService.SVClientePasswordModificar(pobjDToCliente, pCancellationToken);
        }

        [HttpPut]
        [Route("ClienteEstadoModificar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(
        Summary = "Cliente Estado Modificar",
            Description = "Modifica el estado de un cliente.",
            OperationId = "ClienteEstadoModificar",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Modificación correcta de estado.", typeof(DToResponse<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Modificación no válida.", typeof(DToResponse<bool>))]
        public async Task<DToResponse<bool>> ClienteEstadoModificar([FromBody, SwaggerRequestBody("Datos Cliente", Description = "intIdCliente, blnEstado", Required = true)] DToClienteUpdate pobjDToCliente, CancellationToken pCancellationToken)
        {
            return await l_ClienteService.SVClienteEstadoModificar(pobjDToCliente, pCancellationToken);
        }
    }
}
