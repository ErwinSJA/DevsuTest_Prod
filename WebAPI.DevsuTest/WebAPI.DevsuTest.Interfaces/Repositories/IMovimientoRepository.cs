using WebAPI.DevsuTest.Models.Movimiento;

namespace WebAPI.DevsuTest.Interfaces.Repositories
{
    public interface IMovimientoRepository
    {
        Task<long> DMovimientoInsertar(ModelMovimiento pobjModelMovimiento);
        Task<ModelMovimiento> DMovimientoObtener(long plngIdMovimiento);
        Task<List<ModelMovimiento>> DMovimientoListarxCuenta(long plngIdCuenta);
        Task<List<ModelMovimiento>> DMovimientoListarxCuentaFecha(long plngIdCuenta, string pstrFechaInicio, string pstrFechaFin);
        Task<bool> DMovimientoEliminar(long plngIdMovimiento);
    }
}
