using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;

namespace EcdlBooking.ViewModel
{
    public class InputModel
    {


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        // Numero Di telefono implementato da me in quanto
        // non impementato dalllo scaffolden
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numero Di Telefono")]
        public string PhoneNumber { get; set; }



        // Inizio dell utente 
        //[Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        //[Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Cognome")]
        public string Surname { get; set; }

        //            [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data di Nascita")]
        public DateTime Born { get; set; } = DateTime.Now;

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Indirizzo")]
        public string Address { get; set; }

        //            [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Città")]
        public string City { get; set; }

        //            [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Paese")]
        public string Country { get; set; }

        //            [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Nome Genitori")]
        public string familyContactPerson { get; set; }

        //            [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Genitore-Tel")]
        public string familyContactPerson_phone { get; set; }

        //            [Required]
        //[StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [EmailAddress] 
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Genitore-Mail")]
        public string familyContactPerson_email { get; set; }

        /// Iserito in quanto non considerato nell implementazione
        /// dell utente user standard


        // Relativo all id della scuola
        //[ValidateNever]
        public String IdSchool { get; set; }
        
        //Aggiungere quà
        [ValidateNever]
        [Display(Name = "Scuole")]
        public List<SelectListItem> ListSchool { get; set; }
        [ValidateNever]
        public School School { get; set; }
    }
}

/*
 * Classe utilizzata per fare il binding dati nella pagina 
di registrazione delll utente.
*/