using System.Net;

namespace WebAPI.DevsuTest.Commons.Exceptions
{
    public class CustomException : Exception
    {
        public string? strMensajeError { get; }

        public HttpStatusCode hscCodidoEstado { get; }

        public string strHeaderResponse { get; }

        public CustomException(string pstrMensaje, string pstrHeaderResponse = "", string? error = "", HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(pstrMensaje)
        {
            strHeaderResponse = pstrHeaderResponse;
            strMensajeError = error;
            hscCodidoEstado = statusCode;
        }
    }
}
