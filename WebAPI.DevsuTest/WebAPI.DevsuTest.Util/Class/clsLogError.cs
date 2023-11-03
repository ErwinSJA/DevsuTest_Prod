namespace WebAPI.DevsuTest.Util.Class
{
    public static class clsLogError
    {
        public static bool EscribirLogRespuesta(string pstrNombreLog, string pstrTexto, string pstrRuta)
        {
            try
            {
                pstrRuta = pstrRuta + "Log" + pstrNombreLog + "_" + Convert.ToString(DateTime.Now.Year) + (Convert.ToString(DateTime.Now.Month).Length == 1 ? "0" : "") + Convert.ToString(DateTime.Now.Month) + (Convert.ToString(DateTime.Now.Day).Length == 1 ? "0" : "") + Convert.ToString(DateTime.Now.Day);

                using (StreamWriter sw = new (pstrRuta, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss fffffff") + " -> " + pstrTexto);
                    sw.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
