using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.Models
{
    public class School
    {   
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string? Address { get; set; }
        public string? City { get; set; }


        //public Guid IdClass { get; set; }
        //public IList<Class> Classes { get; set; } = new List<Class>();

        //Relazione con l esame 1:n
        // in una sciuola si possono fare più di un esame
        public List<Exam>? Exam { get; set; } = null;
        


         //Relazione Con La tabella Della Scuole
         public List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();

    }
}
