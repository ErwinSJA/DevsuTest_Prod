using Dapper;
using System.Data;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.Commons.DapperHelper;
using WebAPI.DevsuTest.Commons.SPCatalog;
using WebAPI.DevsuTest.Models.Cuenta;
using WebAPI.DevsuTest.Interfaces.Repositories;
using static WebAPI.DevsuTest.Util.Class.clsConstantes;

namespace WebAPI.DevsuTest.Repositories.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly IDapperHelper l_Helper;
        private readonly ICapaActualService l_CapaActualDatosService;

        public CuentaRepository(IDapperHelper pHelper, ICapaActualService pCapaActualDatosService)
        {
            l_Helper = pHelper;
            l_CapaActualDatosService = pCapaActualDatosService;
            l_CapaActualDatosService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaRepositorio);
        }

        public async Task<long> DCuentaInsertar(ModelCuenta pobjModelCuenta)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@peintIdCliente", pobjModelCuenta.intIdCliente, DbType.Int32, ParameterDirection.Input);
            dpParametros.Add("@petinTipoCuenta", pobjModelCuenta.bytTipoCuenta, DbType.Byte, ParameterDirection.Input);
            dpParametros.Add("@pemonSaldo", pobjModelCuenta.decSaldo, DbType.Decimal, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBTransact;
            return await l_Helper.ExecuteSP_Single<long>(clsUspCuenta.CuentaInsertar, dpParametros);
        }

        public async Task<ModelCuenta> DCuentaObtener(long plngIdCuenta)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@pebigIdCuenta", plngIdCuenta, DbType.Int64, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBTransact;
            return await l_Helper.ExecuteSP_Single<ModelCuenta>(clsUspCuenta.CuentaObtener, dpParametros, true);
        }

        public async Task<List<ModelCuenta>> DCuentaListar(int pintIdCliente)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@peintIdCliente", pintIdCliente, DbType.Int32, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBTransact;
            return await l_Helper.ExecuteSP_Multiple<ModelCuenta>(clsUspCuenta.CuentaListar, dpParametros, true);
        }

        public async Task<bool> DCuentaEliminar(long plngIdCuenta)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@pebigIdCuenta", plngIdCuenta, DbType.Int64, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBTransact;
            await l_Helper.ExecuteSPonly(clsUspCuenta.CuentaEliminar, dpParametros);

            return true;
        }
    }
}