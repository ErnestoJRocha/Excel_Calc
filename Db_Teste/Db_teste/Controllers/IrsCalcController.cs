using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Db_teste.Models;
using System.Text.Encodings.Web;
using System.Linq;
using System.Text.RegularExpressions;
using Db_teste.Auxiliar;
using Db_teste.FE;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Db_teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IrsCalcController : ControllerBase
    {
        private readonly syfidbContext _context;
        private readonly Timesheet_DevDbContext _timesheetContext;

        public IrsCalcController(syfidbContext context, Timesheet_DevDbContext timesheetContext)
        {
            _context = context;
            _timesheetContext = timesheetContext;
        }

        // GET: api/irscalc
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Status>>> GetStatus([FromQuery] Status stat)
        //public IEnumerable<string> Get() //Original
        //public List<string> Get() //Original
        //public async Task<ActionResult<string>> GetList()

        //public async Task<List<Contentor>> GetList()
        //public async Task<List<IQueryable<BaseData>>> GetList()

        /*
        public string Get() //Original
        {
            var v = "";
            return  v;
        }
        */

        /*
        // GET api/irscalc/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST api/irscalc
        [HttpPost]
        //public void Post([FromBody] string value)
        public async Task<ActionResult<IrsCalcResp>> PostIrsCalc(IrsCalc irsCalc)
        {
            var area = irsCalc.Area;
            var level = irsCalc.Nivel;
            var maritalStatus = irsCalc.maritalStatus;
            var dependents = irsCalc.dependents;
            var salary = _timesheetContext.Nivel.Where(p => p.Nivelid == level).Select(p => p.Vencimento).First();
            int irstable = _context.Status.Where(s => s.Id == maritalStatus).Select(s => s.IrsTable).First();
            var irs = _context.IrsTable
                            .Where(itx => itx.IdIrsTable == irstable)
                            //.Where(itx => itx.Salary <= (decimal)TotalGrossSalary)
                            .Where(itx => itx.Salary <= salary)
                            .Where(itx => itx.NumDep == dependents)
                            .OrderByDescending(itx => itx.Salary)
                            .Select(itx => itx.IrsTax)
                            .FirstOrDefault();
            IrsCalcResp resp = new IrsCalcResp() { BaseSalary = (decimal)salary, Irs = irs };
            return resp;

        }

        /*
        // PUT api/irscalc/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/irscalc/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
