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
    public class ReservaController : ControllerBase
    {

        private readonly AplicationDbContext _context;

        public ReservaController(AplicationDbContext context)
        {
            _context = context;

        }


        // GET: api/<ReservaController>
        [HttpGet]
        public ActionResult<List<Reserva>> Get()
        {
            try
            {

                var listReserva = _context.Reserva.ToList();
                return Ok(listReserva);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
              
        }

        // GET api/<ReservaController>/5
        [HttpGet("{id}")]
        public ActionResult<Reserva> Get(int id)
        {

            try
            {

                var reserva = _context.Reserva.Find(id);
                if (reserva == null)
                {
                    return NotFound();
                }

                return Ok(reserva);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // POST api/<ReservaController>
        [HttpPost]
        public ActionResult Post([FromBody] Reserva reserva)
        {

            try
            {

                _context.Add(reserva);
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
        public ActionResult Put(int id, [FromBody] Reserva reserva)
        {
            try
            {

                if (id != reserva.id)
                {
                    return BadRequest();
                }

                _context.Entry(reserva).State = EntityState.Modified;
                _context.Update(reserva);
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

                var reserva = _context.Reserva.Find(id);

                if (reserva == null)
                {
                    return NotFound();
                }

                _context.Remove(reserva);
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
