using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.DTOs.Comunes
{
    public class DtoErrorServicio
    {
        public DtoErrorServicio()
        {
            intStatusCode = 0;
            strFuente = string.Empty;
            strExcepcion = string.Empty;
            strDetalle = string.Empty;
            bytCapaOrigen = (byte)clsEnums.ENCapaOrigenLogError.NoAsignada;
        }

        [SwaggerSchema(Title = "Codigo de respuesta", Description = "Código de respuesta del API (StatusCode)", Format = "int")]
        [SwaggerSchemaExample("0")]
        public int intStatusCode { get; set; }

        [SwaggerSchema(Title = "Capa Error", Description = "Identificador de la Capa donde se originó el error", Format = "byte")]
        [SwaggerSchemaExample("0")]
        public byte bytCapaOrigen { get; set; }

        [SwaggerSchema(Title = "Excepción", Description = "Mensaje de Excepción principal", Format = "string")]
        [SwaggerSchemaExample("")]
        public string strExcepcion { get; set; }

        [SwaggerSchema(Title = "Fuente", Description = "Fuente donde ocurrio el error", Format = "string")]
        [SwaggerSchemaExample("")]
        public string strFuente { get; set; }

        [SwaggerSchema(Title = "Detalle", Description = "Detalle de la excepción (StackTrace)", Format = "string")]
        [SwaggerSchemaExample("")]
        public string strDetalle { get; set; }        
    }
}
