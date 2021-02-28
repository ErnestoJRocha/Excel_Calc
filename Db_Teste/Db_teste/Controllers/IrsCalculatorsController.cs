using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Db_teste.Models;
using Db_teste.Auxiliar;


namespace Db_teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IrsCalculatorsController : ControllerBase
    {
        private readonly syfidbContext _context;
        private readonly Timesheet_DevDbContext _timesheetContext;

        public IrsCalculatorsController(syfidbContext context, Timesheet_DevDbContext timesheetContext)
        {
            _context = context;
            _timesheetContext = timesheetContext;
        }

        // GET: api/IrsCalculators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IrsCalculator>>> GetIrsCalculator()
        {
            return await _context.IrsCalculator.ToListAsync();
        }

        // GET: api/IrsCalculators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IrsCalculator>> GetIrsCalculator(int id)
        {
            var irsCalculator = await _context.IrsCalculator.FindAsync(id);

            if (irsCalculator == null)
            {
                return NotFound();
            }

            return irsCalculator;
        }

        // PUT: api/IrsCalculators/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIrsCalculator(int id, IrsCalculator irsCalculator)
        {

            //CalculatorData cd = new CalculatorData(irsCalculator, _context, _timesheetContext);

            if (id != irsCalculator.Id)
            {
                return BadRequest();
            }

            _context.Entry(irsCalculator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IrsCalculatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //return Ok(cd);
        }

        // POST: api/IrsCalculators
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //public async Task<ActionResult<IrsCalculatorOLD>> PostIrsCalculator(IrsCalculatorOLD irsCalculator)
        public async Task<ActionResult<IrsCalculator>> PostIrsCalculator(IrsCalculator irsCalculator)
        {

            // Validar dados recebidos


            // Validar se a area do nivel seleccionado no IRSCalc corresponde a uma area 
            /*
            var level = irsCalculator.PickLevel;
            var area = _context.PositionLevel.Where(p=> p.NivelId == irsCalculator.PickLevel).Select(p => p.AreaId);
            //var area = _timesheetContext.Nivel.Where(n=> n.Nivelid == irsCalculator.PickLevel).Select(n => n.Shortdesc);
            if (irsCalculator.PickArea != area.First())
                return NotFound("Nivel/Posição não corresponde à area escolhida.");
            */

            /*  
             *  *************
             *  Carrega dados
             *  *************
            */

            //CalculatorData cd = new CalculatorData(irsCalculatorOLD, _context, _timesheetContext ) ;


            //_context.Position.Where(p => p.AreaId = irsCalculator.PickLevel)

            // from a in _context.Position
            //select new BaseData()
            //{
            //    Id = a.Id,
            //    Description = a.AreaName
            //};

            //Actualizar registo
            _context.IrsCalculator.Add(irsCalculator);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IrsCalculatorExists(irsCalculator.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            
          return CreatedAtAction("GetIrsCalculator", new { id = irsCalculator.Id }, irsCalculator);
          //return CreatedAtAction("GetIrsCalculator", new { id = irsCalculator.Id }, cd);
        }

        // DELETE: api/IrsCalculators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IrsCalculator>> DeleteIrsCalculator(int id)
        {
            var irsCalculator = await _context.IrsCalculator.FindAsync(id);
            if (irsCalculator == null)
            {
                return NotFound();
            }

            _context.IrsCalculator.Remove(irsCalculator);
            await _context.SaveChangesAsync();

            return irsCalculator;
        }

        private bool IrsCalculatorExists(int id)
        {
            return _context.IrsCalculator.Any(e => e.Id == id);
        }
    }
}
