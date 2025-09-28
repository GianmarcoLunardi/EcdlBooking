using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.Models
{
    public class Class
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        // attributo che desctive il nome della classe nella scuola
        public string Name { get; set; }


        public Guid SchoolId { get; set; }
        public School School { get; set; }
         // Required reference navigation to principal
    }
}