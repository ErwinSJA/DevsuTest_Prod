using Dapper;
using System.Data;
using System.Globalization;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.Commons.DapperHelper;
using WebAPI.DevsuTest.Commons.SPCatalog;
using WebAPI.DevsuTest.Models.Movimiento;
using WebAPI.DevsuTest.Interfaces.Repositories;
using static WebAPI.DevsuTest.Util.Class.clsConstantes;

namespace WebAPI.DevsuTest.Repositories.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly IDapperHelper l_Helper;
        private readonly ICapaActualService l_CapaActualDatosService;

        public MovimientoRepository(IDapperHelper pHelper, ICapaActualService pCapaActualDatosService)
        {
            l_Helper = pHelper;
            l_CapaActualDatosService = pCapaActualDatosService;
            l_CapaActualDatosService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaRepositorio);
        }

        public async Task<long> DMovimientoInsertar(ModelMovimiento pobjModelMovimiento)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@pebigIdCuenta", pobjModelMovimiento.lngIdCuenta, DbType.Int64, ParameterDirection.Input);
            dpParametros.Add("@pedtmFecha", DateTime.ParseExact(pobjModelMovimiento.strFecha, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture), DbType.DateTime, ParameterDirection.Input);
            dpParametros.Add("@petinTipoMovimiento", pobjModelMovimiento.bytTipoMovimiento, DbType.Byte, ParameterDirection.Input);
            dpParametros.Add("@pemonSaldoInicial", pobjModelMovimiento.decSaldoInicial, DbType.Decimal, ParameterDirection.Input);
            dpParametros.Add("@pemonValor", pobjModelMovimiento.decValor, DbType.Decimal, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBTransact;
            return await l_Helper.ExecuteSP_Single<long>(clsUspMovimiento.MovimientoInsertar, dpParametros);
        }

        public async Task<ModelMovimiento> DMovimientoObtener(long plngIdMovimiento)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@pebigIdMovimiento", plngIdMovimiento, DbType.Int64, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBTransact;
            return await l_Helper.ExecuteSP_Single<ModelMovimiento>(clsUspMovimiento.MovimientoObtener, dpParametros, true);
        }

        public async Task<List<ModelMovimiento>> DMovimientoListarxCuenta(long plngIdCuenta)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@pebigIdCuenta", plngIdCuenta, DbType.Int64, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBTransact;
            return await l_Helper.ExecuteSP_Multiple<ModelMovimiento>(clsUspMovimiento.MovimientoListarxCuenta, dpParametros, true);
        }

        public async Task<List<ModelMovimiento>> DMovimientoListarxCuentaFecha(long plngIdCuenta, string pstrFechaInicio, string pstrFechaFin)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@pebigIdCuenta", plngIdCuenta, DbType.Int64, ParameterDirection.Input);
            dpParametros.Add("@pedtmFechaInicio", DateTime.ParseExact(pstrFechaInicio,"dd-MM-yyyy", CultureInfo.InvariantCulture), DbType.Date, ParameterDirection.Input);
            dpParametros.Add("@pedtmFechaFin", DateTime.ParseExact(pstrFechaFin, "dd-MM-yyyy", CultureInfo.InvariantCulture), DbType.Date, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBTransact;
            return await l_Helper.ExecuteSP_Multiple<ModelMovimiento>(clsUspMovimiento.MovimientoListarxCuentaFecha, dpParametros, true);
        }

        public async Task<bool> DMovimientoEliminar(long plngIdMovimiento)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@pebigIdMovimiento", plngIdMovimiento, DbType.Int64, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBTransact;
            await l_Helper.ExecuteSPonly(clsUspMovimiento.MovimientoEliminar, dpParametros);

            return true;
        }
    }
}