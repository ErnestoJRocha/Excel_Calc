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
    public class TaxablePersonsController : ControllerBase
    {
        private readonly syfidbContext _context;

        public TaxablePersonsController(syfidbContext context)
        {
            _context = context;
        }

        // GET: api/TaxablePersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxablePerson>>> GetTaxablePerson([FromQuery] TaxablePerson taxable)
        {
            IQueryable<TaxablePerson> taxableperson = _context.TaxablePerson;

            if (taxable.GrossWage > 0)


            {
               taxableperson = taxableperson.Where(
                         i => i.GrossWage.Equals(taxable.GrossWage));
            }

            if (taxable.Tax >= 0)


            {
                taxableperson = taxableperson.Where(
                          i => i.Tax.Equals(taxable.Tax));
            }

            if (taxable.PersonTypeId >= 1)


            {
                taxableperson = taxableperson.Where(
                          i => i.PersonTypeId.Equals(taxable.PersonTypeId));
            }



            return await taxableperson.ToListAsync();
        }

        // GET: api/TaxablePersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxablePerson>> GetTaxablePerson(int id)
        {
            var taxablePerson = await _context.TaxablePerson.FindAsync(id);

            if (taxablePerson == null)
            {
                return NotFound();
            }

            return taxablePerson;
        }

        // PUT: api/TaxablePersons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxablePerson(int id, TaxablePerson taxablePerson)
        {
            if (id != taxablePerson.Id)
            {
                return BadRequest();
            }

            _context.Entry(taxablePerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxablePersonExists(id))
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

        // POST: api/TaxablePersons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaxablePerson>> PostTaxablePerson(TaxablePerson taxablePerson)
        {
            _context.TaxablePerson.Add(taxablePerson);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TaxablePersonExists(taxablePerson.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTaxablePerson", new { id = taxablePerson.Id }, taxablePerson);
        }

        // DELETE: api/TaxablePersons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaxablePerson>> DeleteTaxablePerson(int id)
        {
            var taxablePerson = await _context.TaxablePerson.FindAsync(id);
            if (taxablePerson == null)
            {
                return NotFound();
            }

            _context.TaxablePerson.Remove(taxablePerson);
            await _context.SaveChangesAsync();

            return taxablePerson;
        }

        private bool TaxablePersonExists(int id)
        {
            return _context.TaxablePerson.Any(e => e.Id == id);
        }
    }
}
