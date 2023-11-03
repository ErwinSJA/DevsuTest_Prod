namespace WebAPI.DevsuTest.Commons.CapaActual
{
    public class CapaActualService : ICapaActualService
    {
        private byte l_bytCapaActual;

        public void pCapaActualAsignar(byte pbytCapaActual)
        {
            l_bytCapaActual = pbytCapaActual;
        }

        public byte fbytCapaActualObtener()
        {
            return l_bytCapaActual;
        }
    }
}
