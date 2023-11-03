using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.DTOs.Cuenta;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.DTOs.Reporte
{
    public class DToReporteCabecera
    {
        [SwaggerSchema(Title = "Nro Identificacion", Description = "Número de Identificacion (Documento Identidad) de la Persona.", Format = "string", ReadOnly = true)]
        [SwaggerSchemaExample("74581952")]
        public string strIdentificacion { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Nombre Persona", Description = "Nombre y Apellidos de la Persona.", Format = "string")]
        [SwaggerSchemaExample("")]
        public string strNombre { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Lista de Cuentas", Description = "Lista de Cuentas del Cliente.", Format = "List<DToCuenta>", ReadOnly = true)]
        [SwaggerSchemaExample("")]
        public List<DToReporteDetalleCuenta> lstDToCuentas { get; set; } = new List<DToReporteDetalleCuenta>();
    }
}
