using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.DTOs.Cliente
{
    public class DToClienteUpdate
    {
        [SwaggerSchema(Title = "Id Cliente", Description = "Identificador de Cliente", Format = "int")]
        [SwaggerSchemaExample("102")]
        public int intIdCliente { set; get; } = 0;

        [SwaggerSchema(Title = "Contraseña", Description = "Contraseña para el cliente", Format = "string")]
        [SwaggerSchemaExample("")]
        public string strClave { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Estado", Description = "Estado del Cliente", Format = "bool")]
        [SwaggerSchemaExample("true")]
        public bool blnEstado { set; get; } = true;
    }
}
