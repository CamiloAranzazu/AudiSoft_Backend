using BE_audisoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_audisoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public EstudiantesController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListEstudiantes = await _context.Estudiantes.ToListAsync();
                return Ok(ListEstudiantes);
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
                var estudiante = await _context.Estudiantes.FindAsync(id);
                if(estudiante != null)
                {
                    _context.Estudiantes.Remove(estudiante);
                    await _context.SaveChangesAsync();
                } else
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
        public async Task<IActionResult> Post(Estudiantes estudiantes)
        {
            try
            {
                _context.Add(estudiantes);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = estudiantes.Id }, estudiantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Estudiantes estudiantes)
        {
            try
            {
                if(id != estudiantes.Id)
                {
                    return BadRequest();
                }
                _context.Update(estudiantes);
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
