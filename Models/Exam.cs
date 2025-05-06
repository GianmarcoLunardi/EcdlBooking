using EcdlBooking.Models;
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
        public DateTime Date { get; set; }
        public SessionType SessionType { get; set; }
        public Boolean Bookable { get; set; }

        //TestPoint 
        // relazione alla scuola dove verrà fatto l esame3
        public School School { get; set; }
        public Guid IdSchool { get; set; }

        // Relazione sull Esaminatore
        // un saminatore può fare un solo esame

        [ForeignKey(nameof(ApplicationUser.Id))]
        public Guid ExaminerId { get; set; }
        public ApplicationUser Examiner { get; set; }
        // inserimento delli lista 


    }
}
