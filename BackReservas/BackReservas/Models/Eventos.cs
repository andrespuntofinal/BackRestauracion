using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackReservas.Models
{
    public class Eventos
    {

        public int id { get; set; }
        [Required]
        public string nombreevento { get; set; }
        [Required]
        public string descripcionevento { get; set; }
        [Required]
        public int asistentesevento { get; set; }
        [Required]
        public DateTime fechaevento { get; set; }
        [Required]
        public string horarioevento { get; set; }
        [Required]
        public int estadoevento { get; set; }

    }
}
