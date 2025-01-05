using EduTrack.API.Dtos;
using EduTrack.Domain.Entities;
using EduTrack.Domain.ViewModels;
using EduTrack.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Infraestructure.Repositories
{
    public class UsuarioRepository
    {
        private readonly EduTrackDbContext _context;

        public UsuarioRepository(EduTrackDbContext context)
        {
            this._context = context;
        }

        // Obtener todos los usuarios
        public async Task<List<UsuarioDto>> GetAllUsuarios()
        {
            var usuariosFromDb = await _context.Usuarios.ToListAsync();

            if (!usuariosFromDb.Any())
                throw new Exception("No Data Found");

            return usuariosFromDb.Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Correo = u.Correo,
                Matricula = u.Matricula,
                Rol = u.Rol,
                FechaRegistro = u.FechaRegistro,
                Activo = u.Activo
            }).ToList();
        }

        // Obtener un usuario por ID
        public async Task<UsuarioDto> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                throw new Exception("No Data Found");

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Matricula = usuario.Matricula,
                Rol = usuario.Rol,
                FechaRegistro = usuario.FechaRegistro,
                Activo = usuario.Activo
            };
        }

        // Crear un nuevo usuario
        public async Task<CreateUsuarioResponse> AddUsuario(CreateUsuarioRequest request)
        {
            var nuevoUsuario = new Usuario
            {
                Nombre = request.Nombre,
                Correo = request.Correo,
                Matricula = request.Matricula,
                Contraseña = request.Contraseña, // Recuerda aplicar hash antes de guardar en producción
                Rol = request.Rol,
                FechaRegistro = request.FechaRegistro ?? DateTime.Now.ToString("yyyy-MM-dd"),
                Activo = request.Activo
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            return new CreateUsuarioResponse { Id = nuevoUsuario.Id, Nombre = nuevoUsuario.Nombre, Correo = nuevoUsuario.Correo, Rol = nuevoUsuario.Rol, Activo = nuevoUsuario.Activo };
        }

        // Actualizar un usuario
        public async Task<UsuarioDto> UpdateUsuario(int id, CreateUsuarioRequest request)
        {
            var usuarioDb = await _context.Usuarios.FindAsync(id);

            if (usuarioDb == null)
                throw new Exception("Usuario no encontrado.");

            usuarioDb.Nombre = request.Nombre;
            usuarioDb.Correo = request.Correo;
            usuarioDb.Matricula = request.Matricula;
            usuarioDb.Contraseña = request.Contraseña; // Aplica hash antes de guardar
            usuarioDb.Rol = request.Rol;
            usuarioDb.Activo = request.Activo;

            await _context.SaveChangesAsync();

            return new UsuarioDto
            {
                Id = usuarioDb.Id,
                Nombre = usuarioDb.Nombre,
                Correo = usuarioDb.Correo,
                Matricula = usuarioDb.Matricula,
                Rol = usuarioDb.Rol,
                FechaRegistro = usuarioDb.FechaRegistro,
                Activo = usuarioDb.Activo
            };
        }

        // Eliminar un usuario
        public async Task DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                throw new Exception("Usuario no encontrado.");

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

    }
}
