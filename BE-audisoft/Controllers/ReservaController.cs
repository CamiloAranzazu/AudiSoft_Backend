using BE_axede.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_audisoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ReservaController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListReserva = await _context.Reserva.ToListAsync();

                var newArray = from Reserva in _context.Reserva
                               join habitacion in _context.Habitaciones
                               on Reserva.idHabitacion equals habitacion.Id
                               join hotel in _context.Hotel
                               on Reserva.idHabitacion equals hotel.Id
                               join city in _context.City
                               on hotel.idCity equals city.Id
                               select new
                               {
                                   Reserva,
                                   hotel,
                                   city,
                                   habitacion
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
                var Reserva = await _context.Reserva.FindAsync(id);
                if (Reserva != null)
                {
                    _context.Reserva.Remove(Reserva);
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
        public async Task<IActionResult> Post(Reserva Reserva)
        {
            try
            {
                _context.Add(Reserva);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = Reserva.Id }, Reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Reserva Reserva)
        {
            try
            {
                if (id != Reserva.Id)
                {
                    return BadRequest();
                }
                _context.Update(Reserva);
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