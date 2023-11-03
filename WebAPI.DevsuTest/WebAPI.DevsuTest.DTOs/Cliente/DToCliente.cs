using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.DTOs.Persona;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.DTOs.Cliente
{
    public class DToCliente : DToPersona
    {
        [SwaggerSchema(Title = "Id de Cliente", Description = "Identificador único de Cliente.", Format = "int", ReadOnly = true)]
        [SwaggerSchemaExample("102")]
        public int intIdCliente { set; get; } = 0;

        [SwaggerSchema(Title = "Estado", Description = "Estado del Cliente.", Format = "bool", ReadOnly = true)]
        [SwaggerSchemaExample("true")]
        public bool blnEstado { set; get; } = true;
    }
}
