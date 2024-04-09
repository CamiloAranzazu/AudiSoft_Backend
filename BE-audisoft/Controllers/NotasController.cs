using BE_audisoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_audisoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public NotasController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListNotas = await _context.Notas.ToListAsync();

                var newArray = from notas in _context.Notas
                               join estudiante in _context.Estudiantes
                               on notas.idEstudiante equals estudiante.Id
                               join profesor in _context.Profesores
                               on notas.idProfesor equals profesor.Id
                               select new
                               {
                                   notas.Id,
                                   notas.Nombre,
                                   notas.Valor,
                                   estudiante,
                                   profesor,

                               };

                return Ok(newArray);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var profesor = await _context.Notas.FindAsync(id);
                if (profesor != null)
                {
                    _context.Notas.Remove(profesor);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Notas notas)
        {
            try
            {
                _context.Add(notas);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = notas.Id }, notas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Notas notas)
        {
            try
            {
                if (id != notas.Id)
                {
                    return BadRequest();
                }
                _context.Update(notas);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
