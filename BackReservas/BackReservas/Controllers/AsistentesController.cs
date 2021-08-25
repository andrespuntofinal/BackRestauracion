using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackReservas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackReservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistentesController : ControllerBase

         
    {


        private AplicationDbContext db = new AplicationDbContext();

        private readonly AplicationDbContext _context;

        public AsistentesController(AplicationDbContext context)
        {
            _context = context;

        }

     

        // GET: api/<AsistentesController>
        [HttpGet]
        public ActionResult<List<Reserva>> Get()
        {

            try
            {
                //string queryString = "SELECT A.*,totalA FROM  abmreservas.eventos A left join ( select idevento, count(idevento) As totalA from abmreservas.reserva group by idevento ) B ON A.id = B.idevento group by id";

                //var listReserva = db.Database.ExecuteSqlCommand("SELECT A.id, A.nombreevento, A.descripcionevento, A.asistentesevento, A.fechaevento, A.horarioevento,A.estadoevento,B.identificacion  From abmreservas.eventos A inner join abmreservas.reserva B on A.id=B.idevento");

                //  .FromSqlRaw("SELECT A.id, A.nombreevento, A.descripcionevento, A.asistentesevento,A.fechaevento, A.horarioevento,A.estadoevento,totalA FROM  abmreservas.eventos A left join ( select idevento, count(idevento) As totalA from abmreservas.reserva group by idevento ) B ON A.id = B.idevento group by id")
                // .ToList();

                //var listReserva = _context.Reserva.ToList();

                var listReserva = (from ev in db.Eventos
                                   join re in db.Reserva on ev.id equals re.idevento

                                   select new { re.idevento, ev.fechaevento, ev.horarioevento, ev.asistentesevento, ev.nombreevento } into q

                                   group q by q.idevento into w


                                   
                                       select new
                                       {
                                           idevento = w.Key,
                                           asistentes = w.Count(),
                                           nombreevento = w.Max( x=> x.nombreevento),
                                           fechaevento = w.Max(x => x.fechaevento),
                                           horarioevento = w.Max(x => x.horarioevento),
                                           cupooevento = w.Max(x => x.asistentesevento)


                                         
                                       }
                                       
                                       
                                       );

                
                
              
                return Ok(listReserva);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        // GET api/<AsistentesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AsistentesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AsistentesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AsistentesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
