namespace Parcial.Utils
{
    public class IncrementoIdUtils
    {
        private static int _ultimoId = 0;

        public static int ObtenerSiguienteId()
        {
            return ++_ultimoId;
        }
    }
}
