using EcdlBooking.Configurazione;
using EcdlBooking.Data.Migrations;
using EcdlBooking.Models;
using EcdlBooking.Models;
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
            //Creazione di un amministrato

            // inserimento della PWS
            var hasher = new PasswordHasher<ApplicationUser>();


            var Amministrattore = new ApplicationUser
            {
                Id = "9f5de216-b03f-43d2-b0a1-4f9d6bb5c126",
                UserName = "Gianmarco_Lunardi",
                NormalizedUserName = "Gianmarco_Lunardi".ToUpper(),
                Email = "gianmarco.lunardi@iis-bressanone.edu.com",
                NormalizedEmail = "gianmarco.lunardi@iis-bressanone.edu.com".ToUpper(),
                IdSchool = Guid.Parse("a361e1b4-5427-463c-abc8-f2f176821181"),
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEJk1vQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQw==",
                //PasswordHash = Admin,  
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                SecurityStamp = "72a47951-3867-403d-9ee8-eaad38b9d269",
                ConcurrencyStamp = "1e569cc1-d487-4a7d-a1ac-39274065eb42",
                //LockoutEnabled = false,
                // = 0,
                Esami = null
            };
            

            //seeding della scuola

            modelBuilder.Entity<School>().HasData(

                new School { Id = Guid.Parse("a361e1b4-5427-463c-abc8-f2f176821181"),
                            Name ="ITE LICEO Falcone Borsellino",
                            Address = "Via Pra' delle Suore 1/A",
                            City = "Bressanone" },

                 new School{Id = Guid.Parse("a37260f3-ec66-4787-a60d-2baa24aefa5a"),
                            Name = "FP Enrico Mattei",
                            Address = "Via Pra' delle Suore 1/A",    
                            City = "Bressanone"}
                );

            
            // seeding dei ruolo

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "26723492-169e-4ef7-941c-fa87c060d0d8",
                    Name = "Studente",
                    NormalizedName = "Studente".ToUpper()
                },
                new IdentityRole
                {
                    Id= "7a4edc4a-6ad0-466b-929c-73a8f769fa5e",
                    Name = "Insegnante",
                    NormalizedName = "Insegnante".ToUpper(),
                },
                new IdentityRole
                {
                    Id = "2a1447a0-8c6a-46e9-b187-25a28e8da50e",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
                );

            // Seeding Di un  dell amministratore
            modelBuilder.Entity<ApplicationUser>().HasData(Amministrattore);

            
            modelBuilder.Entity<Modulo>().HasData(

                new Modulo
                {
                    Id = Guid.Parse("94f1d7b2-232b-4542-a395-98f97c371326"),
                    Nome = "Computer Essentials",
                    
                },

                 new Modulo
                 {
                     Id = Guid.Parse("c2642c79-1742-47a8-a7aa-18eb853b1906"),
                     Nome = "Online Essentials",

                 },
                new Modulo
                {
                    Id = Guid.Parse("2f67549b-efd9-4fb7-a84e-4837e519b925"),
                    Nome = "Word Processing",

                },
                new Modulo
                {
                    Id = Guid.Parse("ff8dc93f-98b5-4f0e-a19b-5e7b85df3bdd"),
                    Nome = "Spreadsheet",

                },
                new Modulo
                {
                    Id = Guid.Parse("a6d7b193-df8f-4691-9ea7-260dbd6c985c"),
                    Nome = "Presentation",

                },
                new Modulo
                {
                    Id = Guid.Parse("c009dd27-ce86-4f24-80a1-f453e5a7612d"),
                    Nome = "Online Collaboration",

                },
                new Modulo
                {
                    Id = Guid.Parse("663f6c0f-6843-4ddf-af2b-bd96503d1dbb"),
                    Nome = "Database",

                }
            );
            
           


        }

        // Schema Relazionale Della Base Dati
        // https://dbdiagram.io/d/Diagramma-Booking-ECDL-68cc48c45779bb7265234be5

        // Tabelle 
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<School> Schools { get; set; }
        //public DbSet<Class> classes { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<IdentityRole> Ruoli { get; set; }

        public DbSet<ApplicationUser> Utenti { get; set; }

        public DbSet<SchedulerEcdl> SchedulerExams { get; set; }
        public DbSet<Modulo> Moduli { get; set; }
    }
}

