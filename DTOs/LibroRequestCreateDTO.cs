namespace Parcial.DTOs
{
    public class LibroRequestCreateDTO
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Genero { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Editorial { get; set; }
        public string ISBN { get; set; }
        public int CantidadEjemplares { get; set; }
        public string NombreAutor { get; set; }
        public DateTime FechaNacimientoAutor { get; set; }
        public int Paginas { get; set; }
        public decimal Precio { get; set; }
    }
}
