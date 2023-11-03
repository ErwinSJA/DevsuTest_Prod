using Dapper;
using System.Data;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.Commons.DapperHelper;
using WebAPI.DevsuTest.Commons.SPCatalog;
using WebAPI.DevsuTest.Models.Cliente;
using WebAPI.DevsuTest.Interfaces.Repositories;
using static WebAPI.DevsuTest.Util.Class.clsConstantes;

namespace WebAPI.DevsuTest.Repositories.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDapperHelper l_Helper;
        private readonly ICapaActualService l_CapaActualDatosService;

        public ClienteRepository(IDapperHelper pHelper, ICapaActualService pCapaActualDatosService)
        {
            l_Helper = pHelper;
            l_CapaActualDatosService = pCapaActualDatosService;
            l_CapaActualDatosService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaRepositorio);
        }

        public async Task<int> DClienteInsertar(int pintIdPersona, ModelCliente pModelCliente)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@peintIdPersona", pintIdPersona, DbType.Int32, ParameterDirection.Input);
            dpParametros.Add("@pevchPasswordSalt", pModelCliente.strPasswordSalt, DbType.String, ParameterDirection.Input);
            dpParametros.Add("@pevchPasswordHash", pModelCliente.strPasswordHash, DbType.String, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBPersona;
            return await l_Helper.ExecuteSP_Single<int>(clsUspCliente.ClienteInsertar, dpParametros);
        }

        public async Task<ModelCliente> DClienteObtener(int pintIdCliente)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@peintIdCliente", pintIdCliente, DbType.Int32, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBPersona;
            return await l_Helper.ExecuteSP_Single<ModelCliente> (clsUspCliente.ClienteObtener, dpParametros, true);
        }

        public async Task<List<ModelCliente>> DClienteListar()
        {
            l_Helper.l_strBD = STDB.G_STRDBPersona;
            return await l_Helper.ExecuteSP_Multiple<ModelCliente>(clsUspCliente.ClienteListar, new {}, true);
        }

        public async Task<bool> DClientePasswordModificar(ModelCliente pModelCliente)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@peintIdCliente", pModelCliente.intIdCliente, DbType.Int32, ParameterDirection.Input);
            dpParametros.Add("@pevchPasswordSalt", pModelCliente.strPasswordSalt, DbType.String, ParameterDirection.Input);
            dpParametros.Add("@pevchPasswordHash", pModelCliente.strPasswordHash, DbType.String, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBPersona;
            await l_Helper.ExecuteSPonly(clsUspCliente.ClientePasswordModificar, dpParametros);

            return true;
        }

        public async Task<bool> DClienteEstadoModificar(int pintIdCliente, bool pblnEstado)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@peintIdCliente", pintIdCliente, DbType.Int32, ParameterDirection.Input);
            dpParametros.Add("@pebitEstado", pblnEstado, DbType.Boolean, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBPersona;
            await l_Helper.ExecuteSPonly(clsUspCliente.ClienteEstadoModificar, dpParametros);

            return true;
        }

    }
}