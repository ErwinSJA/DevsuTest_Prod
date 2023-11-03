using WebAPI.DevsuTest.DTOs.Cuenta;
using WebAPI.DevsuTest.DTOs.Comunes;

namespace WebAPI.DevsuTest.Interfaces.Services
{
    public interface ICuentaService
    {
        Task<DToResponse<long>> SVCuentaInsertar(DToCuenta pobjDToCuenta, CancellationToken pCancellationToken);
        Task<DToResponse<DToCuenta>> SVCuentaObtener(long plngIdCuenta, CancellationToken pCancellationToken);
        Task<DToResponse<List<DToCuenta>>> SVCuentaListar(int pintIdCliente, CancellationToken pCancellationToken);
        Task<DToResponse<bool>> SVCuentaEliminar(long plngIdCuenta, CancellationToken pCancellationToken);
    }
}
