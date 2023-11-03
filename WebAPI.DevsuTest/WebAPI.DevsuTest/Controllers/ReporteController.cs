using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.DTOs.Reporte;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.Interfaces.Services;

namespace WebAPI.DevsuTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [SwaggerTag("API que expone métodos REST de Reporteria.")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Indica obtención no válida.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "No autorizado.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status408RequestTimeout, "Excedió el Tiempo de espera.", typeof(DToResponse<string>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error general", typeof(DToResponse<string>))]

    public class ReporteController : Controller
    {
        private readonly IReporteService l_ReporteService;
        private readonly ICapaActualService l_CapaActualService;

        public ReporteController(ICapaActualService pCapaActualService, IReporteService pReporteService)
        {
            l_CapaActualService = pCapaActualService;
            l_ReporteService = pReporteService;
            l_CapaActualService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaControlador);
        }

        [HttpGet]
        [Route("ReporteEstadoCuenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Reporte Estado de Cuenta con rango de Fecha",
            Description = "Reporte de Estado de Cuenta de Cliente en un rango de fechas (DD-MM-YYYY)",
            OperationId = "ReporteEstadoCuenta",
            Tags = new[] { "Reporte" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Reporte correcto de datos.", typeof(DToResponse<DToReporteCabecera>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Reporte no válido.", typeof(DToResponse<DToReporteCabecera>))]
        public async Task<DToResponse<DToReporteCabecera>> ReporteEstadoCuenta([FromQuery] int pintIdCliente, [FromQuery] string pstrFechaInicio, [FromQuery] string pstrFechaFin, CancellationToken pCancellationToken)
        {
            return await l_ReporteService.SVReporteEstadoCuenta(pintIdCliente, pstrFechaInicio, pstrFechaFin, pCancellationToken);
        }
    }
}
