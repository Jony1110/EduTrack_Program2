using EduTrack.API.Dtos;
//using EduTrack.Common.Requests;
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

        // Obtener una Clase por ID
        [HttpGet("GetClase/{id}")]
        public async Task<ActionResult<ClaseDto>> GetClase(int id)
        {
            try
            {
                var clase = await _repo.Get(id);
                if (clase == null)
                {
                    return NotFound($"No se encontró una clase con el ID {id}.");
                }

                return Ok(clase);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Obtener todas clases
        [HttpGet(nameof(GetClases))]
        public async Task<ActionResult<List<ClaseDto>>> GetClases()
        {
            try
            {
                var clases = await _repo.GetAll();
                if (clases == null || !clases.Any())
                {
                    return NotFound("No se encontraron clases.");
                }

                return Ok(clases);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // Método POST para agregar una clase
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

        // Actualizar un estudiante existente
        [HttpPut("UpdateClase/{id}")]
        public async Task<IActionResult> UpdateClase(int id, CreateClaseRequest request)
        {
            try
            {
                // Llama al método Update del repositorio con los parámetros correctos
                var updatedClase = await _repo.Update(id, request);

                // Retorna el estudiante actualizado en la respuesta
                return Ok(updatedClase); // Retorna el objeto actualizado como respuesta
            }
            catch (Exception ex)
            {
                // Maneja los errores y retorna un mensaje si no se encuentra el estudiante
                return NotFound(ex.Message);
            }
        }


        // Eliminar un estudiante
        [HttpDelete("DeleteClase/{id}")]
        public async Task<IActionResult> DeleteClase(int id)
        {
            var clase = await _repo.Get(id);
            if (clase == null)
            {
                return NotFound();
            }

            await _repo.Delete(id);

            return NoContent(); // Retorna 204 No Content indicando que la operación fue exitosa
        }

        //[HttpPost("AsignarProfesorAClase")]
        //public async Task<IActionResult> AsignarProfesorAClase([FromBody] CreateClaseRequest request)
        //{
        //    try
        //    {
        //        // Validar que los IDs no sean nulos o cero
        //        if (request.ClaseId <= 0 || request.ProfesorId <= 0)
        //        {
        //            return BadRequest("Los IDs de Clase y Profesor deben ser válidos.");
        //        }

        //        await _repo.AsignarProfesorAClase(request.ClaseId, request.ProfesorId);
        //        return Ok("Profesor asignado correctamente.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error al asignar profesor: {ex.Message}");
        //    }
        //}

        [HttpPost("AsignarProfesorAClase")]
        public async Task<IActionResult> AsignarProfesorAClase([FromBody] AsignarProfesorRequest request)
        {
            try
            {
                // Validar que los IDs no sean nulos o cero
                if (request.ClaseId <= 0 || request.ProfesorId <= 0)
                {
                    return BadRequest("Los IDs de Clase y Profesor deben ser válidos.");
                }

                await _repo.AsignarProfesorAClase(request.ClaseId, request.ProfesorId);
                return Ok("Profesor asignado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al asignar profesor: {ex.Message}");
            }
        }


    }
}
