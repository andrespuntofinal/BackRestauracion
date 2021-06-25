using BackReservas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackReservas
{
    public class AplicationDbContext: DbContext     
    {

        public DbSet<Reserva> Reserva { get; set; }

        public DbSet<Eventos> Eventos { get; set; }


        public AplicationDbContext()
        {


        }

        public AplicationDbContext(DbContextOptions options) : base(options)
        {


        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             if( !optionsBuilder.IsConfigured )
            { 
            optionsBuilder.UseMySql("Server=localhost;Database=ABMReservas;Uid=root;Pwd=Isaias40");

            }
        }

    }
}
