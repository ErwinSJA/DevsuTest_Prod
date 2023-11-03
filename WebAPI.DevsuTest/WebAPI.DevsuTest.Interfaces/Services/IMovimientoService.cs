using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.DTOs.Movimiento;

namespace WebAPI.DevsuTest.Interfaces.Services
{
    public interface IMovimientoService
    {
        Task<DToResponse<long>> SVMovimientoInsertar(DToMovimiento pobjDToMovimiento, CancellationToken pCancellationToken);
        Task<DToResponse<DToMovimiento>> SVMovimientoObtener(long plngIdMovimiento, CancellationToken pCancellationToken);
        Task<DToResponse<List<DToMovimiento>>> SVMovimientoListarxCuenta(long plngIdCuenta, CancellationToken pCancellationToken);
        Task<DToResponse<List<DToMovimiento>>> SVMovimientoListarxCuentaFecha(long plngIdCuenta, string pstrFechaInicio, string pstrFechaFin, CancellationToken pCancellationToken);
        Task<DToResponse<bool>> SVMovimientoEliminar(long plngIdMovimiento, CancellationToken pCancellationToken);
    }
}
