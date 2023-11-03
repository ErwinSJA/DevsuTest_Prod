using Microsoft.AspNetCore.Http;

namespace WebAPI.DevsuTest.Middlewares.TimeOut
{
    public class TimeoutMiddleware
    {
        private readonly RequestDelegate l_next;
        private readonly int _timeout;

        public TimeoutMiddleware(RequestDelegate next, int timeout)
        {
            l_next = next;
            _timeout = timeout;
        }

        public async Task InvokeAsync(HttpContext pContext)
        {
            using (var timeoutSource = CancellationTokenSource.CreateLinkedTokenSource(pContext.RequestAborted))
            {
                timeoutSource.CancelAfter(_timeout);
                pContext.RequestAborted = timeoutSource.Token;
                await l_next(pContext);
            }
        }
    }
}
