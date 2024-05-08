using BE_axede.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_audisoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public HotelController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListHotel = await _context.Hotel.ToListAsync();

                var newArray = from hotel in _context.Hotel
                               join city in _context.City
                               on hotel.idCity equals city.Id
                               select new
                               {
                                   hotel,
                                   city
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
                var hotel = await _context.Hotel.FindAsync(id);
                if (hotel != null)
                {
                    _context.Hotel.Remove(hotel);
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
        public async Task<IActionResult> Post(Hotel Hotel)
        {
            try
            {
                _context.Add(Hotel);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = Hotel.Id }, Hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Hotel Hotel)
        {
            try
            {
                if (id != Hotel.Id)
                {
                    return BadRequest();
                }
                _context.Update(Hotel);
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
