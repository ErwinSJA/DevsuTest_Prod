using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.DTOs.Movimiento
{
    public class DToMovimiento
    {
        [SwaggerSchema(Title = "Id de Movimiento", Description = "Identificador del Movimiento.", Format = "long", ReadOnly = true)]
        [SwaggerSchemaExample("0")]
        public long lngIdMovimiento { set; get; } = 0L;

        [SwaggerSchema(Title = "Id de Cuenta", Description = "Identificador de la Cuenta.", Format = "long")]
        [SwaggerSchemaExample("100001")]
        public long lngIdCuenta { set; get; } = 0L;

        [SwaggerSchema(Title = "Fecha de Operacion", Description = "Fecha Formato dd/MM/yyyy HH:mm:ss.", Format = "string")]
        [SwaggerSchemaExample("02/11/2023 15:18:40")]
        public string strFecha { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Id Tipo Movimiento", Description = "1: Deposito | 2: Retiro", Format = "byte", ReadOnly = true)]
        [SwaggerSchemaExample("1")]
        public byte bytTipoMovimiento { set; get; } = 0;

        [SwaggerSchema(Title = "Tipo Movimiento", Description = "Descripción del tipo de Movimiento.", Format = "string", ReadOnly = true)]
        [SwaggerSchemaExample("")]
        public string strTipoMovimiento { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Saldo Inicial", Description = "Saldo de la cuenta anterior a realizar el Movimiento.", Format = "decimal")]
        [SwaggerSchemaExample("4500.00")]
        public decimal decSaldoInicial { set; get; } = 0M;

        [SwaggerSchema(Title = "Importe Operacion", Description = "Importe del Movimiento.", Format = "decimal")]
        [SwaggerSchemaExample("480.00")]
        public decimal decValor { set; get; } = 0M;

        [SwaggerSchema(Title = "Saldo Final", Description = "Saldo de la cuenta posterior a realizar el Movimiento.", Format = "decimal", ReadOnly = true)]
        [SwaggerSchemaExample("4500.00")]
        public decimal decSaldoMovimiento { set; get; } = 0M;

        [SwaggerSchema(Title = "Estado", Description = "Estado del Movimiento.", Format = "bool", ReadOnly = true)]
        [SwaggerSchemaExample("true")]
        public bool blnEstado { set; get; } = true;
    }
}
