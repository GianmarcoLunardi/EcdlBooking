using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EcdlBooking.ViewModel
{
    public class Admin_Users_User
    {

        [Key]
            [Display(Name = "Codice Identificativo")]
            public string Id { get; set; }

            [Required(ErrorMessage = "Inserire nome Utente")]
            [Display(Name = "Nome Utente")]
            public string UserName { get; set; }
        

            [Required(ErrorMessage = "Inserire una mail")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Key]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            [ValidateNever]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            [ValidateNever]
            public string ConfirmPassword { get; set; }


            // Numero Di telefono implementato da me in quanto
            // non impementato dalllo scaffolden
            //            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Numero Di Telefono")]
            public string PhoneNumber { get; set; }



            // Inizio dell utente 
            //[Required]
            [StringLength (20 , MinimumLength = 3, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
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
            public DateTime Born { get; set; }

            //            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
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
        
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Genitore-Mail")]
            public string familyContactPerson_email { get; set; }
     
        /// Iserito in quanto non considerato nell implementazione
        /// dell utente user standard

        // Caticamento della scuola a cui appartienen l utente
        [ValidateNever]
        public School School { get; set; }


        // Relativo all id della scuola relativo al listmenu
        [Display(Name = "Scuola")]
        public Guid IdSchool { get; set; }
        [ValidateNever]
        public List<SelectListItem> ListSchool { get; set; } = null;
     

        // Ruolo dell utente



        // Menu Dei Ruoli
        [ValidateNever]
        [Display(Name = "Ruoli")]
        public List<SelectListItem> ListRuoli { get; set; } = null;


        // Sono i diversi id dei ruoli coperti dall utente
        [ValidateNever]
        public IList<string> IdRuoli { get; set; } = null;




    }
}
