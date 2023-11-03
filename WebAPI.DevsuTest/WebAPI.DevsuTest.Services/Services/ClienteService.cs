using AutoMapper;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.Models.Cliente;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.DTOs.Cliente;
using WebAPI.DevsuTest.Interfaces.Repositories;
using WebAPI.DevsuTest.Interfaces.Services;
using WebAPI.DevsuTest.Services.Class;

namespace WebAPI.DevsuTest.Services.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ICapaActualService l_CapaActualService;
        private readonly IClienteRepository l_ClienteRepository;
        private readonly IPersonaRepository l_PersonaRepository;
        private readonly IMapper l_Mapper;

        public ClienteService(ICapaActualService pCapaActualDatosService, IClienteRepository pClienteRepository, IPersonaRepository pPersonaRepository, IMapper pMapper)
        {
            l_CapaActualService = pCapaActualDatosService;
            l_ClienteRepository = pClienteRepository;
            l_PersonaRepository = pPersonaRepository;
            l_Mapper = pMapper;
            l_CapaActualService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaServicio);
        }

        public async Task<DToResponse<int>> SVClienteInsertar(DToClienteCreate pobjDToCliente, CancellationToken pCancellationToken)
        {
            ModelCliente objModelCliente = new ModelCliente();
            var objModelPersona = await l_PersonaRepository.DPersonaObtener(pobjDToCliente.strIdentificacion);

            string strPasswordSalt;
            objModelCliente.strPasswordHash = clsEncrypt.fstrGenerarPasswordHashSHA512(pobjDToCliente.strClave, out strPasswordSalt);
            objModelCliente.strPasswordSalt = strPasswordSalt;
            int intResult = await l_ClienteRepository.DClienteInsertar(objModelPersona.intIdPersona, objModelCliente);
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<int>(intResult);
        }

        public async Task<DToResponse<DToCliente>> SVClienteObtener(int pintIdCliente, CancellationToken pCancellationToken)
        {
            var objDTo = l_Mapper.Map<DToCliente>(await l_ClienteRepository.DClienteObtener(pintIdCliente));
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<DToCliente>(objDTo);
        }

        public async Task<DToResponse<List<DToCliente>>> SVClienteListar(CancellationToken pCancellationToken)
        {
            var lstDTo = l_Mapper.Map<List<DToCliente>>(await l_ClienteRepository.DClienteListar());
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<List<DToCliente>>(lstDTo);
        }

        public async Task<DToResponse<bool>> SVClientePasswordModificar(DToClienteUpdate pobjDToCliente, CancellationToken pCancellationToken)
        {
            ModelCliente objModelCliente = new ModelCliente();
            string strPasswordSalt;

            objModelCliente.intIdCliente = pobjDToCliente.intIdCliente;
            objModelCliente.strPasswordHash = clsEncrypt.fstrGenerarPasswordHashSHA512(pobjDToCliente.strClave, out strPasswordSalt);
            objModelCliente.strPasswordSalt = strPasswordSalt;

            bool blnResult = await l_ClienteRepository.DClientePasswordModificar(objModelCliente);
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<bool>(blnResult);
        }

        public async Task<DToResponse<bool>> SVClienteEstadoModificar(DToClienteUpdate pobjDToCliente, CancellationToken pCancellationToken)
        {
            bool blnResult = await l_ClienteRepository.DClienteEstadoModificar(pobjDToCliente.intIdCliente, pobjDToCliente.blnEstado);
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<bool>(blnResult);
        }
    }
}
