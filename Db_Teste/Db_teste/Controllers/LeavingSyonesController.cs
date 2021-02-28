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
    public class LeavingSyonesController : ControllerBase
    {
        private readonly syfidbContext _context;

        public LeavingSyonesController(syfidbContext context)
        {
            _context = context;
        }

        // GET: api/LeavingSyones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeavingSyone>>> GetLeavingSyone([FromQuery] LeavingSyone leaving)
        {
            IQueryable<LeavingSyone> leavingsyone = _context.LeavingSyone;

            if (!string.IsNullOrEmpty(leaving.Designation))
            {
                leavingsyone = leavingsyone.Where(
                          s => s.Designation.ToLower().Contains(leaving.Designation.ToLower()));
            }





            return await leavingsyone.ToListAsync();
        }

        // GET: api/LeavingSyones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeavingSyone>> GetLeavingSyone(int id)
        {
            var leavingSyone = await _context.LeavingSyone.FindAsync(id);

            if (leavingSyone == null)
            {
                return NotFound();
            }

            return leavingSyone;
        }

        // PUT: api/LeavingSyones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeavingSyone(int id, LeavingSyone leavingSyone)
        {
            if (id != leavingSyone.Id)
            {
                return BadRequest();
            }

            _context.Entry(leavingSyone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeavingSyoneExists(id))
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

        // POST: api/LeavingSyones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LeavingSyone>> PostLeavingSyone(LeavingSyone leavingSyone)
        {
            _context.LeavingSyone.Add(leavingSyone);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LeavingSyoneExists(leavingSyone.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLeavingSyone", new { id = leavingSyone.Id }, leavingSyone);
        }

        // DELETE: api/LeavingSyones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeavingSyone>> DeleteLeavingSyone(int id)
        {
            var leavingSyone = await _context.LeavingSyone.FindAsync(id);
            if (leavingSyone == null)
            {
                return NotFound();
            }

            _context.LeavingSyone.Remove(leavingSyone);
            await _context.SaveChangesAsync();

            return leavingSyone;
        }

        private bool LeavingSyoneExists(int id)
        {
            return _context.LeavingSyone.Any(e => e.Id == id);
        }
    }
}
