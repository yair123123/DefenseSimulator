using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DefenseSimulator.Models;
using Microsoft.EntityFrameworkCore;

namespace DefenseSimulator.Data
{
    public class DefenseSimulatorContext : DbContext
    {
        public DefenseSimulatorContext (DbContextOptions<DefenseSimulatorContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<States>().HasData(
           new States { Id = 1, Name = "Hamas", Distance = 70 },
           new States { Id = 2, Name = "Hezbollah", Distance = -100 },
           new States { Id = 3, Name = "Houthis", Distance = 2377 },
           new States { Id = 4, Name = "Iran", Distance = 1600 });


           modelBuilder.Entity<Weapon>().HasData(
           new Weapon { WeaponId = 1, Type = "BallisticMissile", Speed = 300 , CounterMeasure  = "ElectronicJamming" },
           new Weapon { WeaponId = 2, Type = "Drone", Speed = 880 , CounterMeasure  = "AntiAirSystem" },
           new Weapon { WeaponId = 3, Type = "Rocket", Speed = 18000 ,  CounterMeasure = "InterceptorMissile" }
       );

            modelBuilder.Entity<Cities>().HasData(
                new Cities { Id = 1, Name = "צפון", Location = -80 },
                new Cities { Id = 2, Name = "מרכז", Location = 0 },
                new Cities { Id = 3, Name = "דרום", Location = 60 });
        }

        public DbSet<Threat> Threat { get; set; } = default!;
        public DbSet<States> States { get; set; } = default!;
        public DbSet<Cities> Cities { get; set; } = default!;
        public DbSet<Response> Response { get; set; } = default!;
        public DbSet<Weapon> Weapon { get; set; } = default!;
        public DbSet<CountTil> CountTil { get; set; } = default!;
    }
}
