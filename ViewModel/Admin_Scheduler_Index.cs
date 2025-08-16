using System.ComponentModel.DataAnnotations;

namespace EcdlBooking.ViewModel
{
    public class Admin_Scheduler_Index
    {
        [Display(Name = "Codice Esame ")]
        public Guid id { get; set; }

        [Display(Name = "Nome Studente ")]
        public string NomeStudente { get; set; }

        [Display(Name = "Cognome Studente ")]
        public String CpgnomeStudente { get; set; }

        [Display(Name = "Data Dell' esame")]
        public DateTime Data { get; set; } // Data del Esame

        [Display(Name = "Ora del esame")]
        public DateTime Ora { get; set; } // ora Del Esame

        [Display(Name = "Scuola")]
        public string Luogo { get; set; } // puo contenere solo valori Aperti Chiuso

        [Display(Name = "Tipo Esame")]
        public String LuogoEsame { get; set; }

        [Display(Name = "Voto")]
        public float Voto { get; set; }
    }
}
