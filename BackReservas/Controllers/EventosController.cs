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
    public class EventosController : ControllerBase
    {

        private readonly AplicationDbContext _context;

        public EventosController(AplicationDbContext context)
        {
            _context = context;

        }

        // GET: api/<ReservaController>
        [HttpGet]
        public ActionResult<List<Eventos>> Get()
        {
            try
            {

                var listEventos= _context.Eventos.ToList();
                return Ok(listEventos);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // GET api/<ReservaController>/5
        [HttpGet("{id}")]
        public ActionResult<Eventos> Get(int id)
        {

            try
            {

                var eventos = _context.Eventos.Find(id);
                if (eventos == null)
                {
                    return NotFound();
                }

                return Ok(eventos);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // POST api/<ReservaController>
        [HttpPost]
        public ActionResult Post([FromBody] Eventos eventos)
        {

            try
            {

                _context.Add(eventos);
                _context.SaveChanges();

                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // PUT api/<ReservaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Reserva eventos)
        {
            try
            {

                if (id != eventos.id)
                {
                    return BadRequest();
                }

                _context.Entry(eventos).State = EntityState.Modified;
                _context.Update(eventos);
                _context.SaveChanges();

                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<ReservaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            try
            {

                var eventos = _context.Reserva.Find(id);

                if (eventos == null)
                {
                    return NotFound();
                }

                _context.Remove(eventos);
                _context.SaveChanges();


                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
