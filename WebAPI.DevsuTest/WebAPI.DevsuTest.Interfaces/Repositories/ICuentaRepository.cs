using WebAPI.DevsuTest.Models.Cuenta;

namespace WebAPI.DevsuTest.Interfaces.Repositories
{
    public interface ICuentaRepository
    {
        Task<long> DCuentaInsertar(ModelCuenta pobjModelCuenta);
        Task<ModelCuenta> DCuentaObtener(long plngIdCuenta);
        Task<List<ModelCuenta>> DCuentaListar(int pintIdCliente);
        Task<bool> DCuentaEliminar(long plngIdCuenta);
    }
}
