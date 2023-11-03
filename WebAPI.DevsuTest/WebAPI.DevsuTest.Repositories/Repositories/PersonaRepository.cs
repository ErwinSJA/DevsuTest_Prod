using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.Commons.DapperHelper;
using WebAPI.DevsuTest.Commons.SPCatalog;
using WebAPI.DevsuTest.Models.Persona;
using WebAPI.DevsuTest.Interfaces.Repositories;
using static WebAPI.DevsuTest.Util.Class.clsConstantes;

namespace WebAPI.DevsuTest.Repositories.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly IDapperHelper l_Helper;
        private readonly ICapaActualService l_CapaActualDatosService;

        public PersonaRepository(IDapperHelper pHelper, ICapaActualService pCapaActualDatosService)
        {
            l_Helper = pHelper;
            l_CapaActualDatosService = pCapaActualDatosService;
            l_CapaActualDatosService.pCapaActualAsignar((byte)clsEnums.ENCapaOrigenLogError.CapaRepositorio);
        }

        public async Task<int> DPersonaInsertar(ModelPersona pModelPersona)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@pevchNombre", pModelPersona.strNombre, DbType.String, ParameterDirection.Input);
            dpParametros.Add("@petinGenero", pModelPersona.bytGenero, DbType.Byte, ParameterDirection.Input);
            dpParametros.Add("@peintEdad", pModelPersona.intEdad, DbType.Int32, ParameterDirection.Input);
            dpParametros.Add("@pevchIdentificacion", pModelPersona.strIdentificacion, DbType.String, ParameterDirection.Input);
            dpParametros.Add("@pevchDireccion", pModelPersona.strDireccion, DbType.String, ParameterDirection.Input);
            dpParametros.Add("@pevchTelefono", pModelPersona.strTelefono, DbType.String, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBPersona;
            return await l_Helper.ExecuteSP_Single<int> (clsUspPersona.PersonaInsertar, dpParametros);
        }

        public async Task<ModelPersona> DPersonaObtener(string pstrIdentificacion)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@pevchIdentificacion", pstrIdentificacion, DbType.String, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBPersona;
            return await l_Helper.ExecuteSP_Single<ModelPersona>(clsUspPersona.PersonaObtener, dpParametros, true);
        }

        public async Task<List<ModelPersona>> DPersonaListar()
        {
            l_Helper.l_strBD = STDB.G_STRDBPersona;
            return await l_Helper.ExecuteSP_Multiple<ModelPersona>(clsUspPersona.PersonaListar, new { }, true);
        }

        public async Task<bool> DPersonaDatosModificar(ModelPersona pModelPersona)
        {
            DynamicParameters dpParametros = new();
            dpParametros.Add("@pevchIdentificacion", pModelPersona.strIdentificacion, DbType.String, ParameterDirection.Input);
            dpParametros.Add("@pevchNombre", pModelPersona.strNombre, DbType.String, ParameterDirection.Input);
            dpParametros.Add("@petinGenero", pModelPersona.bytGenero, DbType.Byte, ParameterDirection.Input);
            dpParametros.Add("@peintEdad", pModelPersona.intEdad, DbType.Int32, ParameterDirection.Input);
            dpParametros.Add("@pevchDireccion", pModelPersona.strDireccion, DbType.String, ParameterDirection.Input);
            dpParametros.Add("@pevchTelefono", pModelPersona.strTelefono, DbType.String, ParameterDirection.Input);

            l_Helper.l_strBD = STDB.G_STRDBPersona;
            await l_Helper.ExecuteSPonly(clsUspPersona.PersonaDatosModificar, dpParametros);

            return true;
        }
    }
}