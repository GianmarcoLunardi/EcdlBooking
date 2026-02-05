using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.Models
{
    public class SchedulerEcdl
    {
        //Tabella Delle Prenotazioni Di tutti Gli Studenti
        public Guid Id { get; set; }
        public DateTime DataPrenotazione { get; set; }

        //relazione con studente
        public Guid IdStudente { get; set; }
        public ApplicationUser Studente { get; set; }


        public  Guid IdEsame { get; set; }
        public Exam Exam { get; set; }

        public Guid IdModulo { get; set; }
        public Modulo Modulo { get; set; }

        public float voto { get; set; }// numero negativo 

    }
}
