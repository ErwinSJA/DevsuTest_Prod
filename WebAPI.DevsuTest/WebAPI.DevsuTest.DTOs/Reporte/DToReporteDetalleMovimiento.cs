using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.DTOs.Reporte
{
    public class DToReporteDetalleMovimiento
    {
        [SwaggerSchema(Title = "Id de Movimiento", Description = "Identificador del Movimiento.", Format = "long", ReadOnly = true)]
        [SwaggerSchemaExample("0")]
        public long lngIdMovimiento { set; get; } = 0L;

        [SwaggerSchema(Title = "Fecha de Operacion", Description = "Formato dd/MM/yyyy HH:mm:ss.", Format = "string", ReadOnly = true)]
        [SwaggerSchemaExample("02/11/2023 15:18:40")]
        public string strFecha { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Tipo Movimiento", Description = "Descripción del tipo de Movimiento.", Format = "string", ReadOnly = true)]
        [SwaggerSchemaExample("")]
        public string strTipoMovimiento { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Saldo Inicial", Description = "Saldo de la cuenta anterior a realizar el Movimiento.", Format = "decimal", ReadOnly = true)]
        [SwaggerSchemaExample("4500.00")]
        public decimal decSaldoInicial { set; get; } = 0M;

        [SwaggerSchema(Title = "Importe Operacion", Description = "Importe del Movimiento.", Format = "decimal", ReadOnly = true)]
        [SwaggerSchemaExample("300.00")]
        public decimal decImporte { set; get; } = 0M;

        [SwaggerSchema(Title = "Saldo Final", Description = "Saldo de la cuenta posterior a realizar el Movimiento.", Format = "decimal", ReadOnly = true)]
        [SwaggerSchemaExample("4800.00")]
        public decimal decSaldoMovimiento { set; get; } = 0M;

        [SwaggerSchema(Title = "Estado", Description = "Estado del Movimiento.", Format = "bool", ReadOnly = true)]
        [SwaggerSchemaExample("true")]
        public bool blnEstado { set; get; } = true;
    }
}
