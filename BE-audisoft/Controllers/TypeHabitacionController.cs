using BE_axede.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BE_axede.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeHabitacionController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public TypeHabitacionController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListTypeHabitacion = await _context.TypeHabitacion.ToListAsync();
                return Ok(ListTypeHabitacion);
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
                var typeHabitacion = await _context.TypeHabitacion.FindAsync(id);
                if (typeHabitacion != null)
                {
                    _context.TypeHabitacion.Remove(typeHabitacion);
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
        public async Task<IActionResult> Post(TypeHabitacion TypeHabitacion)
        {
            try
            {
                _context.Add(TypeHabitacion);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = TypeHabitacion.Id }, TypeHabitacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TypeHabitacion TypeHabitacion)
        {
            try
            {
                if (id != TypeHabitacion.Id)
                {
                    return BadRequest();
                }
                _context.Update(TypeHabitacion);
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

