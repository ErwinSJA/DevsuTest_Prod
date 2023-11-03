using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.DTOs.Cuenta;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.Interfaces.Services;

namespace WebAPI.DevsuTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [SwaggerTag("API que expone métodos REST de Cuenta.")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Indica obtención no válida.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "No autorizado.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status408RequestTimeout, "Excedió el Tiempo de espera.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error general", typeof(DToResponse<string>))]

    public class CuentaController : Controller
    {
        private readonly ICuentaService l_CuentaService;
        private readonly ICapaActualService l_CapaActualService;

        public CuentaController(ICapaActualService pCapaActualService, ICuentaService pCuentaService)
        {
            l_CapaActualService = pCapaActualService;
            l_CuentaService = pCuentaService;
            l_CapaActualService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaControlador);
        }

        [HttpPost]
        [Route("CuentaInsertar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Cuenta Insertar",
            Description = "Registra una nueva Cuenta.",
            OperationId = "CuentaInsertar",
            Tags = new[] { "Cuenta" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Inserción correcta de datos.", typeof(DToResponse<long>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Inserción no válida.", typeof(DToResponse<long>))]
        public async Task<DToResponse<long>> CuentaInsertar([FromBody, SwaggerRequestBody("Datos Cuenta", Required = true)] DToCuenta pobjDToCuenta, CancellationToken pCancellationToken)
        {
            return await l_CuentaService.SVCuentaInsertar(pobjDToCuenta, pCancellationToken);
        }

        [HttpGet]
        [Route("CuentaObtener")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Cuenta Obtener",
            Description = "Obtiene los datos de una Cuenta.",
            OperationId = "CuentaObtener",
            Tags = new[] { "Cuenta" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Obtención correcta de datos.", typeof(DToResponse<DToCuenta>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Obtención no válida.", typeof(DToResponse<DToCuenta>))]
        public async Task<DToResponse<DToCuenta>> CuentaObtener([FromQuery] long plngIdCuenta, CancellationToken pCancellationToken)
        {
            return await l_CuentaService.SVCuentaObtener(plngIdCuenta, pCancellationToken);
        }

        [HttpGet]
        [Route("CuentaListar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Cuenta Listar",
            Description = "Lista las cuentas de un Cliente.",
            OperationId = "CuentaListar",
            Tags = new[] { "Cuenta" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Listado correcto de datos.", typeof(DToResponse<List<DToCuenta>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Listado no válido.", typeof(DToResponse<List<DToCuenta>>))]
        public async Task<DToResponse<List<DToCuenta>>> CuentaListar([FromQuery] int pintIdCliente, CancellationToken pCancellationToken)
        {
            return await l_CuentaService.SVCuentaListar(pintIdCliente, pCancellationToken);
        }

        [HttpDelete]
        [Route("CuentaEliminar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Cuenta Eliminar",
            Description = "Elimina una cuenta.",
            OperationId = "CuentaEliminar",
            Tags = new[] { "Cuenta" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Eliminación correcta de datos.", typeof(DToResponse<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Eliminación no válida.", typeof(DToResponse<bool>))]
        public async Task<DToResponse<bool>> CuentaEliminar([FromQuery] long plngIdCuenta, CancellationToken pCancellationToken)
        {
            return await l_CuentaService.SVCuentaEliminar(plngIdCuenta, pCancellationToken);
        }
    }
}
