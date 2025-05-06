using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.Models
{
    public class SessionType
    {
        [Key]
        public Guid Id { get; set; } 
        public string TypeIt { get; set; }
        public string TypeDe { get; set; }
    }
}
