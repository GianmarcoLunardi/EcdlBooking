using EcdlBooking.Configurazione;
using EcdlBooking.Data.Migrations;
using EcdlBooking.Models;
using EcdlBooking.Models;
using LanguageExt.Pipes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace EcdlBooking.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        //seedingIdentityRole dinamico
        // https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/#dbcontextoptions

        // https://www.meziantou.net/entity-framework-core-seed-data-dynamically.htm

        // Seeding

        //https://guidgenerator.com/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        // Schema Relazionale Della Base Dati
        // https://dbdiagram.io/d/Diagramma-Booking-ECDL-68cc48c45779bb7265234be5

        // Tabelle 
        //
        //
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<School> Schools { get; set; }
        //public DbSet<Class> classes { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<IdentityRole> Ruoli { get; set; }

        //public DbSet<ApplicationUser> Utenti { get; set; }

        public DbSet<SchedulerEcdl> SchedulerExams { get; set; }
        public DbSet<Modulo> Moduli { get; set; }
    }
}

