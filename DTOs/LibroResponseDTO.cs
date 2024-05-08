namespace Parcial.DTOs
{
    public class LibroResponseDTO
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Genero { get; set; }
        public string FechaPublicacion { get; set; }
        public string ISBN { get; set; }
        public int CantidadEjemplares { get; set; }
        public string NombreAutor { get; set; }
        public int EdadAutor { get; set; }
        public int Paginas { get; set; }
        public decimal Precio { get; set; }
    }
}