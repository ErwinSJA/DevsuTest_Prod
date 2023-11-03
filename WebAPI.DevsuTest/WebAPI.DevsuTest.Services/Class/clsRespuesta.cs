using WebAPI.DevsuTest.Util.Class;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.DTOs.Comunes;

namespace WebAPI.DevsuTest.Services.Class
{
    public class clsRespuesta
    {
        private readonly ICapaActualService l_CapaActualService;
        private readonly CancellationToken l_CancellationToken;
        private readonly bool l_blnValidaTimeOut;

        public clsRespuesta(ICapaActualService pCapaActualService, CancellationToken pCancellationToken, bool pblnValidaTimeOut = true)
        {
            l_CapaActualService = pCapaActualService;
            l_CancellationToken = pCancellationToken;
            l_blnValidaTimeOut = pblnValidaTimeOut;
        }

        public async Task<DToResponse<T>> fDtoGenerarRptaValidacion<T>(int pintIdCodigo, bool pblnEstadoRpta, string pstrMensaje)
        {
            // GRABAR LOG EN BD
            // FIN GRABAR LOG EN BD

            if (l_blnValidaTimeOut == true && l_CancellationToken.IsCancellationRequested == true)
            { l_CancellationToken.ThrowIfCancellationRequested(); }

            return await Task.Run(() => new DToResponse<T>(pintIdCodigo, pblnEstadoRpta, pstrMensaje));
        }

        public async Task<DToResponse<T>> fDtoGenerarRptaOK<T>(T pobjRespuesta)
        {
            // GRABAR LOG EN BD
            // FIN GRABAR LOG EN BD

            if (l_blnValidaTimeOut == true && l_CancellationToken.IsCancellationRequested == true)
            { l_CancellationToken.ThrowIfCancellationRequested(); }

            return await Task.Run(() => new DToResponse<T>(0, true, "Ejecutado Satisfactoriamente", pobjRespuesta));
        }
    }
}
