using EcdlBooking.Models;
using Microsoft.AspNetCore.Identity;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
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
            EsameTre
        }




        private async static Task SeedStore(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                //IConfiguration config =
                //scope.ServiceProvider.GetService<IConfiguration>();
                UserManager<ApplicationUser> userManager =
                scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                RoleManager<IdentityRole> roleManager =
                scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                /*
                string roleName = config["Dashboard:Role"] ?? "Dashboard";


                string userName = config["Dashboard:User"] ?? "admin@example.com";
                string password = config["Dashboard:Password"] ?? "mysecret";
                */






                // Inserimento della Scuola di default

                School Scuola = new School
                {
                    Name = ScuolaNome,
                    Address = ScuolaIndirizzo,
                    City = ScuolaIndirizzo
                };



                // inserimento di una scula di setup 

                /*
                ApplicationUser? Utente = await userManager.FindByEmailAsync("gianmarco.lunardi@iis-bressanone.edu.it");
                if (Utente == null)
                {
                    Utente = new ApplicationUser
                    {
                        UserName = Configurazione.UtenteUser,
                        Name = Configurazione.UtenteNome,
                        Surname = Configurazione.UtenteCognome,
                        Email = Configurazione.EmailUser,   // inserire una mail di configurazione
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(Utente);
                    Utente = await userManager.FindByEmailAsync("gianmarco.lunardi@iis-bressanone.edu.it");
                    
                    await userManager.AddPasswordAsync(Utente, "admin");

                    if (!await userManager.IsInRoleAsync(Utente, Configurazione.Insegnante))
                    {
                        await userManager.AddToRoleAsync(Utente, Configurazione.Insegnante);
                    }
                    
                }

                */
            }
        }
    }
}



    