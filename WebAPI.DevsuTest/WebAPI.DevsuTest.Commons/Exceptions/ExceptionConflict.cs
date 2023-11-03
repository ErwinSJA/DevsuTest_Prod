using System.Net;

namespace WebAPI.DevsuTest.Commons.Exceptions
{
    public class ExceptionConflict : CustomException
    {
        public ExceptionConflict(string message, string pstrHeaderResponse = "")
            : base(message, pstrHeaderResponse, null, HttpStatusCode.Conflict) { }
    }
}
