using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Db_teste.Models;
using System.Text.Encodings.Web;
using System.Linq;
using System.Text.RegularExpressions;
using Db_teste.Auxiliar;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Db_teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDataController : ControllerBase
    {
        private readonly syfidbContext _context;
        private readonly Timesheet_DevDbContext _timesheetContext;

        public BaseDataController(syfidbContext context, Timesheet_DevDbContext timesheetContext)
        {
            _context = context;
            _timesheetContext = timesheetContext;
        }

        // GET: api/basedata
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Status>>> GetStatus([FromQuery] Status stat)
        //public IEnumerable<string> Get() //Original
        //public List<string> Get() //Original
        //public string Get() //Original
        //public async Task<ActionResult<string>> GetList()

        public async Task<List<Contentor>> GetList()
        //public async Task<List<IQueryable<BaseData>>> GetList()
        //public async Task<ActionResult<List<string>>> GetList() //OLD
        {

            
            List < IQueryable < BaseData >> final = new List< IQueryable < BaseData >> ();

            // *** OLD ***
            //List<string> final = new List<string>(); //OLD
            // Areas
            //final.Add(JsonSerializer.Serialize(_context.Areas.ToList()).Replace(@"\", ""));

            // Marital Status
            //final.Add(JsonSerializer.Serialize(_context.Status.ToList()).Replace(@"\", ""));

            // Dependents
            //final.Add(JsonSerializer.Serialize(_context.Dependents.ToList()).Replace(@"\", ""));

            // Car Type
            //final.Add(JsonSerializer.Serialize(_context.CarType.ToList()).Replace(@"\", ""));

            // Level / Position
            //final.Add(JsonSerializer.Serialize(_context.Position));
            //final.Add(JsonSerializer.Serialize(_context.Position.ToList()).Replace(@"\", ""));
            //final.Add(JsonSerializer.Serialize(_timesheetContext.Nivel.ToList()).Replace(@"\", ""));

            // Employees
            //final.Add(JsonSerializer.Serialize(_context.Employees));
            //final.Add(JsonSerializer.Serialize(_context.Employees.ToList()).Replace(@"\", ""));

            //return final;



            //// *** NEW ***
            //// Areas
            //List<Areas> listArea = new List<Areas>();
            ////var areas = _context.Areas;

            List<IQueryable<BaseData>> lstBD = new List<IQueryable<BaseData>>();
            //IQueryable<BaseData> titulo = new IQueryable<BaseData>;
            //List<string> lstBD = new List<string>();

            //
            /*
            //lista.Add("-------- Areas -------- ");
            //foreach (var a in _context.Areas)
            //{

            //    BaseData bd = new BaseData();
            //    bd.Id = a.Id;
            //    bd.Description = a.AreaName;
            //}

            //foreach (var s in _context.Status)
            //{
            //    bd.Id = s.Id;
            //    bd.Description = s.MaritalStatus;
            //}
            //*/



            // *** Areas ***

            //titulo.Description = "Areas";
            List<Contentor> c = new List<Contentor>();
            
            //var areas = from a in _context.Areas
            //            select new BaseData()
            //            {
            //                Id = a.Id,
            //                Description = a.AreaName
            //            };

            //c.Add(new Contentor() { Titulo = "Areas", Lista = areas, Tabela = _context.Areas });
            c.Add(new Contentor() { Titulo = "Areas", Tabela = _context.Areas });

            // *** Level by Area ***
            Object Level = new Object();

            List<LevelArea> Lba = new List<LevelArea>();

            foreach (var a in _context.Areas)
            {
                
                Level = _context.PositionLevel
                    .Where(l => l.AreaId == a.Id)
                    .Select(l => new BaseData()
                    {
                        Id = (int)l.NivelId,
                        Description = l.PositionName
                    });

                Lba.Add( new LevelArea()
                    {
                        AreaId = a.Id,
                        AreaName = a.AreaName,
                        Levels = Level
                    });

            }
            c.Add(new Contentor() { Titulo = "Level by Area", Tabela = Lba });

            // *** Status ***
            //var status = from s in _context.Status
            //             select new BaseData()
            //             {
            //                 Id = s.Id,
            //                 Description = s.MaritalStatus
            //             };
            //c.Add(new Contentor() { Titulo = "Marital Status", Lista = status });
            c.Add(new Contentor() { Titulo = "Marital Status", Tabela = _context.Status });

            // *** Dependents ***
            //var dependents = from d in _context.Dependents
            //             select new BaseData()
            //             {
            //                 Id = d.Id,
            //                 Description = d.DependentsNum.ToString()
            //             };
            //c.Add(new Contentor() { Titulo = "Dependents", Lista = dependents });
            c.Add(new Contentor() { Titulo = "Dependents", Tabela = _context.Dependents });

            // *** Car Type ***
            //var cartype = from cr in _context.CarType
            //                 select new BaseData()
            //                 {
            //                     Id = cr.Id,
            //                     Description = cr.Cartype
            //                 };
            //c.Add(new Contentor() { Titulo = "Car Type", Lista = cartype });
            c.Add(new Contentor() { Titulo = "Car Type", Tabela = _context.CarType });


            // *** PositionLevel ***
            //var positionlevel = from pl in _context.PositionLevel
            //              select new BaseData()
            //              {
            //                  Id = (int)(pl.NivelId),
            //                  Description = pl.PositionName
            //              };
            //c.Add(new Contentor() { Titulo = "Position/Level", Lista = positionlevel });
            c.Add(new Contentor() { Titulo = "Position/Level", Tabela = _context.PositionLevel });

            return c;





            //foreach (var a in areas)
            //{
            //    listArea.Add(a);  // (LinL)
            //}

            //// Marital Status
            //List<Status> listStatus = new List<Status>();
            //var stat = _context.Status;
            ////lista.Add("-------- Marital Status -------- ");
            //foreach (var s in stat)
            //{
            //    //lista.Add(s.Id + " " + s.MaritalStatus);
            //    listStatus.Add(s);  // (LinL)
            //}

            ////final.Add(lista.ToString());
            ////final.Add(listStatus.ToString()); // (LinL)


            //// Dependents
            //List<Dependents> listDependents = new List<Dependents>();
            //var dep = _context.Dependents;
            ////lista.Add("-------- Dependents -------- ");
            //foreach (var d in dep) 
            //{
            //    //lista.Add(d.Id + " " + d.DependentsNum.ToString());
            //    listDependents.Add(d);
            //}

            ////final.Add(lista.ToString());
            ////final.Add(listDependents.ToString()); // (LinL)

            //// Car Type
            //List<CarType> listCarType = new List<CarType>();
            //var car = _context.CarType;
            ////lista.Add("-------- Car Type -------- ");
            //foreach (var c in car) 
            //{
            //    //lista.Add(c.Id + " " + c.NormalKm.ToString()+"- Normal "+ c.PluginKm.ToString() + "- PlugIn ");
            //    listCarType.Add(c);
            //}

            ////final.Add(lista.ToString());
            ////final.Add(listCarType.ToString()); // (LinL)

            //// Level / Position
            //List<Position> listPosition = new List<Position>();
            //var pos = _context.Position;
            //lista.Add("-------- Level/Position -------- ");
            //foreach (var p in pos) 
            //{
            //    //lista.Add(p.Id + " " +p.PositionName);
            //    listPosition.Add(p);
            //}

            ////final.Add(lista.ToString());
            ////final.Add(listPosition.ToString()); // (LinL)

            ////return final; (LinL)
            ////return new List<string> { listarea.ToString(), liststatus.ToString() };
            ////return  lst;//_context.Status.ToListAsync();

            ////var ret = listPosition.ToString();
            ////return ret.ToString();

            //return final;
        }

        /*
        // GET api/<BaseData>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<BaseData>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BaseData>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BaseData>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
