using EcdlBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.ViewModel
{
    public class CreateClassSchool
    {
        public Guid  Id_School{ get; set; }
        public string Nome { get; set; }
        public string? indirizzo { get; set; }
        public string? City { get; set; }


    }
}
