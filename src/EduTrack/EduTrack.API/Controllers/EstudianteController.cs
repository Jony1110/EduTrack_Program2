using EduTrack.API.Dtos;
using EduTrack.Domain.ViewModels;
using EduTrack.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteRepository _repo;

        public EstudianteController(EstudianteRepository repo)
        {
            _repo = repo;
        }

        // Obtener un estudiante por ID
        [HttpGet("GetEstudiante/{id}")]
        public async Task<ActionResult<EstudianteDto>> GetEstudiante(int id)
        {
            var estudiante = await _repo.Get(id);
            if (estudiante == null)
            {
                return NotFound($"No se encontró un estudiante con el ID {id}.");
            }

            return estudiante;
        }

        // Obtener todos los estudiantees
        [HttpGet(nameof(GetEstudiantes))]
        public async Task<ActionResult<List<EstudianteDto>>> GetEstudiantes()
        {
            var estudiantes = await _repo.GetAll();
            return estudiantes;
        }

        // Agregar un nuevo estudiante
        // Método para manejar solicitudes OPTIONS (Preflight)
        //[HttpOptions("AddEstudiante")]
        //public IActionResult Preflight()
        //{
        //    Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:7019");
        //    Response.Headers.Add("Access-Control-Allow-Methods", "POST, OPTIONS");
        //    Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
        //    return Ok();
        //}

        // Método POST para agregar un estudiante
        [HttpPost(nameof(AddEstudiante))]
        public async Task<ActionResult<CreateEstudianteResponse>> AddEstudiante([FromBody] CreateEstudianteRequest request)
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

        // Actualizar un estudiante existente
        [HttpPut("UpdateEstudiante/{id}")]
        public async Task<IActionResult> UpdateEstudiante(int id, CreateEstudianteRequest request)
        {
            try
            {
                // Llama al método Update del repositorio con los parámetros correctos
                var updatedEstudiante = await _repo.Update(id, request);

                // Retorna el estudiante actualizado en la respuesta
                return Ok(updatedEstudiante); // Retorna el objeto actualizado como respuesta
            }
            catch (Exception ex)
            {
                // Maneja los errores y retorna un mensaje si no se encuentra el estudiante
                return NotFound(ex.Message);
            }
        }


        // Eliminar un estudiante
        [HttpDelete("DeleteEstudiante/{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _repo.Get(id);
            if (estudiante == null)
            {
                return NotFound(); // Si no se encuentra el estudiante, devuelve NotFound
            }

            // Eliminar el estudiante
            await _repo.Delete(id);

            return NoContent(); // Retorna 204 No Content indicando que la operación fue exitosa
        }
    }
}
