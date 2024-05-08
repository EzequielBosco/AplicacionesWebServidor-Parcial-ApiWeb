using Microsoft.AspNetCore.Identity;
using Parcial.DTOs;
using Parcial.Models;
using System.Linq.Expressions;

namespace Parcial.Services.Implements
{
    public class LibroService : ILibroService
    {
        private static List<Libro> _libros = null;

        public LibroService()
        {
            if (_libros == null)
            {
                _libros = new List<Libro>();
                _libros.Add(new Libro
                {
                    Id = 1,
                    Titulo = "El señor de los anillos",
                    Descripcion = "Un libro de aventuras",
                    Genero = "Fantasía",
                    FechaPublicacion = new DateTime(1954, 7, 29),
                    Editorial = "Minotauro",
                    ISBN = "9788445071409",
                    CantidadEjemplares = 100,
                    NombreAutor = "J.R.R. Tolkien",
                    FechaNacimientoAutor = new DateTime(1892, 1, 3),
                    Paginas = 1216,
                    Precio = 25,
                    Activo = true
                });
                _libros.Add(new Libro
                {
                    Id = 2,
                    Titulo = "El código Da Vinci",
                    Descripcion = "Un libro de misterio",
                    Genero = "Misterio",
                    FechaPublicacion = new DateTime(2003, 3, 18),
                    Editorial = "Doubleday",
                    ISBN = "9780385504201",
                    CantidadEjemplares = 50,
                    NombreAutor = "Dan Brown",
                    FechaNacimientoAutor = new DateTime(1964, 6, 22),
                    Paginas = 454,
                    Precio = 20,
                    Activo = true
                });
                _libros.Add(new Libro
                {
                    Id = 3,
                    Titulo = "El principito",
                    Descripcion = "Un libro de aventuras",
                    Genero = "Fantasía",
                    FechaPublicacion = new DateTime(1943, 4, 6),
                    Editorial = "Reynal & Hitchcock",
                    ISBN = "9780156012195",
                    CantidadEjemplares = 200,
                    NombreAutor = "Antoine de Saint-Exupéry",
                    FechaNacimientoAutor = new DateTime(1900, 6, 29),
                    Paginas = 96,
                    Precio = 15,
                    Activo = true
                });
                _libros.Add(new Libro
                {
                    Id = 4,
                    Titulo = "Harry Potter y la piedra filosofal",
                    Descripcion = "Un libro de magia y aventuras",
                    Genero = "Fantasía",
                    FechaPublicacion = new DateTime(1997, 6, 26),
                    Editorial = "Bloomsbury",
                    ISBN = "9780747532743",
                    CantidadEjemplares = 150,
                    NombreAutor = "J.K. Rowling",
                    FechaNacimientoAutor = new DateTime(1965, 7, 31),
                    Paginas = 223,
                    Precio = 18,
                    Activo = true
                });
                _libros.Add(new Libro
                {
                    Id = 5,
                    Titulo = "Crimen y castigo",
                    Descripcion = "Una novela psicológica",
                    Genero = "Ficción",
                    FechaPublicacion = new DateTime(1866, 1, 1),
                    Editorial = "The Russian Messenger",
                    ISBN = "9780140449136",
                    CantidadEjemplares = 80,
                    NombreAutor = "Fyodor Dostoevsky",
                    FechaNacimientoAutor = new DateTime(1821, 11, 11),
                    Paginas = 671,
                    Precio = 22,
                    Activo = true
                });
                _libros.Add(new Libro
                {
                    Id = 6,
                    Titulo = "1984",
                    Descripcion = "Una novela distópica",
                    Genero = "Ficción",
                    FechaPublicacion = new DateTime(1949, 6, 8),
                    Editorial = "Secker & Warburg",
                    ISBN = "9780451524935",
                    CantidadEjemplares = 120,
                    NombreAutor = "George Orwell",
                    FechaNacimientoAutor = new DateTime(1903, 6, 25),
                    Paginas = 328,
                    Precio = 19,
                    Activo = true
                });
                _libros.Add(new Libro
                {
                    Id = 7,
                    Titulo = "Orgullo y prejuicio",
                    Descripcion = "Una novela romántica",
                    Genero = "Ficción",
                    FechaPublicacion = new DateTime(1813, 1, 28),
                    Editorial = "T. Egerton, Whitehall",
                    ISBN = "9780141439518",
                    CantidadEjemplares = 90,
                    NombreAutor = "Jane Austen",
                    FechaNacimientoAutor = new DateTime(1775, 12, 16),
                    Paginas = 432,
                    Precio = 17,
                    Activo = true
                });
                _libros.Add(new Libro
                {
                    Id = 8,
                    Titulo = "Cien años de soledad",
                    Descripcion = "Una novela de realismo mágico",
                    Genero = "Ficción",
                    FechaPublicacion = new DateTime(1967, 5, 30),
                    Editorial = "Editorial Sudamericana",
                    ISBN = "9780307350483",
                    CantidadEjemplares = 110,
                    NombreAutor = "Gabriel García Márquez",
                    FechaNacimientoAutor = new DateTime(1927, 3, 6),
                    Paginas = 417,
                    Precio = 21,
                    Activo = true
                });
                _libros.Add(new Libro
                {
                    Id = 9,
                    Titulo = "Don Quijote de la Mancha",
                    Descripcion = "Una novela de caballería",
                    Genero = "Ficción",
                    FechaPublicacion = new DateTime(1605, 1, 16),
                    Editorial = "Francisco de Robles",
                    ISBN = "9788420412146",
                    CantidadEjemplares = 95,
                    NombreAutor = "Miguel de Cervantes",
                    FechaNacimientoAutor = new DateTime(1547, 9, 29),
                    Paginas = 863,
                    Precio = 23,
                    Activo = true
                });
                _libros.Add(new Libro
                {
                    Id = 10,
                    Titulo = "Moby Dick",
                    Descripcion = "Una novela de aventuras marítimas",
                    Genero = "Ficción",
                    FechaPublicacion = new DateTime(1851, 10, 18),
                    Editorial = "Harper & Brothers",
                    ISBN = "9780142437247",
                    CantidadEjemplares = 85,
                    NombreAutor = "Herman Melville",
                    FechaNacimientoAutor = new DateTime(1819, 8, 1),
                    Paginas = 624,
                    Precio = 23,
                    Activo = true
                });
            }
        }
        public async Task<List<Libro>> GetAll()
        {
            return await Task.Run(() => _libros.ToList());
        }

        public async Task<Libro>GetByISBN(string ISBN)
        {
            return await Task.Run(() => _libros.LastOrDefault(l => l.ISBN == ISBN));
        }

        public async Task<Libro> GetByTitulo(string titulo)
        {
            return await Task.Run(() => _libros.LastOrDefault(l => l.Titulo == titulo));
        }

        public Task<Libro> Create(LibroRequestCreateDTO libro)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (!_libros.Any(l => l.Titulo == libro.Titulo && l.ISBN == libro.ISBN))
                    {
                        int nuevoId = Utils.IncrementoIdUtils.ObtenerSiguienteId();

                        var nuevoLibro = new Libro
                        {
                            Id = nuevoId,
                            Titulo = libro.Titulo,
                            Descripcion = libro.Descripcion,
                            Genero = libro.Genero,
                            FechaPublicacion = libro.FechaPublicacion,
                            Editorial = libro.Editorial,
                            ISBN = libro.ISBN,
                            CantidadEjemplares = libro.CantidadEjemplares,
                            NombreAutor = libro.NombreAutor,
                            FechaNacimientoAutor = libro.FechaNacimientoAutor,
                            Paginas = libro.Paginas,
                            Precio = libro.Precio
                        };

                        _libros.Add(nuevoLibro);

                        return Task.FromResult(nuevoLibro);
                    }
                    else
                    {
                        throw new Exception("El libro ya existe.");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }

        public async Task<Libro> Update(string ISBN, LibroRequestUpdateDTO libro)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var libroExistente = _libros.LastOrDefault(l => l.ISBN == ISBN);

                    if (libroExistente != null)
                    {
                        libroExistente.Titulo = libro.Titulo;
                        libroExistente.Descripcion = libro.Descripcion;
                        libroExistente.Genero = libro.Genero;
                        libroExistente.FechaPublicacion = libro.FechaPublicacion;
                        libroExistente.Editorial = libro.Editorial;
                        libroExistente.CantidadEjemplares = libro.CantidadEjemplares;
                        libroExistente.NombreAutor = libro.NombreAutor;
                        libroExistente.FechaNacimientoAutor = libro.FechaNacimientoAutor;
                        libroExistente.Paginas = libro.Paginas;
                        libroExistente.Precio = libro.Precio;
                        libroExistente.Activo = libro.Activo;

                        return Task.FromResult(libroExistente);
                    }
                    else
                    {
                        return null;
                        throw new Exception("El libro no se puede actualizar porque no existe.");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }

        public async Task<Libro> UpdateCantidadLibros(string ISBN, int cantidadLibros)
        {
            return await  Task.Run(() =>
            {
                try
                {
                    var libroExistente = _libros.LastOrDefault(l => l.ISBN == ISBN);

                    if (libroExistente != null)
                    {
                        libroExistente.CantidadEjemplares = cantidadLibros;

                        return Task.FromResult(libroExistente);
                    }
                    else
                    {
                        return null;
                        throw new Exception("El libro no se puede actializar porque no existe.");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }

        public async Task<bool> Delete(string ISBN)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var libroExistente = _libros.FirstOrDefault(l => l.ISBN == ISBN);

                    if (libroExistente != null)
                    {
                        _libros.Remove(libroExistente);
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    throw new Exception("El libro no se puede eliminar porque no existe.");
                }
            });
        }
    }
}
