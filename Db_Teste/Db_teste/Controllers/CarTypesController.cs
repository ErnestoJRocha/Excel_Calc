using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Db_teste.Models;

namespace Db_teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypesController : ControllerBase
    {
        private readonly syfidbContext _context;

        public CarTypesController(syfidbContext context)
        {
            _context = context;
        }

        // GET: api/CarTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarType>>> GetCarType([FromQuery] CarType car)
        {
            IQueryable<CarType> cartype = _context.CarType;

            //if (car.PluginKm > 0 || car.PluginKm <= 50)


            //{
            //    cartype = cartype.Where(
            //             i => i.PluginKm.Equals(car.PluginKm));
            //}

            //if (car.NormalKm > 0 || car.NormalKm <= 50)


            
                cartype = cartype.Where(
                         i => i.Cartype.Equals(car.Cartype));
            




            //return await cartype.ToListAsync();
            return await _context.CarType.ToListAsync();
        }

        // GET: api/CarTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarType>> GetCarType(int id)
        {
            var carType = await _context.CarType.FindAsync(id);

            if (carType == null)
            {
                return NotFound();
            }

            return carType;
        }

        // PUT: api/CarTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarType(int id, CarType carType)
        {
            if (id != carType.Id)
            {
                return BadRequest();
            }

            _context.Entry(carType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CarType>> PostCarType(CarType carType)
        {
            _context.CarType.Add(carType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarTypeExists(carType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarType", new { id = carType.Id }, carType);
        }

        // DELETE: api/CarTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarType>> DeleteCarType(int id)
        {
            var carType = await _context.CarType.FindAsync(id);
            if (carType == null)
            {
                return NotFound();
            }

            _context.CarType.Remove(carType);
            await _context.SaveChangesAsync();

            return carType;
        }

        private bool CarTypeExists(int id)
        {
            return _context.CarType.Any(e => e.Id == id);
        }
    }
}
