using WebAPI.DevsuTest.Models.Cliente;

namespace WebAPI.DevsuTest.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<int> DClienteInsertar(int pintIdPersona, ModelCliente pModelCliente);
        Task<ModelCliente> DClienteObtener(int pintIdCliente);
        Task<List<ModelCliente>> DClienteListar();
        Task<bool> DClientePasswordModificar(ModelCliente pModelCliente);
        Task<bool> DClienteEstadoModificar(int pintIdCliente, bool pblnEstado);
    }
}
