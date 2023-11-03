using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.DTOs.Reporte
{
    public class DToReporteDetalleCuenta
    {
        [SwaggerSchema(Title = "Id de Cuenta", Description = "Identificador de la Cuenta.", Format = "long", ReadOnly = true)]
        [SwaggerSchemaExample("100001")]
        public long lngIdCuenta { set; get; } = 0L;

        [SwaggerSchema(Title = "Tipo Cuenta", Description = "Descripción del tipo de Cuenta.", Format = "string", ReadOnly = true)]
        [SwaggerSchemaExample("")]
        public string strTipoCuenta { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Saldo Actual", Description = "Saldo de la Cuenta.", Format = "decimal", ReadOnly = true)]
        [SwaggerSchemaExample("800.00")]
        public decimal decSaldo { set; get; } = 0M;

        [SwaggerSchema(Title = "Estado", Description = "Estado de la Cuenta.", Format = "bool", ReadOnly = true)]
        [SwaggerSchemaExample("true")]
        public bool blnEstado { set; get; } = true;

        [SwaggerSchema(Title = "Lista de Movimientos", Description = "Movimientos de la Cuenta.", Format = "List<DToReporteDetalleMovimiento>", ReadOnly = true)]
        [SwaggerSchemaExample("")]
        public List<DToReporteDetalleMovimiento> lstDToMovimientos { get; set; } = new List<DToReporteDetalleMovimiento>();

    }
}
