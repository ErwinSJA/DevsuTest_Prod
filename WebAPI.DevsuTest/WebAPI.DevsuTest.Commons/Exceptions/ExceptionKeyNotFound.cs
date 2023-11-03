using System.Net;

namespace WebAPI.DevsuTest.Commons.Exceptions
{
    public class ExceptionKeyNotFound : CustomException
    {
        public ExceptionKeyNotFound(string message, string pstrHeaderResponse = "") 
            : base(message, pstrHeaderResponse, null, HttpStatusCode.Unauthorized) { }
    }
}
