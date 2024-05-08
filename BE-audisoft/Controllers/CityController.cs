using BE_axede.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_axede.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public CityController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListCity = await _context.City.ToListAsync();
                return Ok(ListCity);
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
                var estudiante = await _context.City.FindAsync(id);
                if(estudiante != null)
                {
                    _context.City.Remove(estudiante);
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
        public async Task<IActionResult> Post(City city)
        {
            try
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = city.Id }, city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, City city)
        {
            try
            {
                if(id != city.Id)
                {
                    return BadRequest();
                }
                _context.Update(city);
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
