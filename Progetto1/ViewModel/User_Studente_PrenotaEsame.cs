using EcdlBooking.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcdlBooking.ViewModel
{
    public class User_Studente_PrenotaEsame
    {

        public Guid id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Ora { get; set; } // ora Del Esame
        public string TipoSessione { get; set; }

        // Con questa relazione si indica in quale scuola si fa l esame in una scuola

        
        public Guid IdSchool { get; set; }
        public School School { get; set; }

        //Relazione com L Esaminatore
        // Un  esame viene fatto da un esaminatore
        
        public Guid IdEsaminatore { get; set; }
        
    }
}
