using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.Models
{

    // da non considerare in quanti ci sono già quelle di IdentityRole
    public class AppRole
    {
     
        public string Id { get; set;}// = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string NormalizedName { get; set; }

    }
}
