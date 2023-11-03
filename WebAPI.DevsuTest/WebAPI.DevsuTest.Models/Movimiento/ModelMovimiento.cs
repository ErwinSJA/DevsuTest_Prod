using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DevsuTest.Models.Movimiento
{
    public class ModelMovimiento
    {
        [Column("bigIdMovimiento")] public long lngIdMovimiento { set; get; } = 0L;
        [Column("bigIdCuenta")] public long lngIdCuenta { set; get; } = 0L;
        [Column("strFecha")] public string strFecha { set; get; } = string.Empty;
        [Column("tinTipoMovimiento")] public byte bytTipoMovimiento { set; get; } = 0;
        [Column("vchTipoMovimiento")] public string strTipoMovimiento { set; get; } = string.Empty;
        [Column("monSaldoInicial")] public decimal decSaldoInicial { set; get; } = 0M;
        [Column("monValor")] public decimal decValor { set; get; } = 0M;
        [Column("monSaldoMovimiento")] public decimal decSaldoMovimiento { set; get; } = 0M;
        [Column("bitEstado")] public bool blnEstado { set; get; } = true;
    }
}
