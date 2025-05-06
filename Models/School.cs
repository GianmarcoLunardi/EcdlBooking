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
        public Guid id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } 
        public string Address { get; set; }

        //public List<Class> Classes { get; set; } = new List<Class>();
        public string City { get; set; }


        //public Guid IdClass { get; set; }
        public IList<Class> Classes { get; set; } = new List<Class>();

        public ICollection<Exam> Posts { get; } = new List<Exam>(); // Collection navigation containing dependents


         //Relazione Con La tabella Della Scuole
         public List<ApplicationUser> ApplicationUsers { get; } = new List<ApplicationUser>();

    }
}
