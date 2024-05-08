using BE_axede.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_audisoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public HabitacionesController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListHabitacion = await _context.Habitaciones.ToListAsync();

                var newArray = from habitacion in _context.Habitaciones
                               join typeHabitacion in _context.TypeHabitacion
                               on habitacion.idTypeHabitacion equals typeHabitacion.Id
                               select new
                               {
                                   habitacion,
                                   typeHabitacion
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
                var habitacion = await _context.Habitaciones.FindAsync(id);
                if (habitacion != null)
                {
                    _context.Habitaciones.Remove(habitacion);
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
        public async Task<IActionResult> Post(Habitaciones habitaciones)
        {
            try
            {
                _context.Add(habitaciones);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = habitaciones.Id }, habitaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Habitaciones habitaciones)
        {
            try
            {
                if (id != habitaciones.Id)
                {
                    return BadRequest();
                }
                _context.Update(habitaciones);
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
