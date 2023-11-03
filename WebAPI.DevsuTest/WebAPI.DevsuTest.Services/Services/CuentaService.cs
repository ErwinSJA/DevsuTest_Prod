using AutoMapper;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.Models.Cuenta;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.DTOs.Cuenta;
using WebAPI.DevsuTest.Interfaces.Repositories;
using WebAPI.DevsuTest.Interfaces.Services;
using WebAPI.DevsuTest.Services.Class;
using WebAPI.DevsuTest.DTOs.Movimiento;

namespace WebAPI.DevsuTest.Services.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly ICapaActualService l_CapaActualService;
        private readonly ICuentaRepository l_CuentaRepository;
        private readonly IMapper l_Mapper;

        public CuentaService(ICapaActualService pCapaActualDatosService, ICuentaRepository pCuentaRepository, IMapper pMapper)
        {
            l_CapaActualService = pCapaActualDatosService;
            l_CuentaRepository = pCuentaRepository;
            l_Mapper = pMapper;
            l_CapaActualService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaServicio);
        }

        public async Task<DToResponse<long>> SVCuentaInsertar(DToCuenta pobjDToCuenta, CancellationToken pCancellationToken)
        {
            long lngResult = await l_CuentaRepository.DCuentaInsertar(l_Mapper.Map<ModelCuenta>(pobjDToCuenta));
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<long>(lngResult);
        }

        public async Task<DToResponse<DToCuenta>> SVCuentaObtener(long plngIdCuenta, CancellationToken pCancellationToken)
        {
            var objDTo = l_Mapper.Map<DToCuenta>(await l_CuentaRepository.DCuentaObtener(plngIdCuenta));
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<DToCuenta>(objDTo);
        }

        public async Task<DToResponse<List<DToCuenta>>> SVCuentaListar(int pintIdCliente, CancellationToken pCancellationToken)
        {
            var lstDTo = l_Mapper.Map<List<DToCuenta>>(await l_CuentaRepository.DCuentaListar(pintIdCliente));
            if (lstDTo is null || lstDTo.Count == 0)
            {
                return await new clsRespuesta(l_CapaActualService, pCancellationToken)
                    .fDtoGenerarRptaValidacion<List<DToCuenta>>(-1, false, "El cliente no tiene cuentas o estan inactivas.");
            }
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<List<DToCuenta>>(lstDTo);
        }

        public async Task<DToResponse<bool>> SVCuentaEliminar(long plngIdCuenta, CancellationToken pCancellationToken)
        {
            bool blnResult = await l_CuentaRepository.DCuentaEliminar(plngIdCuenta);
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<bool>(blnResult);
        }
    }
}
