using EduTrack.API.Dtos;
using EduTrack.Domain.ViewModels;
using EduTrack.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsistenciaController : ControllerBase
    {
        private readonly AsistenciaRepository _repo;

        public AsistenciaController(AsistenciaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllAsistencias")]
        public async Task<ActionResult<List<AsistenciaDto>>> GetAllAsistencias()
        {
            try
            {
                var asistencias = await _repo.GetAllAsistencias();
                if (asistencias == null || !asistencias.Any())
                {
                    return NotFound("No se encontraron asistencias.");
                }

                return Ok(asistencias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // Obtener todas las asistencias de una clase en una fecha
        [HttpGet("GetAsistencias/{idClase}/{fecha}")]
        public async Task<ActionResult<List<AsistenciaDto>>> GetAsistencias(int idClase, string fecha)
        {
            try
            {
                var asistencias = await _repo.GetAll(idClase, fecha);
                if (asistencias == null || !asistencias.Any())
                {
                    return NotFound($"No se encontraron asistencias para la clase con ID {idClase} en la fecha {fecha}.");
                }

                return Ok(asistencias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Obtener una asistencia por ID
        [HttpGet("GetAsistencia/{id}")]
        public async Task<ActionResult<AsistenciaDto>> GetAsistencia(int id)
        {
            try
            {
                var asistencia = await _repo.Get(id);
                if (asistencia == null)
                {
                    return NotFound($"No se encontró una asistencia con el ID {id}.");
                }

                return Ok(asistencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Agregar o actualizar asistencias
        [HttpPost("AddOrUpdateAsistencias")]
        public async Task<IActionResult> AddOrUpdateAsistencias([FromBody] List<CreateAsistenciaRequest> request)
        {
            if (request == null || !request.Any())
            {
                return BadRequest("La solicitud es inválida o está vacía.");
            }

            try
            {
                await _repo.AddOrUpdate(request);
                return Ok("Asistencias registradas o actualizadas correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteAsistencias/{id_asistencia}/{fecha}")]
        public async Task<IActionResult> DeleteAsistencias(int id_asistencia, string fecha)
        {
            try
            {
                await _repo.Delete(id_asistencia, fecha);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Actualizar una asistencia existente
        [HttpPut("UpdateAsistencia/{id}")]
        public async Task<IActionResult> UpdateAsistencia(int id, CreateAsistenciaRequest request)
        {
            if (request == null || id != request.id_asistencia)
            {
                return BadRequest("La solicitud es inválida o el ID no coincide.");
            }

            try
            {
                // Llama al repositorio para actualizar la asistencia
                var updatedAsistencia = await _repo.Update(id, request);

                // Retorna la asistencia actualizada como respuesta
                return Ok(updatedAsistencia); // Retorna el objeto actualizado
            }
            catch (Exception ex)
            {
                // Maneja los errores y retorna un mensaje si no se encuentra la asistencia
                return NotFound(ex.Message);
            }
        }


    }
}
