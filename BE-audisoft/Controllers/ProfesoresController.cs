using BE_audisoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_audisoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ProfesoresController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListProfesores = await _context.Profesores.ToListAsync();
                return Ok(ListProfesores);
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
                var profesor = await _context.Profesores.FindAsync(id);
                if (profesor != null)
                {
                    _context.Profesores.Remove(profesor);
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
        public async Task<IActionResult> Post(Profesores profesores)
        {
            try
            {
                _context.Add(profesores);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = profesores.Id }, profesores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Profesores profesores)
        {
            try
            {
                if (id != profesores.Id)
                {
                    return BadRequest();
                }
                _context.Update(profesores);
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
