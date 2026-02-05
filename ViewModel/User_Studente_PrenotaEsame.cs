using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcdlBooking.ViewModel
{
    public class User_Studente_PrenotaEsame
    {

        public Guid Id { get; set; }
        public DateTime DataPrenotazione { get; set; }

        //public Guid IdStudente { get; set; }
        public ApplicationUser Studente { get; set; }
        public Guid IdStudente { get; set; }

        public Guid IdEsame { get; set; }
     
        public Exam Exam { get; set; }

        public Guid? IdModulo { get; set; }
        public Modulo? Modulo { get; set; }

        [ValidateNever]
        [Display(Name = "Modulo")]
        public List<SelectListItem> ListaModuli { get; set; }

    }
}
