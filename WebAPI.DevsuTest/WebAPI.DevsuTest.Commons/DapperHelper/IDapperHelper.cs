using System.Data;

namespace WebAPI.DevsuTest.Commons.DapperHelper
{
    public interface IDapperHelper
    {
        string l_strBD { get; set; }

        Task ExecuteSPonly(string spName, dynamic param = null!);
        Task<T> ExecuteSP_Single<T>(string spName, dynamic param = null!, Boolean pblnUsaColumn = false);
        Task<dynamic> ExecuteSP_Multiple<T>(string storedProcedure, dynamic param = null!, Boolean pblnUsaColumn = false) where T : class;
        IDbConnection fsqlEstablecerConexion();
    }
}
