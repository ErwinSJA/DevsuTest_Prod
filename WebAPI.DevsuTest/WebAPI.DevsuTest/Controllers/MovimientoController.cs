using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.DTOs.Movimiento;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.Interfaces.Services;

namespace WebAPI.DevsuTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [SwaggerTag("API que expone métodos REST de Movimientos.")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Indica obtención no válida.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "No autorizado.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status408RequestTimeout, "Excedió el Tiempo de espera.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error general", typeof(DToResponse<string>))]

    public class MovimientoController : Controller
    {
        private readonly IMovimientoService l_MovimientoService;
        private readonly ICapaActualService l_CapaActualService;

        public MovimientoController(ICapaActualService pCapaActualService, IMovimientoService pMovimientoService)
        {
            l_CapaActualService = pCapaActualService;
            l_MovimientoService = pMovimientoService;
            l_CapaActualService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaControlador);
        }

        [HttpPost]
        [Route("MovimientoInsertar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Movimiento Insertar",
            Description = "Registra un nuevo Movimiento.",
            OperationId = "MovimientoInsertar",
            Tags = new[] { "Movimiento" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Inserción correcta de datos.", typeof(DToResponse<long>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Inserción no válida.", typeof(DToResponse<long>))]
        public async Task<DToResponse<long>> MovimientoInsertar([FromBody, SwaggerRequestBody("Datos Movimiento", Required = true)] DToMovimiento pobjDToMovimiento, CancellationToken pCancellationToken)
        {
            return await l_MovimientoService.SVMovimientoInsertar(pobjDToMovimiento, pCancellationToken);
        }

        [HttpGet]
        [Route("MovimientoObtener")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Movimiento Obtener",
            Description = "Obtiene los datos de un Movimiento.",
            OperationId = "MovimientoObtener",
            Tags = new[] { "Movimiento" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Obtención correcta de datos.", typeof(DToResponse<DToMovimiento>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Obtención no válida.", typeof(DToResponse<DToMovimiento>))]
        public async Task<DToResponse<DToMovimiento>> MovimientoObtener([FromQuery] long plngIdMovimiento, CancellationToken pCancellationToken)
        {
            return await l_MovimientoService.SVMovimientoObtener(plngIdMovimiento, pCancellationToken);
        }

        [HttpGet]
        [Route("MovimientoListarxCuenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Movimiento Listar Cuenta",
            Description = "Lista los Movimientos de una Cuenta.",
            OperationId = "MovimientoListarxCuenta",
            Tags = new[] { "Movimiento" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Listado correcto de datos.", typeof(DToResponse<List<DToMovimiento>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Listado no válido.", typeof(DToResponse<List<DToMovimiento>>))]
        public async Task<DToResponse<List<DToMovimiento>>> MovimientoListarxCuenta([FromQuery] long plngIdCuenta, CancellationToken pCancellationToken)
        {
            return await l_MovimientoService.SVMovimientoListarxCuenta(plngIdCuenta, pCancellationToken);
        }

        [HttpGet]
        [Route("MovimientoListarxCuentaFecha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Movimiento Listar Cuenta y Fecha",
            Description = "Lista los Movimientos de una Cuenta en un rango de fechas (DD-MM-YYYY)",
            OperationId = "MovimientoListarxCuentaFecha",
            Tags = new[] { "Movimiento" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Listado correcto de datos.", typeof(DToResponse<List<DToMovimiento>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Listado no válido.", typeof(DToResponse<List<DToMovimiento>>))]
        public async Task<DToResponse<List<DToMovimiento>>> MovimientoListarxCuentaFecha([FromQuery] long plngIdCuenta, [FromQuery] string pstrFechaInicio, [FromQuery] string pstrFechaFin, CancellationToken pCancellationToken)
        {
            return await l_MovimientoService.SVMovimientoListarxCuentaFecha(plngIdCuenta, pstrFechaInicio, pstrFechaFin, pCancellationToken);
        }

        [HttpDelete]
        [Route("MovimientoEliminar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Movimiento Eliminar",
            Description = "Elimina una Movimiento.",
            OperationId = "MovimientoEliminar",
            Tags = new[] { "Movimiento" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Eliminación correcta de datos.", typeof(DToResponse<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Eliminación no válida.", typeof(DToResponse<bool>))]
        public async Task<DToResponse<bool>> MovimientoEliminar([FromQuery] long plngIdMovimiento, CancellationToken pCancellationToken)
        {
            return await l_MovimientoService.SVMovimientoEliminar(plngIdMovimiento, pCancellationToken);
        }
    }
}
