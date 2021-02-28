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
    public class DependentsController : ControllerBase
    {
        private readonly syfidbContext _context;

        public DependentsController(syfidbContext context)
        {
            _context = context;
        }

        // GET: api/Dependents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dependents>>> GetDependents([FromQuery] Dependents depend)
        {

            IQueryable<Dependents> dependents = _context.Dependents;

            //if (!string.IsNullOrEmpty(depend.DependentsNum))
           
                if (depend.DependentsNum > 0 && depend.DependentsNum <= 6)


            {
                dependents = dependents.Where(
                         d => d.DependentsNum.Equals(depend.DependentsNum));
            }


             
            return await dependents.ToListAsync();

           // return await _context.Dependents.ToListAsync();
        }

        // GET: api/Dependents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dependents>> GetDependents(int id)
        {
            var dependents = await _context.Dependents.FindAsync(id);

            if (dependents == null)
            {
                return NotFound();
            }

            return dependents;
        }

        // PUT: api/Dependents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDependents(int id, Dependents dependents)
        {
            if (id != dependents.Id)
            {
                return BadRequest();
            }

            _context.Entry(dependents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DependentsExists(id))
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

        // POST: api/Dependents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dependents>> PostDependents(Dependents dependents)
        {
            _context.Dependents.Add(dependents);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DependentsExists(dependents.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDependents", new { id = dependents.Id }, dependents);
        }

        // DELETE: api/Dependents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dependents>> DeleteDependents(int id)
        {
            var dependents = await _context.Dependents.FindAsync(id);
            if (dependents == null)
            {
                return NotFound();
            }

            _context.Dependents.Remove(dependents);
            await _context.SaveChangesAsync();

            return dependents;
        }

        private bool DependentsExists(int id)
        {
            return _context.Dependents.Any(e => e.Id == id);
        }
    }
}
