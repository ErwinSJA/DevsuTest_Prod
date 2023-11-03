using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.DTOs.Movimiento;
using WebAPI.DevsuTest.DTOs.Reporte;

namespace WebAPI.DevsuTest.Interfaces.Services
{
    public interface IReporteService
    {
        Task<DToResponse<DToReporteCabecera>> SVReporteEstadoCuenta(int pintIdCliente, string pstrFechaInicio, string pstrFechaFin, CancellationToken pCancellationToken);
    }
}
