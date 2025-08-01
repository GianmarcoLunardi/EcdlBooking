using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace EcdlBooking.Models { 

    
    public class Exam
    {
        [Key]
        public Guid id {get; set;}
        public DateTime Data { get; set; }
        public DateTime Ora { get; set; } // ora Del Esame
        public string TipoSessione { get; set; }

        // Con questa relazione si indica in quale scuola si fa l esame in una scuola

        [ForeignKey(nameof(School))]
        public Guid IdSchool { get; set; }
        public School School { get; set; }

        //Relazione com L Esaminatore
        // Un  esame viene fatto da un esaminatore
        [ForeignKey(nameof(ApplicationUser))]
        public Guid IdEsaminatore { get; set; } 
        public ApplicationUser Esaminatore { get; set; }    


    }
}
        // Relazione sull Esaminatore
        // un saminatore può fare un solo esame
        /*
        [ForeignKey(nameof(ApplicationUser.Id))]
        public Guid ExaminerId { get; set; }
        public ApplicationUser Examiner { get; set; }
        */

        /*
        [ForeignKey(nameof(ApplicationUser.Id))]
        public Guid EsaminatoreId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        */
        //  relazione alla scuola dove verrà fatto l esame