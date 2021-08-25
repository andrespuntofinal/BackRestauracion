using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackReservas.Models
{
    public class Reserva
    {

        public int id { get; set; }
        [Required]
        public Int32 identificacion { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string celular { get; set; }
        [Required]
        public DateTime fechaservicio { get; set; }
        [Required]
        public string horario { get; set; }
        [Required]
        public int idevento { get; set; }


    }
}
