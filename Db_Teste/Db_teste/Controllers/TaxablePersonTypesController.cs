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
    public class TaxablePersonTypesController : ControllerBase
    {
        private readonly syfidbContext _context;

        public TaxablePersonTypesController(syfidbContext context)
        {
            _context = context;
        }

        // GET: api/TaxablePersonTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxablePersonType>>> GetTaxablePersonType([FromQuery] TaxablePersonType taxableperson)
        {
            IQueryable<TaxablePersonType> taxablepersontype = _context.TaxablePersonType;

            if (!string.IsNullOrEmpty(taxableperson.PersonTypeDescription))
            {
               taxablepersontype = taxablepersontype.Where(
                         i => i.PersonTypeDescription.ToLower().Contains(taxableperson.PersonTypeDescription.ToLower()));
            }




            return await taxablepersontype.ToListAsync();
        }

        // GET: api/TaxablePersonTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxablePersonType>> GetTaxablePersonType(int id)
        {
            var taxablePersonType = await _context.TaxablePersonType.FindAsync(id);

            if (taxablePersonType == null)
            {
                return NotFound();
            }

            return taxablePersonType;
        }

        // PUT: api/TaxablePersonTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxablePersonType(int id, TaxablePersonType taxablePersonType)
        {
            if (id != taxablePersonType.Id)
            {
                return BadRequest();
            }

            _context.Entry(taxablePersonType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxablePersonTypeExists(id))
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

        // POST: api/TaxablePersonTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaxablePersonType>> PostTaxablePersonType(TaxablePersonType taxablePersonType)
        {
            _context.TaxablePersonType.Add(taxablePersonType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TaxablePersonTypeExists(taxablePersonType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTaxablePersonType", new { id = taxablePersonType.Id }, taxablePersonType);
        }

        // DELETE: api/TaxablePersonTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaxablePersonType>> DeleteTaxablePersonType(int id)
        {
            var taxablePersonType = await _context.TaxablePersonType.FindAsync(id);
            if (taxablePersonType == null)
            {
                return NotFound();
            }

            _context.TaxablePersonType.Remove(taxablePersonType);
            await _context.SaveChangesAsync();

            return taxablePersonType;
        }

        private bool TaxablePersonTypeExists(int id)
        {
            return _context.TaxablePersonType.Any(e => e.Id == id);
        }
    }
}
