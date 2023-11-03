using WebAPI.DevsuTest.Models.Persona;

namespace WebAPI.DevsuTest.Interfaces.Repositories
{
    public interface IPersonaRepository
    {
        Task<int> DPersonaInsertar(ModelPersona pModelPersona);

        Task<ModelPersona> DPersonaObtener(string pstrIdentificacion);

        Task<List<ModelPersona>> DPersonaListar();

        Task<bool> DPersonaDatosModificar(ModelPersona pModelPersona);
    }
}
