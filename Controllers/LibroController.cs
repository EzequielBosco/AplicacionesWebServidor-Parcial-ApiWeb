using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial.Services;
using Parcial.Models;
using Parcial.DTOs;
using Parcial.Utils;

namespace Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        private readonly ILogger<LibroController> _logger;

        public LibroController(ILibroService libroService, ILogger<LibroController> logger)
        {
            _libroService = libroService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<LibroResponseDTO>>> GetAll()
        {
            try 
            {
                var allLibros = await _libroService.GetAll();

                _logger.LogInformation("Se invocó el endpoint GetAll.");
                if (allLibros.Count == 0)
                    return NoContent();

                var result = allLibros.Select(libro => new LibroResponseDTO
                {
                    Titulo = libro.Titulo,
                    Descripcion = libro.Descripcion,
                    Genero = libro.Genero,
                    FechaPublicacion = FormatearFechaPublicacionUtils.FormatearFechaPublicacion(libro.FechaPublicacion),
                    ISBN = libro.ISBN,
                    CantidadEjemplares = libro.CantidadEjemplares,
                    NombreAutor = libro.NombreAutor,
                    EdadAutor = DateTime.Now.Year - libro.FechaNacimientoAutor.Year,
                    Paginas = libro.Paginas,
                    Precio = libro.Precio
                }).ToList();

                _logger.LogWarning("Por enviar resultado de GetAll");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en GetAll:  {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error en el servidor al ejecutar GetAll.");
            }
        }

        [HttpGet("GetByISBN")]
        public async Task<ActionResult<LibroResponseDTO>> GetByISBN(string ISBN)
        {
            try
            {
                _logger.LogInformation($"Se invocó el EndPoint GetByISBN: {ISBN}");
                var libro = await _libroService.GetByISBN(ISBN);

                if (libro == null)
                {
                    _logger.LogError($"No se encontró un libro con el ISBN {ISBN}");
                    return NoContent();
                }

                var result = new LibroResponseDTO
                {
                    Titulo = libro.Titulo,
                    Descripcion = libro.Descripcion,
                    Genero = libro.Genero,
                    FechaPublicacion = FormatearFechaPublicacionUtils.FormatearFechaPublicacion(libro.FechaPublicacion),
                    ISBN = libro.ISBN,
                    CantidadEjemplares = libro.CantidadEjemplares,
                    NombreAutor = libro.NombreAutor,
                    EdadAutor = DateTime.Now.Year - libro.FechaNacimientoAutor.Year,
                    Paginas = libro.Paginas,
                    Precio = libro.Precio
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en GetByISBN: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error en el servidor al ejecutar GetByISBN.");
            }
        }

        [HttpGet("GetByTitulo")]
        public async Task<ActionResult<LibroResponseDTO>> GetByTitulo(string titulo)
        {
            try
            {
                _logger.LogInformation($"Se invocó el EndPoint GetByTitulo, se buscó el libro con el titulo: {titulo}");
                var libro = await _libroService.GetByTitulo(titulo);

                if (libro == null)
                    return NoContent();

                var result = new LibroResponseDTO
                {
                    Titulo = libro.Titulo,
                    Descripcion = libro.Descripcion,
                    Genero = libro.Genero,
                    FechaPublicacion = FormatearFechaPublicacionUtils.FormatearFechaPublicacion(libro.FechaPublicacion),
                    ISBN = libro.ISBN,
                    CantidadEjemplares = libro.CantidadEjemplares,
                    NombreAutor = libro.NombreAutor,
                    EdadAutor = DateTime.Now.Year - libro.FechaNacimientoAutor.Year,
                    Paginas = libro.Paginas,
                    Precio = libro.Precio
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en GetByTitulo: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error en el servidor al ejecutar GetByTitulo.");
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Libro>> Create(LibroRequestCreateDTO libro)
        {
            try
            {
                _logger.LogInformation("Se invocó el EndPoint Create");
                var newLibro = await _libroService.Create(libro);

                var result = new LibroRequestCreateDTO
                {
                    Titulo = newLibro.Titulo,
                    Descripcion = newLibro.Descripcion,
                    Genero = newLibro.Genero,
                    FechaPublicacion = newLibro.FechaPublicacion,
                    Editorial = newLibro.Editorial,
                    ISBN = newLibro.ISBN,
                    CantidadEjemplares = newLibro.CantidadEjemplares,
                    NombreAutor = newLibro.NombreAutor,
                    FechaNacimientoAutor = newLibro.FechaNacimientoAutor,
                    Paginas = newLibro.Paginas,
                    Precio = newLibro.Precio
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en Create: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error en el servidor al ejecutar Create.");
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Libro>> Update(string ISBN, LibroRequestUpdateDTO libro)
        {
            try
            {
                _logger.LogInformation($"Se invocó el EndPoint Update del libro: {libro}, con ISBN: {ISBN}");
                var updatedLibro = await _libroService.Update(ISBN, libro);

                if (updatedLibro == null)
                {
                    _logger.LogError($"No se encontró un libro con el ISBN {ISBN}");
                    return NotFound($"No se encontró un libro con el ISBN {ISBN}");
                }

                var result = new LibroRequestUpdateDTO
                {
                    Titulo = updatedLibro.Titulo,
                    Descripcion = updatedLibro.Descripcion,
                    Genero = updatedLibro.Genero,
                    FechaPublicacion = updatedLibro.FechaPublicacion,
                    Editorial = updatedLibro.Editorial,
                    CantidadEjemplares = updatedLibro.CantidadEjemplares,
                    NombreAutor = updatedLibro.NombreAutor,
                    FechaNacimientoAutor = updatedLibro.FechaNacimientoAutor,
                    Paginas = updatedLibro.Paginas,
                    Precio = updatedLibro.Precio,
                    Activo = updatedLibro.Activo
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en Update: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error en el servidor al ejecutar Update.");
            }
        }

        [HttpPatch("UpdateCantidadLibros")]
        public async Task<ActionResult<Libro>> UpdateCantidadLibros(string ISBN, int cantidadLibros)
        {
            try
            {
                _logger.LogInformation($"Se invocó el EndPoint UpdateCantidadLibros: {cantidadLibros}, de libro con ISBN: {ISBN}");
                var updatedLibro = await _libroService.UpdateCantidadLibros(ISBN, cantidadLibros);

                if (updatedLibro == null)
                {
                    _logger.LogError($"No se encontró un libro con el ISBN {ISBN}");
                    return NotFound($"No se encontró un libro con el ISBN {ISBN}");
                }

                var result = new LibroRequestCantidadUpdateDTO
                {
                    CantidadEjemplares = updatedLibro.CantidadEjemplares
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en UpdateCantidadLibros: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error en el servidor al ejecutar UpdateCantidad.");
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> Delete(string ISBN)
        {
            try
            {
                _logger.LogInformation($"Se invocó el EndPoint Delete: {ISBN}");
                var deleted = await _libroService.Delete(ISBN);

                if (!deleted)
                {
                    _logger.LogError($"No se encontró un libro con el ISBN {ISBN}");
                    return NotFound($"No se encontró un libro con el ISBN {ISBN}");
                }

                _logger.LogWarning($"Por eliminar el libro con ISBN: {ISBN}");

                return Ok(deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en Delete: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error en el servidor al ejecutar Delete.");
            }
        }
    }
}
