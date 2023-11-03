using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DevsuTest.Models.Cuenta
{
    public class ModelCuenta
    {
        [Column("bigIdCuenta")] public long lngIdCuenta { set; get; } = 0L;
        [Column("intIdCliente")] public int intIdCliente { set; get; } = 0;
        [Column("tinTipoCuenta")] public byte bytTipoCuenta { set; get; } = 0;
        [Column("vchTipoCuenta")] public string strTipoCuenta { set; get; } = string.Empty;
        [Column("monSaldo")] public decimal decSaldo { set; get; } = 0M;
        [Column("strFechaMod")] public string strFechaMod { set; get; } = string.Empty;
        [Column("bitEstado")] public bool blnEstado { set; get; } = true;
    }
}
