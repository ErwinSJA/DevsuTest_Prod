using System.Net;

namespace WebAPI.DevsuTest.Commons.Exceptions
{
    public class ExceptionNotFound : CustomException
    {
        public ExceptionNotFound(string message, string pstrHeaderResponse = "")
            : base(message, pstrHeaderResponse, null, HttpStatusCode.NotFound)
        {
        }
    }
}
