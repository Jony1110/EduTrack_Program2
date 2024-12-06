using EduTrack.API.Dtos;
using EduTrack.Domain.ViewModels;
using EduTrack.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaseController : ControllerBase
    {
        private readonly ClaseRepository _repo;

        public ClaseController(ClaseRepository repo)
        {
            _repo = repo;
        }

        // Obtener una clase por ID
        [HttpGet("GetClase/{id}")]
        public async Task<ActionResult<ClaseDto>> GetClase(int id)
        {
            var clase = await _repo.Get(id);
            if (clase == null)
            {
                return NotFound($"No se encontró una clase con el ID {id}.");
            }

            return clase;
        }

        // Obtener todas las clases
        [HttpGet(nameof(GetClases))]
        public async Task<ActionResult<List<ClaseDto>>> GetClases()
        {
            var clases = await _repo.GetAll();
            return clases;
        }

        // Agregar una nueva clase
        [HttpPost(nameof(AddClase))]
        public async Task<ActionResult<CreateClaseResponse>> AddClase([FromBody] CreateClaseRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            try
            {
                var response = await _repo.Add(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Actualizar una clase existente
        [HttpPut("UpdateClase/{id}")]
        public async Task<IActionResult> UpdateClase(int id, CreateClaseRequest request)
        {
            try
            {
                var updatedClase = await _repo.Update(id, request);

                // Retorna la clase actualizada en la respuesta
                return Ok(updatedClase);
            }
            catch (Exception ex)
            {
                // Maneja los errores y retorna un mensaje si no se encuentra la clase
                return NotFound(ex.Message);
            }
        }

        // Eliminar una clase
        [HttpDelete("DeleteClase/{id}")]
        public async Task<IActionResult> DeleteClase(int id)
        {
            var clase = await _repo.Get(id);
            if (clase == null)
            {
                return NotFound(); // Si no se encuentra la clase, devuelve NotFound
            }

            // Eliminar la clase
            await _repo.Delete(id);

            return NoContent(); // Retorna 204 No Content indicando que la operación fue exitosa
        }
    }
}
