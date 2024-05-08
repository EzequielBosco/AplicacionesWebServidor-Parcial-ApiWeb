using Parcial.DTOs;
using Parcial.Models;

namespace Parcial.Services
{
    public interface ILibroService
    {
        Task<List<Libro>> GetAll();
        Task<Libro> GetByISBN(string ISBN);
        Task<Libro> GetByTitulo(string titulo);
        Task<Libro> Create(LibroRequestCreateDTO libro);
        Task<Libro> Update(string ISBN, LibroRequestUpdateDTO libro);
        Task<Libro> UpdateCantidadLibros(string ISBN, int cantidadLibros);
        Task<bool> Delete(string ISBN);
    }
}
