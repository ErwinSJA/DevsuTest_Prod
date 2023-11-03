using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.DTOs.Cuenta
{
    public class DToCuenta
    {
        [SwaggerSchema(Title = "Id de Cuenta", Description = "Identificador de la Cuenta.", Format = "long", ReadOnly = true)]
        [SwaggerSchemaExample("100001")]
        public long lngIdCuenta { set; get; } = 0L;

        [SwaggerSchema(Title = "Id de Cliente", Description = "Identificador único de Cliente.", Format = "int")]
        [SwaggerSchemaExample("102")]
        public int intIdCliente { set; get; } = 0;

        [SwaggerSchema(Title = "Id Tipo Cuenta", Description = "1: Ahorros | 2: Corriente", Format = "byte")]
        [SwaggerSchemaExample("1")]
        public byte bytTipoCuenta { set; get; } = 0;

        [SwaggerSchema(Title = "Tipo Cuenta", Description = "Descripción del tipo de Cuenta.", Format = "string", ReadOnly = true)]
        [SwaggerSchemaExample("")]
        public string strTipoCuenta { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Saldo Inicial", Description = "Saldo inicial de la Cuenta.", Format = "decimal")]
        [SwaggerSchemaExample("800.00")]
        public decimal decSaldo { set; get; } = 0M;

        [SwaggerSchema(Title = "Fecha Modificacion", Description = "Fecha de la última modificación en la Cuenta. Formato: dd/MM/yyyy HH:mm:ss", Format = "DateTime", ReadOnly = true)]
        [SwaggerSchemaExample("02/11/2023 15:45:10")]
        public string strFechaMod { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Estado", Description = "Estado de la Cuenta.", Format = "bool", ReadOnly = true)]
        [SwaggerSchemaExample("true")]
        public bool blnEstado { set; get; } = true;
    }
}
