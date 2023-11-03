using Swashbuckle.AspNetCore.Annotations;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.DTOs.Comunes
{
    [SwaggerSchema(Required = new[] { "intIdCodigo", "blnEstadoRpta", "strMensajeRpta", "objDtoError", "objRespuesta" })]
    public class DToResponse<T>
    {
        // Exception

        public DToResponse(int pintIdCodigo, bool pblnEstadoRpta, string pstrMensajeRpta, DtoErrorServicio pobjDtoError)
        {
            intIdCodigo = pintIdCodigo;
            blnEstadoRpta = pblnEstadoRpta;
            strMensajeRpta = pstrMensajeRpta;
            objRespuesta = default;
            objDtoError = pobjDtoError;
        }

        // Error o Validación
        public DToResponse(int pintIdCodigo, bool pblnEstadoRpta, string pstrMensajeRpta, T pobjRespuesta = default!)
        {
            intIdCodigo = pintIdCodigo;
            blnEstadoRpta = pblnEstadoRpta;
            strMensajeRpta = pstrMensajeRpta;
            objRespuesta = pobjRespuesta;
            objDtoError = new DtoErrorServicio();
        }

        public DToResponse()
        {
            intIdCodigo = 0;
            blnEstadoRpta = false;
            strMensajeRpta = string.Empty;
            objRespuesta = default;
            objDtoError = new DtoErrorServicio();
        }

        [SwaggerSchema(Title = "Código de respuesta", Description = "Código de respuesta (Validacion / Error)", Format = "int")]
        [SwaggerSchemaExample("400")]
        public int intIdCodigo { get; set; }

        [SwaggerSchema(Title = "Estado de respuesta", Description = "Estado de respuesta (true: correcto / false: incorrecto)", Format = "bool")]
        [SwaggerSchemaExample("true")]
        public bool blnEstadoRpta { get; set; }

        [SwaggerSchema(Title = "Mensaje de respuesta", Description = "Mensaje de respuesta del API", Format = "string")]
        [SwaggerSchemaExample("")]
        public string strMensajeRpta { get; set; }

        [SwaggerSchema(Title = "Objeto de Respuesta", Description = "Objeto de respuesta, depende de tipo de DTO a obtener", Format = "Generic")]
        [SwaggerSchemaExample("")]
        public T? objRespuesta { get; set; }

        [SwaggerSchema(Title = "Objeto de Exception", Description = "Contiene información de la Exceptión generada", Format = "DtoErrorServicio")]
        public DtoErrorServicio objDtoError { get; set; }
    }
}
