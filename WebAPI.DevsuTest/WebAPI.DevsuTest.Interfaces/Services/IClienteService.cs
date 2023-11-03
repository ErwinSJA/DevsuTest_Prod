using WebAPI.DevsuTest.DTOs.Cliente;
using WebAPI.DevsuTest.DTOs.Comunes;

namespace WebAPI.DevsuTest.Interfaces.Services
{
    public interface IClienteService
    {
        Task<DToResponse<int>> SVClienteInsertar(DToClienteCreate pobjDToCliente, CancellationToken pCancellationToken);
        Task<DToResponse<DToCliente>> SVClienteObtener(int pintIdCliente, CancellationToken pCancellationToken);
        Task<DToResponse<List<DToCliente>>> SVClienteListar(CancellationToken pCancellationToken);
        Task<DToResponse<bool>> SVClientePasswordModificar(DToClienteUpdate pobjDToCliente, CancellationToken pCancellationToken);
        Task<DToResponse<bool>> SVClienteEstadoModificar(DToClienteUpdate pobjDToCliente, CancellationToken pCancellationToken);
    }
}
