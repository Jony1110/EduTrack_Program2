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

        //EnvironmentVariablesExtensions context = new 

        //_repo = new ProfesorRepository()

        public ProfesorController(ProfesorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetProfesor/{id}")]
        public async Task<ActionResult<ProfesorDto>> GetProfesor(int id)
        {
            var profesor = await _repo.Get(id);
            if (profesor == null)
            {
                return NotFound();
            }

            //var response = new ProfesorDto
            //{
            //    Id = profesorDb.Id,
            //    Gender = profesorDb.Gender,
            //    Email = profesorDb.Email,
            //    IsActive = profesorDb.IsActive,
            //    Lastname = profesorDb.Lastname,
            //    Name = profesorDb.Name,
            //    Phone = profesorDb.Phone
            //};


            //return profesorDb;
            return profesor;

        }

        [HttpGet(nameof(GetProfesores))]
        public async Task<ActionResult<List<ProfesorDto>>> GetProfesores()
        {
            var profesores = await _repo.GetAll();

            return profesores;
        }

        [HttpPost(nameof(AddProfesor))]
        public async Task<ActionResult<CreateProfesorResponse>> AddProfesor(CreateProfesorRequest request)
        {
            //var dbProfesor = new Profesor();

            //dbProfesor.Id = request.Id;
            //dbProfesor.Name = request.Name;
            //dbProfesor.Lastname = request.Lastname;
            //dbProfesor.Email = request.Email;
            //dbProfesor.Phone = request.Phone;
            //dbProfesor.Gender = request.Gender;
            //dbProfesor.Birthdate = request.Birthdate;
            //dbProfesor.IsActive = request.IsActive;

            //_context.Profesores.Add(dbProfesor);
            //await _context.SaveChangesAsync();

            //return new CreateProfesorResponse { Id = dbProfesor.Id };

            return await _repo.Add(request);

        }

        //[HttpPut("UpdateCustomer/{id}")]
        //public async Task<IActionResult> UpdateCustomer(int id, CreateProfesorRequest request)
        //{
        //    var profesor = await _repo.Update(id);
        //    if (profesor == null)
        //    {
        //        return NotFound();
        //    }

        //    profesor.Name = request.Name;
        //    profesor.Lastname = request.Lastname;
        //    profesor.Email = request.Email;
        //    profesor.Phone = request.Phone;
        //    profesor.Gender = request.Gender;
        //    profesor.Birthdate = request.Birthdate;
        //    profesor.IsActive = request.IsActive; ;
        //    _repo.Customers.Update(customerDb);
        //    await _repo.SaveChangesAsync();
        //    return NoContent();
        //    return await _repo.Add(request);
        //}

        //[HttpDelete("DeleteCustomer/{id}")]
        //public async Task<IActionResult> DeleteCustomer(int id)
        //{
        //    var customerDb = await _repo.profesor.FindAsync(id);
        //    if (customerDb == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Customers.Remove(customerDb);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}
    }
}
