using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.ViewModel
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages =>
        (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}


// Capitolo 8 pagina 217