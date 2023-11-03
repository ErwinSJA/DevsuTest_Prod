using AutoMapper;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.DTOs.Reporte;
using WebAPI.DevsuTest.Interfaces.Repositories;
using WebAPI.DevsuTest.Interfaces.Services;
using WebAPI.DevsuTest.Services.Class;
using WebAPI.DevsuTest.DTOs.Movimiento;

namespace WebAPI.DevsuTest.Services.Services
{
    public class ReporteService : IReporteService
    {
        private readonly ICapaActualService l_CapaActualService;
        private readonly IClienteRepository l_ClienteRepository;
        private readonly ICuentaRepository l_CuentaRepository;
        private readonly IMovimientoRepository l_MovimientoRepository;

        public ReporteService(ICapaActualService pCapaActualDatosService, IClienteRepository pClienteRepository, ICuentaRepository pCuentaRepository, 
                              IMovimientoRepository pMovimientoRepository, IMapper pMapper)
        {
            l_CapaActualService = pCapaActualDatosService;
            l_ClienteRepository = pClienteRepository;
            l_CuentaRepository = pCuentaRepository;
            l_MovimientoRepository = pMovimientoRepository;
            l_CapaActualService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaServicio);
        }

        public async Task<DToResponse<DToReporteCabecera>> SVReporteEstadoCuenta(int pintIdCliente, string pstrFechaInicio, string pstrFechaFin, CancellationToken pCancellationToken)
        {
            DToReporteCabecera objDToRptCabecera = new DToReporteCabecera();
            DToReporteDetalleCuenta objDToRptCuenta;
            DToReporteDetalleMovimiento objDToRptMovimiento;

            var lstModeloCuentas = await l_CuentaRepository.DCuentaListar(pintIdCliente);

            if (lstModeloCuentas.Count == 0)
            {
                return await new clsRespuesta(l_CapaActualService, pCancellationToken)
                    .fDtoGenerarRptaValidacion<DToReporteCabecera>(-1, false, "El cliente no tiene cuentas.");
            }            

            foreach(var objModeloCuenta in lstModeloCuentas)
            {
                objDToRptCuenta = new DToReporteDetalleCuenta();

                var lstModeloMovimientos = await l_MovimientoRepository.DMovimientoListarxCuentaFecha(objModeloCuenta.lngIdCuenta, pstrFechaInicio, pstrFechaFin);

                if (lstModeloMovimientos.Count > 0)
                {

                    foreach (var objModeloMovimiento in lstModeloMovimientos)
                    {
                        objDToRptMovimiento = new DToReporteDetalleMovimiento();
                        objDToRptMovimiento.lngIdMovimiento = objModeloMovimiento.lngIdMovimiento;
                        objDToRptMovimiento.strFecha = objModeloMovimiento.strFecha;
                        objDToRptMovimiento.strTipoMovimiento = objModeloMovimiento.strTipoMovimiento;
                        objDToRptMovimiento.decSaldoInicial = objModeloMovimiento.decSaldoInicial;
                        objDToRptMovimiento.decImporte = objModeloMovimiento.decValor;
                        objDToRptMovimiento.decSaldoMovimiento = objModeloMovimiento.decSaldoMovimiento;
                        objDToRptMovimiento.blnEstado = objModeloMovimiento.blnEstado;

                        objDToRptCuenta.lstDToMovimientos.Add(objDToRptMovimiento);
                    };

                    objDToRptCuenta.lngIdCuenta = objModeloCuenta.lngIdCuenta;
                    objDToRptCuenta.strTipoCuenta = objModeloCuenta.strTipoCuenta;
                    objDToRptCuenta.decSaldo = objModeloCuenta.decSaldo;
                    objDToRptCuenta.blnEstado = objModeloCuenta.blnEstado;

                    objDToRptCabecera.lstDToCuentas.Add(objDToRptCuenta);
                }
            }

            if (objDToRptCabecera.lstDToCuentas.Count == 0)
            {
                return await new clsRespuesta(l_CapaActualService, pCancellationToken)
                    .fDtoGenerarRptaValidacion<DToReporteCabecera>(-1, false, "El cliente no tiene movimientos en sus cuentas para el rango de fechas.");
            }

            var objModeloCliente = await l_ClienteRepository.DClienteObtener(pintIdCliente);

            objDToRptCabecera.strIdentificacion = objModeloCliente.strIdentificacion;
            objDToRptCabecera.strNombre = objModeloCliente.strNombre;

            return await new clsRespuesta(l_CapaActualService, pCancellationToken).fDtoGenerarRptaOK<DToReporteCabecera>(objDToRptCabecera);
        }

    }
}
