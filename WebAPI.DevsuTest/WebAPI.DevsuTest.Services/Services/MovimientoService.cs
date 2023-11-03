using AutoMapper;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.Models.Movimiento;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.DTOs.Movimiento;
using WebAPI.DevsuTest.Interfaces.Repositories;
using WebAPI.DevsuTest.Interfaces.Services;
using WebAPI.DevsuTest.Services.Class;

namespace WebAPI.DevsuTest.Services.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly ICapaActualService l_CapaActualService;
        private readonly IMovimientoRepository l_MovimientoRepository;
        private readonly ICuentaRepository l_CuentaRepository;
        private readonly IMapper l_Mapper;

        public MovimientoService(ICapaActualService pCapaActualDatosService, IMovimientoRepository pMovimientoRepository, ICuentaRepository pCuentaRepository, IMapper pMapper)
        {
            l_CapaActualService = pCapaActualDatosService;
            l_MovimientoRepository = pMovimientoRepository;
            l_CuentaRepository = pCuentaRepository;
            l_Mapper = pMapper;
            l_CapaActualService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaServicio);
        }

        public async Task<DToResponse<long>> SVMovimientoInsertar(DToMovimiento pobjDToMovimiento, CancellationToken pCancellationToken)
        {
            var objModelCuenta = await l_CuentaRepository.DCuentaObtener(pobjDToMovimiento.lngIdCuenta);

            if (objModelCuenta.decSaldo != pobjDToMovimiento.decSaldoInicial)
            {
                return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaValidacion<long>(-1, false, "El saldo ingresado es diferente al que posee la cuenta");
            }
            else if (objModelCuenta.decSaldo + pobjDToMovimiento.decValor < 0M)
            {
                return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaValidacion<long>(-99, false, "Saldo no disponible");
            }
            long lngResult = await l_MovimientoRepository.DMovimientoInsertar(l_Mapper.Map<ModelMovimiento>(pobjDToMovimiento));
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<long>(lngResult);
        }

        public async Task<DToResponse<DToMovimiento>> SVMovimientoObtener(long plngIdMovimiento, CancellationToken pCancellationToken)
        {
            var objDTo = l_Mapper.Map<DToMovimiento>(await l_MovimientoRepository.DMovimientoObtener(plngIdMovimiento));
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<DToMovimiento>(objDTo);
        }

        public async Task<DToResponse<List<DToMovimiento>>> SVMovimientoListarxCuenta(long plngIdCuenta, CancellationToken pCancellationToken)
        {
            var lstDTo = l_Mapper.Map<List<DToMovimiento>>(await l_MovimientoRepository.DMovimientoListarxCuenta(plngIdCuenta));
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<List<DToMovimiento>>(lstDTo);
        }

        public async Task<DToResponse<List<DToMovimiento>>> SVMovimientoListarxCuentaFecha(long plngIdCuenta, string pstrFechaInicio, string pstrFechaFin, CancellationToken pCancellationToken)
        {
            var lstDTo = l_Mapper.Map<List<DToMovimiento>>(await l_MovimientoRepository.DMovimientoListarxCuentaFecha(plngIdCuenta, pstrFechaInicio, pstrFechaFin));

            if (lstDTo is null || lstDTo.Count == 0)
            {
                return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaValidacion<List<DToMovimiento>>(-1, false, "No se registran movimientos para la cuenta dentro del rango de fechas.");
            }
            
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<List<DToMovimiento>>(lstDTo);
        }

        public async Task<DToResponse<bool>> SVMovimientoEliminar(long plngIdMovimiento, CancellationToken pCancellationToken)
        {
            bool blnResult = await l_MovimientoRepository.DMovimientoEliminar(plngIdMovimiento);
            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<bool>(blnResult);
        }
    }
}
