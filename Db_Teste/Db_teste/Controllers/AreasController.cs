using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Db_teste.Models;

namespace Db_teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly syfidbContext _context;

        public AreasController(syfidbContext context)
        {
            _context = context;
        }

        // GET: api/Areas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Areas>>> GetAreas()
       // public async Task<Areas> GetAreas()
        {
            return await _context.Areas.ToListAsync();
        }

        // GET: api/Areas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Areas>> GetAreas(int id)
        {
            var areas = await _context.Areas.FindAsync(id);

            if (areas == null)
            {
                return NotFound();
            }

            return areas;
        }

        // PUT: api/Areas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreas(int id, Areas areas)
        {
            if (id != areas.Id)
            {
                return BadRequest();
            }

            _context.Entry(areas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreasExists(id))
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

        // POST: api/Areas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Areas>> PostAreas(Areas areas)
        {
            _context.Areas.Add(areas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AreasExists(areas.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAreas", new { id = areas.Id }, areas);
        }

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Areas>> DeleteAreas(int id)
        {
            var areas = await _context.Areas.FindAsync(id);
            if (areas == null)
            {
                return NotFound();
            }

            _context.Areas.Remove(areas);
            await _context.SaveChangesAsync();

            return areas;
        }

        private bool AreasExists(int id)
        {
            return _context.Areas.Any(e => e.Id == id);
        }
    }
}
