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
    public class PositionLevelsController : ControllerBase
    {
        private readonly syfidbContext _context;

        public PositionLevelsController(syfidbContext context)
        {
            _context = context;
        }

        // GET: api/PositionLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionLevel>>> GetPosition()
        {
            return await _context.PositionLevel.ToListAsync();
        }

        // GET: api/PositionLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionLevel>> GetPosition(decimal id)
        {
            var positionlevel = await _context.PositionLevel.FindAsync(id);

            if (positionlevel == null)
            {
                return NotFound();
            }

            return positionlevel;
        }

        // PUT: api/PositionLevels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosition(int id, PositionLevel positionlevel)
        {
            if (id != positionlevel.NivelId)
            {
                return BadRequest();
            }

            _context.Entry(positionlevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionLevelsExists(id))
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

        // POST: api/PositionLevels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PositionLevel>> PostPosition(PositionLevel positionlevel)
        {
            _context.PositionLevel.Add(positionlevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosition", new { id = positionlevel.NivelId }, positionlevel);
        }

        // DELETE: api/PositionLevels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PositionLevel>> DeletePosition(int id)
        {
            var positionlevel = await _context.PositionLevel.FindAsync(id);
            if (positionlevel == null)
            {
                return NotFound();
            }

            _context.PositionLevel.Remove(positionlevel);
            await _context.SaveChangesAsync();

            return positionlevel;
        }

        private bool PositionLevelsExists(int id)
        {
            return _context.PositionLevel.Any(e => e.NivelId == id);
        }
    }
}
