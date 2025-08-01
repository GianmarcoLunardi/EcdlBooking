using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.Models
{
    public class SchedulerEcdl
    {
        //Tabella Delle Prenotazioni Di tutti Gli Studenti
        public Guid Id { get; set; }
        public string IdTeacher { get; set; }
        public string IdStudent { get; set; }
        // Chiave Esterna Alla Tabella Esame
        public string IdEsame { get; set; }

        // Colonna dei Voti assume un voto negativo quando l alunno deve ancora 
        // presentarsi all test 
        public float Voto { get; set; } = -1;
        //Contiene Quale Tipo tipo di Esame 
        public Configurazione.Configurazione.ListaEsami TipoEsame { get; set; }



        //public SessionType Session { get; set; }

    }
}
