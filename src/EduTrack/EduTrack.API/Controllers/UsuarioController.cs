using EduTrack.API.Dtos;
using EduTrack.Domain.ViewModels;
using EduTrack.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _repo;

        public UsuarioController(UsuarioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllUsuarios")]
        public async Task<ActionResult<List<UsuarioDto>>> GetAllUsuarios()
        {
            try
            {
                var usuarios = await _repo.GetAllUsuarios();
                if (usuarios == null || !usuarios.Any())
                {
                    return NotFound("No se encontraron usuarios.");
                }

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetUsuario/{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(int id)
        {
            try
            {
                var usuario = await _repo.GetUsuario(id);
                if (usuario == null)
                {
                    return NotFound($"No se encontró un usuario con el ID {id}.");
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddUsuario")]
        public async Task<ActionResult<CreateUsuarioResponse>> AddUsuario([FromBody] CreateUsuarioRequest request)
        {
            if (request == null)
            {
                return BadRequest("Solicitud inválida.");
            }

            try
            {
                var response = await _repo.AddUsuario(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateUsuario/{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] CreateUsuarioRequest request)
        {
            if (request == null || id != request.Id)
            {
                return BadRequest("Solicitud inválida o el ID no coincide.");
            }

            try
            {
                var updatedUsuario = await _repo.UpdateUsuario(id, request);
                return Ok(updatedUsuario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("DeleteUsuario/{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                await _repo.DeleteUsuario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
