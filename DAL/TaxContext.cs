using congestion.calculator.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.DAL
{
    public class TaxContext : DbContext
    {
        public DbSet<TaxTime> TaxTimes { get; set; }
        public DbSet<Holidays> Holidays { get; set; }

        public TaxContext(DbContextOptions<TaxContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Tax_Calculator;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Data
            modelBuilder.Entity<Holidays>().HasData(
            new Holidays { Id = 1, Date = new DateTime(2013, 1, 1) },
            new Holidays { Id = 2, Date = new DateTime(2013, 3, 28) },
            new Holidays { Id = 3, Date = new DateTime(2013, 3, 29) },
            new Holidays { Id = 4, Date = new DateTime(2013, 4, 1) },
            new Holidays { Id = 5, Date = new DateTime(2013, 4, 30) },
            new Holidays { Id = 6, Date = new DateTime(2013, 5, 1) },
            new Holidays { Id = 7, Date = new DateTime(2013, 5, 8) },
            new Holidays { Id = 8, Date = new DateTime(2013, 5, 9) },
            new Holidays { Id = 9, Date = new DateTime(2013, 6, 5) },
            new Holidays { Id = 10, Date = new DateTime(2013, 6, 6) },
            new Holidays { Id = 11, Date = new DateTime(2013, 6, 21) },
            new Holidays { Id = 12, Date = new DateTime(2013, 7, 1) },
            new Holidays { Id = 13, Date = new DateTime(2013, 11, 1) },
            new Holidays { Id = 14, Date = new DateTime(2013, 12, 24) },
            new Holidays { Id = 15, Date = new DateTime(2013, 12, 25) },
            new Holidays { Id = 16, Date = new DateTime(2013, 12, 26) },
            new Holidays { Id = 17, Date = new DateTime(2013, 12, 31) }
        );

            modelBuilder.Entity<TaxTime>().HasData(
              new TaxTime { Id = 1, StartHour = 6, StartMinute = 0, EndHour = 6, EndMinute = 29, Tax = 8 },
              new TaxTime { Id = 2, StartHour = 6, StartMinute = 30, EndHour = 6, EndMinute = 59, Tax = 13 },
              new TaxTime { Id = 3, StartHour = 7, StartMinute = 0, EndHour = 7, EndMinute = 59, Tax = 18 },
              new TaxTime { Id = 4, StartHour = 8, StartMinute = 0, EndHour = 8, EndMinute = 29, Tax = 13 },
              new TaxTime { Id = 5, StartHour = 8, StartMinute = 30, EndHour = 14, EndMinute = 59, Tax = 8 },
              new TaxTime { Id = 6, StartHour = 15, StartMinute = 0, EndHour = 15, EndMinute = 29, Tax = 13 },
              new TaxTime { Id = 7, StartHour = 15, StartMinute = 30, EndHour = 16, EndMinute = 59, Tax = 18 },
              new TaxTime { Id = 8, StartHour = 17, StartMinute = 0, EndHour = 17, EndMinute = 59, Tax = 13 },
              new TaxTime { Id = 9, StartHour = 18, StartMinute = 0, EndHour = 18, EndMinute = 29, Tax = 8 }
           );
        }
    }
}
