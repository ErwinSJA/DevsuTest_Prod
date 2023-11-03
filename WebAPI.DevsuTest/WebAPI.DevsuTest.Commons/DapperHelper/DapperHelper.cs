using Dapper;
using System.Data;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebAPI.DevsuTest.Commons.DapperHelper
{
    public class DapperHelper : IDapperHelper
    {
        private readonly IConfiguration l_Configuration;
        public string l_strBD { get; set; } = string.Empty;

        public DapperHelper(IConfiguration pConfiguration)
        {
            l_Configuration = pConfiguration;
        }

        public async Task ExecuteSPonly(string spName, dynamic param = null!)
        {
            using IDbConnection objConnection = fsqlEstablecerConexion();
            await objConnection.ExecuteAsync(spName, param: (object)param, commandType: CommandType.StoredProcedure);
        }
        public async Task<T> ExecuteSP_Single<T>(string spName, dynamic param = null!, Boolean pblnUsaColumn = false)
        {
            if (pblnUsaColumn == true) { pMapeoPersonalizado<T>(); }
            using IDbConnection objConnection = fsqlEstablecerConexion();
            IEnumerable<T> temp = await objConnection.QueryAsync<T>(spName, param: (object)param, commandType: CommandType.StoredProcedure);
            return temp.FirstOrDefault()!;
        }
        public async Task<dynamic> ExecuteSP_Multiple<T>(string spName, dynamic param = null!, Boolean pblnUsaColumn = false) where T : class
        {
            if (pblnUsaColumn == true) { pMapeoPersonalizado<T>(); }
            using IDbConnection objConnection = fsqlEstablecerConexion();
            return await objConnection.QueryAsync<T>(spName, param: (object)param, commandType: CommandType.StoredProcedure);
        }

        private void pMapeoPersonalizado<T>()
        {
            // Configuración del mapeo personalizado
            SqlMapper.SetTypeMap(typeof(T), new CustomPropertyTypeMap(typeof(T), (type, columnName) =>
            {
                return type.GetProperties().FirstOrDefault(prop =>
                {
                    var attr = prop.GetCustomAttribute<ColumnAttribute>(true);
                    return attr != null && attr.Name == columnName;
                });
            }));
        }

        public IDbConnection fsqlEstablecerConexion()
        {
            {
                string strSQLServidor = string.Empty, strSQLLogin = string.Empty;

                strSQLServidor = l_Configuration.GetConnectionString("SQLServidor")!; // EN UN CASO REAL, ESTE VALOR VIENE CIFRADO
                strSQLLogin = l_Configuration.GetConnectionString("SQLLogin")!; // EN UN CASO REAL, ESTE VALOR VIENE CIFRADO

                IDbConnection objConeccion = new SqlConnection(strSQLLogin + l_strBD + strSQLServidor);
                return objConeccion;
            }
        }
    }
}
