using Microsoft.AspNetCore.JsonPatch;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.DTOs.Persona;

namespace WebAPI.DevsuTest.Interfaces.Services
{
    public interface IPersonaService
    {
        Task<DToResponse<int>> SVPersonaInsertar(DToPersona pobjDtoPersona, CancellationToken pCancellationToken);
        Task<DToResponse<DToPersona>> SVPersonaObtener(string pstrIdentificacion, CancellationToken pCancellationToken);
        Task<DToResponse<List<DToPersona>>> SVPersonaListar(CancellationToken pCancellationToken);
        Task<DToResponse<bool>> SVPersonaDatosModificar(DToPersona pobjDtoPersona, CancellationToken pCancellationToken);
        Task<DToResponse<bool>> SVPersonaDatosModificarParcial(string pstrIdentificacion, JsonPatchDocument<DToPersona> pobjDtoPersona, CancellationToken pCancellationToken);
    }
}
