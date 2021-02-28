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
    public class IrsTablesController : ControllerBase
    {
        private readonly syfidbContext _context;

        public IrsTablesController(syfidbContext context)
        {
            _context = context;
        }

        // GET: api/IrsTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IrsTable>>> GetIrsTable([FromQuery] IrsTable irs)
        {

            IQueryable<IrsTable> irstable = _context.IrsTable;
           /* if (!string.IsNullOrEmpty(stat.MaritalStatus))
            {
                status = status.Where(
                          s => s.MaritalStatus.ToLower().Contains(stat.MaritalStatus.ToLower()));
            }*/

            if (irs.IdIrsTable > 0)


            {
                irstable = irstable.Where(
                         i => i.IdIrsTable.Equals(irs.IdIrsTable));
            }
            if (!string.IsNullOrEmpty(irs.IrsTableName))
           {
               irstable = irstable.Where(
                        i => i.IrsTableName.ToLower().Contains(irs.IrsTableName.ToLower()));
           }

            if (!string.IsNullOrEmpty(irs.MarriedStatus))
            {
                irstable = irstable.Where(
                          s => s.MarriedStatus.ToLower().Contains(irs.MarriedStatus.ToLower()));
            }

           // var ano = string.Format("{0:yyyy}", irs.FiscalYear);

            if (!string.IsNullOrEmpty(irs.FiscalYear))
            {
                irstable = irstable.Where(
                          s => s.FiscalYear.ToLower().Contains(irs.FiscalYear.ToLower()));
            }





            if (irs.Salary > 0)


            {
              irstable  = irstable.Where(
                         i => i.Salary.Equals(irs.Salary));
            }
            if (irs.NumDep >= 0)


            {
                irstable = irstable.Where(
                         i => i.NumDep.Equals(irs.NumDep));
            }
            if (irs.IrsTax > 0)


            {
                irstable = irstable.Where(
                         i => i.IrsTax.Equals(irs.IrsTax));
            }



            return await irstable.ToListAsync();
        }


        // PUT: api/IrsTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIrsTable(int id, IrsTable irsTable)
        {
            if (id != irsTable.IdIrsTable)
            {
                return BadRequest();
            }

            _context.Entry(irsTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IrsTableExists(id))
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

        // GET: api/IrsTables/5
        [HttpGet("{idIrsTable}")]
        public async Task<ActionResult<IrsTable>> GetIrsTable(int idIrsTable)
        {
            var irsTable = await _context.IrsTable.FindAsync(idIrsTable);

            if (irsTable == null)
            {
                return NotFound();
            }

            return irsTable;
        }
        // POST: api/IrsTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IrsTable>> PostIrsTable(IrsTable irsTable)
        {
            _context.IrsTable.Add(irsTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IrsTableExists(irsTable.IdIrsTable))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIrsTable", new { id = irsTable.IdIrsTable }, irsTable);
        }

        // DELETE: api/IrsTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IrsTable>> DeleteIrsTable(int id)
        {
            var irsTable = await _context.IrsTable.FindAsync(id);
            if (irsTable == null)
            {
                return NotFound();
            }

            _context.IrsTable.Remove(irsTable);
            await _context.SaveChangesAsync();

            return irsTable;
        }

        private bool IrsTableExists(int id)
        {
            return _context.IrsTable.Any(e => e.IdIrsTable == id);
        }
    }
}
