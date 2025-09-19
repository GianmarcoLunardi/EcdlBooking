using EcdlBooking.Models;
using EcdlBooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EcdlBooking.Configurazione;

namespace EcdlBooking.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<School>().HasData(

                new School { 
                    id = Guid.Parse("dd0cd38b-05f8-4a60-a737-db4f6508821d"),
                    Name = "ITE Liceo Falcone Borsellino", 
                    Address = "Via Pra Delle Suore, 1",
                    City = "Bressanone"
                } ,

                new School{
                           id = Guid.Parse("06d1a270-017a-48b9-9d2c-367183f4353f"),
                           Name = "Professionale Enrico Mattei",
                           Address = "Via Pra Delle Suore, 1",
                           City = "Bressanone"
                           }
                );

            // seeding Dei Ruoli
            // www.https://www.guidgenerator.com/

            modelBuilder.Entity<IdentityRole>().HasData(

                new IdentityRole
                {
                    Id = "b61c4c2d-7615-4356-9b70-c956e250474e",
                    Name = Configurazione.Configurazione.Studente,
                    NormalizedName = Configurazione.Configurazione.Studente.ToUpper()
                },

                new IdentityRole
                {
                    Id = "28d79f41-8a12-4dce-a2a5-17494c694efb",
                    Name = Configurazione.Configurazione.Insegnante,
                    NormalizedName = Configurazione.Configurazione.Insegnante.ToUpper()
                },

                new IdentityRole
                {
                    Id = "03f23bce-7b4a-44a3-901b-fa8422783215",
                    Name = Configurazione.Configurazione.Amministratore,
                    NormalizedName = Configurazione.Configurazione.Amministratore.ToUpper()
                }

                );

                // Seeding delle utente
                var passwordHasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                                    new ApplicationUser {

                                        Id = "00e0f514-5ee4-4ee3-811d-ce83bcafd51a",

                                        UserName = Configurazione.Configurazione.UtenteNome,
                                        NormalizedUserName = Configurazione.Configurazione.UtenteUser.ToUpper(),

                                        Name = Configurazione.Configurazione.UtenteNome,
                                        Surname = Configurazione.Configurazione.UtenteCognome,

                                        IdSchool = Guid.Parse("dd347642-8111-4e1c-96b9-ff32abc7daa9"),

                                        Email = Configurazione.Configurazione.EmailUser,
                                        NormalizedEmail = Configurazione.Configurazione.EmailUser.ToUpper(),

                                        EmailConfirmed = true,
                                        PasswordHash = passwordHasher.HashPassword(null, "admin")
                                    }
                                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                                   new IdentityUserRole<string>
                                   {
                                      RoleId = "03f23bce-7b4a-44a3-901b-fa8422783215", // Amministratore
                                      UserId = "00e0f514-5ee4-4ee3-811d-ce83bcafd51a"
                                   }
                               );
          
        }

  
        // Tabelle 
      
        public DbSet<School> Schools { get; set; }
        //public DbSet<Class> classes { get; set; }  // non usare

        public DbSet<Exam> Exams { get; set; }

        public DbSet<IdentityRole> Ruoli { get; set; }

        public DbSet<ApplicationUser> Utenti { get; set; }

        public DbSet<SchedulerEcdl> SchedulerExams { get; set; }
      
    }


}
