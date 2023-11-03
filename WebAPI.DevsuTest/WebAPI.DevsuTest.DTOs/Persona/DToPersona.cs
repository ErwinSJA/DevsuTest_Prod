using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.DTOs.Persona
{
    [SwaggerSchema(Title = "DToPersona", Required = new[] { "strNombre", "bytGenero", "intEdad", "strIdentificacion", "strDireccion", "strTelefono" })]
    public class DToPersona
    {
        [SwaggerSchema(Title = "Id de Persona", Description = "Identificador único de Persona.", Format = "int", ReadOnly = true)]
        [SwaggerSchemaExample("0")]
        public int intIdPersona { set; get; } = 0;

        [SwaggerSchema(Title = "Nro Identificacion", Description = "Número de Identificacion (Documento Identidad) de la Persona.", Format = "string")]
        [SwaggerSchemaExample("74581952")]
        public string strIdentificacion { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Nombre Persona", Description = "Nombre y Apellidos de la Persona.", Format = "string")]
        [SwaggerSchemaExample("")]
        public string strNombre { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Id de Genero", Description = "1: Masculino | 2: Femenino | 3: Otro", Format = "byte")]
        [SwaggerSchemaExample("1")]
        public byte bytGenero { set; get; } = 0;

        [SwaggerSchema(Title = "Descripcion Genero", Description = "Nombre/Descripción del Genero de la Persona.", Format = "string", ReadOnly = true)]
        [SwaggerSchemaExample("")]
        public string strGenero { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Edad", Description = "Edad de la Persona.", Format = "int")]
        [SwaggerSchemaExample("25")]
        public int intEdad { set; get; } = 0;

        [SwaggerSchema(Title = "Direccion", Description = "Dirección de la Persona.", Format = "string")]
        [SwaggerSchemaExample("Calle Dressrosa 547")]
        public string strDireccion { set; get; } = string.Empty;

        [SwaggerSchema(Title = "Telefono", Description = "Número de Telefono de la Persona.", Format = "string")]
        [SwaggerSchemaExample("947815492")]
        public string strTelefono { set; get; } = string.Empty;
    }
}