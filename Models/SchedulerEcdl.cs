using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.Models
{
    public class SchedulerEcdl
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string IdTeacher { get; set; }

        public SessionType Session { get; set; }

    }
}
