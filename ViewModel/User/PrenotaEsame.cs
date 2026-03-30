using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EcdlBooking.ViewModel.User
{
    public class PrenotaEsame
    {
        public String IdStudente { get; init; }
        public Guid IdEsame { get; init; }
        public Guid IdModulo { get; init; }
        public ApplicationUser Studente { get; set; }
        public Exam Esame { get; set; }
        public Modulo Modulo { get; set; }

        [ValidateNever]
        [Display(Name = "Modulo")]
        public List<SelectListItem> ListaModuli { get; set; }

    }
}
