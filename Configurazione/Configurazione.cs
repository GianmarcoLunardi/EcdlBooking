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


        // Costanti che definiscono i ruoli delgli utenti

        public const string Studente = "Studente";
        public const string Insegnante = "Insegnante";
        public const string Amministratore = "Amministratore";

        // Configurazione Degli utenti di default

        public static string UtenteUser = "Admin";
        public static string UtenteNome = "Gianmarco";
        public static string UtenteCognome = "Lunardi";
        public static string UtentePws = "Admin";
        public static string EmailUser = "gianmarco.lunardi@iid-bressanone.edu.it";






    }
}



    