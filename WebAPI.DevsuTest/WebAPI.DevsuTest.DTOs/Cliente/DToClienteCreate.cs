using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.DTOs.Cliente
{
    public class DToClienteCreate
    {
        [SwaggerSchema(Title = "Nro Identificacion Persona", Description = "Número de Identificacion (Documento Identidad) de Persona", Format = "string")]
        [SwaggerSchemaExample("102")]
        public string strIdentificacion { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Contraseña", Description = "Contraseña para el cliente", Format = "string")]
        [SwaggerSchemaExample("")]
        public string strClave { set; get; } = string.Empty;
    }
}
