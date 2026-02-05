using EcdlBooking.Data;
using EcdlBooking.Data.Migrations;
using EcdlBooking.Models;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using LanguageExt.Pipes;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;



using System.ComponentModel;

namespace EcdlBooking.Configurazione
{
    /// <summary>
    /// Classe che contiene tutte le variabili di configurazione 
    /// del software 
    /// </summary>
    /// 

    public static class Configurazione
    {
        // Scuola Configurazione

        public static String ScuolaNome = "Iti G. Marconi";
        public static string ScuolaIndirizzo = "Via Roma";
        public static String ScuolaCitta = "Rovereto";

        public static String ScuolaNome1 = "Ite Borsellino";
        public static string ScuolaIndirizzo1 = "Via Pra Delle Suore";
        public static String ScuolaCitta1 = "Brixen/Bressanone";



        // Costanti che definiscono i ruoli delgli utenti

        public const string Studente = "Studente";
        public const string Insegnante = "Insegnante";
        public const string Amministratore = "Amministratore";

        // Configurazione Degli utenti di default

        public static string adminUserName = "gianmarco.lunardi@iid-bressanone.edu.com";
        public static string adminEmail = "gianmarco.lunardi@iid-bressanone.edu.com";
        public static string adminNome = "Gianmarco";
        public static string adminCognome = "Lunardi";
        public static string adminPws = "Admin";

       
        public static List<string> ListaRuoli = new List<string> { Studente, Insegnante, Amministratore };

        public enum ListaEsami
        {
            [Description("Esame Uno")]
            EsameUno,
            [Description("Esame Due")]
            EsameDue,
            [Description("Esame Tre")]
            EsameTre ,
        }

        public async static Task SeedAsync(IServiceProvider services)
        {

            using var scope = services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


            // Applica automaticamente le migrazioni
           // await context.Database.MigrateAsync();



            // Seeding Degli della scuole
            if (!context.Schools.Any())
            {
                context.Schools.AddRange(
                    new School
                    {
                        Id = Guid.Parse("a361e1b4-5427-463c-abc8-f2f176821181"),
                        Name = "ITE LICEO Falcone Borsellino",
                        Address = "Via Pra' delle Suore 1/A",
                        City = "Bressanone"
                    },

                        new School
                        {
                            Id = Guid.Parse("a37260f3-ec66-4787-a60d-2baa24aefa5a"),
                            Name = "FP Enrico Mattei",
                            Address = "Via Pra' delle Suore 1/A",
                            City = "Bressanone"
                        }

                );



                await context.SaveChangesAsync();
            }
            

            //seeding dei moduli dell esamen del ECDL
            if (!context.Moduli.Any())
            {
                context.Moduli.AddRange(
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


                        );// fine addrange

                await context.SaveChangesAsync();






            }

            // seeding dei ruoli
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(

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
            await context.SaveChangesAsync();






            }
            // creazione dell utente
            if (!context.ApplicationUsers.Any())
            {
                // Creazione dell'utente amministratore di default  
                string email = "gianmarco.lunardi@iis-bressanone.edu.it";
                var adminUser = new ApplicationUser
                {
                    //UserName = "Gianmarco_Lunardi",
                    UserName = email,
                    Email = email,
                    Name = "Gianmarco",
                    Surname = "Lunardi",
                    EmailConfirmed = true,
                    IdSchool = Guid.Parse("a361e1b4-5427-463c-abc8-f2f176821181") // Assegna una scuola all'utente amministratore

                };

                var result = await userManager.CreateAsync(adminUser, "Pinuccio10@");
                if (result.Succeeded)
                {
                   var resultRuolo = await userManager.AddToRoleAsync(adminUser, "Insegnante");
                    var resultRuolo2 =await userManager.AddToRoleAsync(adminUser, "Admin");
                    


                }


            }




        }

    }

}


