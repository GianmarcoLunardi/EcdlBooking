using EcdlBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.ViewModel
{
    public class CreateSelectionView
    {
        public Exam exam { get; set; }
        //public IEnumerable<SessionType> sessionList { get; set; }
        public Guid sessionId { get; set; }
    }
}
