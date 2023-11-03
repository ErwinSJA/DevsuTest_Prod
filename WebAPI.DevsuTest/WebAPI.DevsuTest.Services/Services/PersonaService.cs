using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.Models.Persona;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.DTOs.Persona;
using WebAPI.DevsuTest.Interfaces.Repositories;
using WebAPI.DevsuTest.Interfaces.Services;
using WebAPI.DevsuTest.Services.Class;

namespace WebAPI.DevsuTest.Services.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly ICapaActualService l_CapaActualService;
        private readonly IPersonaRepository l_PersonaRepository;
        private readonly IMapper l_Mapper;

        public PersonaService(ICapaActualService pCapaActualDatosService, IPersonaRepository pPersonaRepository, IMapper pMapper)
        {
            l_CapaActualService = pCapaActualDatosService;
            l_PersonaRepository = pPersonaRepository;
            l_Mapper = pMapper;
            l_CapaActualService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaServicio);
        }

        public async Task<DToResponse<int>> SVPersonaInsertar(DToPersona pobjDtoPersona, CancellationToken pCancellationToken)
        {
            int intResult = await l_PersonaRepository.DPersonaInsertar(l_Mapper.Map<ModelPersona>(pobjDtoPersona));
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<int>(intResult);
        }

        public async Task<DToResponse<DToPersona>> SVPersonaObtener(string pstrIdentificacion, CancellationToken pCancellationToken)
        {
            var objDTo = l_Mapper.Map<DToPersona>(await l_PersonaRepository.DPersonaObtener(pstrIdentificacion));
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<DToPersona>(objDTo);
        }

        public async Task<DToResponse<List<DToPersona>>> SVPersonaListar(CancellationToken pCancellationToken)
        {
            var lstDTo = l_Mapper.Map<List<DToPersona>>(await l_PersonaRepository.DPersonaListar());
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<List<DToPersona>>(lstDTo);
        }

        public async Task<DToResponse<bool>> SVPersonaDatosModificar(DToPersona pobjDtoPersona, CancellationToken pCancellationToken)
        {
            bool blnResult = await l_PersonaRepository.DPersonaDatosModificar(l_Mapper.Map<ModelPersona>(pobjDtoPersona));
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<bool>(blnResult);
        }

        public async Task<DToResponse<bool>> SVPersonaDatosModificarParcial(string pstrIdentificacion, JsonPatchDocument<DToPersona> pobjDtoPersona, CancellationToken pCancellationToken)
        {
            var objDToExistente = l_Mapper.Map<DToPersona>(await l_PersonaRepository.DPersonaObtener(pstrIdentificacion));
            pobjDtoPersona.ApplyTo(objDToExistente);
            bool blnResult = await l_PersonaRepository.DPersonaDatosModificar(l_Mapper.Map<ModelPersona>(objDToExistente));
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<bool>(blnResult);
        }
    }
}
