using System.Net;
using Serilog;
using Serilog.Context;
using AutoMapper;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.Commons.Exceptions;
using WebAPI.DevsuTest.DTOs.Comunes;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.Middlewares.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate l_next;
        private readonly ICapaActualService l_CapaActualDatosService;
        private readonly IMapper l_Mapper;
        private readonly IConfiguration l_Configuration;
        private byte l_bytCapaOrigen;

        public ExceptionMiddleware(RequestDelegate pNext, ICapaActualService pCapaActualDatosService, IMapper pMapper, IConfiguration pConfiguration)
        {
            l_next = pNext;
            l_CapaActualDatosService = pCapaActualDatosService;
            l_Mapper = pMapper;
            l_Configuration = pConfiguration;
        }
        public async Task InvokeAsync(HttpContext pContext)
        {
            try
            {
                await l_next(pContext);
            }
            catch (Exception exception)
            {
                l_bytCapaOrigen = l_CapaActualDatosService.fbytCapaActualObtener();
                string errorId = Guid.NewGuid().ToString();
                LogContext.PushProperty("ErrorId", errorId);
                LogContext.PushProperty("StackTrace", exception.StackTrace);
                clsLogError.EscribirLogRespuesta(l_Configuration["WebApi:ApiNombreLog"]!, "ExceptionMessage: " + exception.ToString(), l_Configuration["WebApi:ApiRutaLog"]!);
                var objDtoErrorServicio = new DtoErrorServicio
                {
                    strFuente = exception.TargetSite?.DeclaringType?.FullName!,
                    strExcepcion = exception.Message.Trim(),
                    strDetalle = exception.ToString(),
                };

                if (objDtoErrorServicio.strFuente == null)
                {
                    objDtoErrorServicio.strFuente = "Sin Trace";
                }

                var exceptionType = exception.GetType();
                if (exceptionType == typeof(SqlException))
                {
                    objDtoErrorServicio.bytCapaOrigen = (byte)clsEnums.ENCapaOrigenLogError.BaseDatos;
                }
                else
                {
                    objDtoErrorServicio.bytCapaOrigen = l_bytCapaOrigen;
                }

                if (exception is not CustomException && exception.InnerException != null)
                {
                    while (exception.InnerException != null)
                    {
                        exception = exception.InnerException;
                    }
                }
                //bool blnTimeOut = false;
                string strHeaderResponse = "X-Exception";
                if (exceptionType == typeof(OperationCanceledException) && pContext.RequestAborted.IsCancellationRequested)
                {
                    //blnTimeOut = true;
                    objDtoErrorServicio.intStatusCode = (int)HttpStatusCode.RequestTimeout;
                    strHeaderResponse = "X-Request-Timeout";
                }
                else
                {
                    switch (exception)
                    {
                        case CustomException e:
                            objDtoErrorServicio.intStatusCode = (int)e.hscCodidoEstado;
                            if (e.strMensajeError is not null)
                            {
                                objDtoErrorServicio.strExcepcion = e.strMensajeError;
                            }
                            if (!e.strHeaderResponse.IsNullOrEmpty()) { strHeaderResponse = e.strHeaderResponse; }
                            break;

                        default:
                            objDtoErrorServicio.intStatusCode = (int)HttpStatusCode.InternalServerError;
                            break;
                    }
                }

                Log.Error($"{objDtoErrorServicio.strExcepcion} La solicitud falló con el código de estado {pContext.Response.StatusCode} y el identificador de error {errorId}.");

                if (!pContext.Response.HasStarted)
                {
                    DToResponse<string> objDtoRespuesta = await GenerarRptaException<string>(objDtoErrorServicio.intStatusCode, string.Empty, objDtoErrorServicio);
                    pContext.Response.ContentType = "application/json";
                    pContext.Response.StatusCode = objDtoErrorServicio.intStatusCode;
                    pContext.Response.Headers.Add(strHeaderResponse, "true");
                    await pContext.Response.WriteAsync(JsonConvert.SerializeObject(objDtoRespuesta));
                }
                else
                {
                    Log.Warning("No se puede escribir la respuesta de error. La respuesta ya ha comenzado.");
                    await l_next(pContext);
                }

            }
        }
        private async Task<DToResponse<T>> GenerarRptaException<T>(int pintIdCodigo, string pstrMensaje, DtoErrorServicio? pobjDToError = null)
        {
            return new DToResponse<T>(pintIdCodigo, false, pstrMensaje, pobjDToError!);
        }
    }
}
