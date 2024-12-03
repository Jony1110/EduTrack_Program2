using EduTrack.API.Dtos;
using EduTrack.Domain.ViewModels;
using EduTrack.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly ProfesorRepository _repo;

        public ProfesorController(ProfesorRepository repo)
        {
            _repo = repo;
        }

        // Obtener un profesor por ID
        [HttpGet("GetProfesor/{id}")]
        public async Task<ActionResult<ProfesorDto>> GetProfesor(int id)
        {
            var profesor = await _repo.Get(id);
            if (profesor == null)
            {
                return NotFound($"No se encontró un profesor con el ID {id}.");
            }

            return profesor;
        }

        // Obtener todos los profesores
        [HttpGet(nameof(GetProfesores))]
        public async Task<ActionResult<List<ProfesorDto>>> GetProfesores()
        {
            var profesores = await _repo.GetAll();
            return profesores;
        }

        // Agregar un nuevo profesor
        // Método para manejar solicitudes OPTIONS (Preflight)
        [HttpOptions("AddProfesor")]
        public IActionResult Preflight()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:7019");
            Response.Headers.Add("Access-Control-Allow-Methods", "POST, OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            return Ok();
        }

        // Método POST para agregar un profesor
        [HttpPost(nameof(AddProfesor))]
        public async Task<ActionResult<CreateProfesorResponse>> AddProfesor([FromBody] CreateProfesorRequest request)
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

        // Actualizar un profesor existente
        [HttpPut("UpdateProfesor/{id}")]
        public async Task<IActionResult> UpdateProfesor(int id, CreateProfesorRequest request)
        {
            try
            {
                // Llama al método Update del repositorio con los parámetros correctos
                var updatedProfesor = await _repo.Update(id, request);

                // Retorna el profesor actualizado en la respuesta
                return Ok(updatedProfesor); // Retorna el objeto actualizado como respuesta
            }
            catch (Exception ex)
            {
                // Maneja los errores y retorna un mensaje si no se encuentra el profesor
                return NotFound(ex.Message);
            }
        }


        // Eliminar un profesor
        [HttpDelete("DeleteProfesor/{id}")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            var profesor = await _repo.Get(id);
            if (profesor == null)
            {
                return NotFound(); // Si no se encuentra el profesor, devuelve NotFound
            }

            // Eliminar el profesor
            await _repo.Delete(id);

            return NoContent(); // Retorna 204 No Content indicando que la operación fue exitosa
        }
    }
}
