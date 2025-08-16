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
        // Seeding


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<School>().HasData(

                new School { Name = Configurazione.Configurazione.ScuolaNome, City = Configurazione.Configurazione.ScuolaCitta }

                );



        }

        public static async Task CreateAdminAccount(IServiceProvider serviceProvider
)

        {
            UserManager<ApplicationUser> userManager =
            serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            RoleManager<IdentityRole> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();


            string username = "Admin";
            string email = "gianmarcofi@gmail.com";
            string password = "cambiami";
            string role = "Teacher";
            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    // inserisce il ruolo insegnabte
                    await roleManager.CreateAsync(new IdentityRole("Teacher"));

                }

                if (await roleManager.FindByNameAsync("Student") == null)
                {
                    // inserisce il ruolo insegnabte
                    await roleManager.CreateAsync(new IdentityRole("Student"));

                }


                // Creacione dell utente



                ApplicationUser user = new ApplicationUser
                {
                    UserName = username,
                    Email = email
                };

                // Associazione del ruolo all utente

                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);


                }
            }
        }
        // Tabelle 
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<School> Schools { get; set; }
        //public DbSet<Class> classes { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<IdentityRole> Ruoli { get; set; }

        public DbSet<ApplicationUser> Utenti { get; set; }

        public DbSet<SchedulerEcdl> SchedulerExams { get; set; }
    }
}
