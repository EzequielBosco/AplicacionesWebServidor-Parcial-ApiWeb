namespace Parcial.Utils
{
    public class FormatearFechaPublicacionUtils
    {
        public static string FormatearFechaPublicacion(DateTime fechaPublicacion)
        {
            return fechaPublicacion.ToString("MM-yyyy");
        }
    }
}
