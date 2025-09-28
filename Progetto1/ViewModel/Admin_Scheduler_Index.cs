using Microsoft.AspNetCore.Mvc.Rendering;
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
        public String CognomeStudente { get; set; }



        public Guid IdStudente { get; set; }

        [Display(Name = "Data Dell' esame")]
        public DateTime Data { get; set; } // Data del Esame

        [Display(Name = "Ora del esame")]
        public DateTime Ora { get; set; } // ora Del Esame

        [Display(Name = "Scuola")]
        public string Luogo { get; set; } // puo contenere solo valori Aperti Chiuso

        // Lista A Tendina Deglie Esami
        public String TipoEsame { get; set; }


        [Display(Name = "Tipo Esame")]
        public String LuogoEsame { get; set; }

        [Display(Name = "Voto")]
        public List<SelectListItem> MenuEsami { get; set; }
        public float Voto { get; set; }

        //Chiavi esterne per eventuali ricerche

        public Guid ExamId { get; set; }
        public Guid SchoolId { get; set; }
    }
}
