
using EcdlBooking.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


/* 
https://dbdiagram.io/d/Diagramma-Booking-ECDL-68cc48c45779bb7265234be5
*/

namespace EcdlBooking.Models
{
    public class ApplicationUser : IdentityUser
    {



        //public WebUser WebUser { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime Born { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string?Country { get; set; }
        public string? familyContactPerson { get; set; }
        public string? familyContactPerson_phone { get; set; }
        public string? familyContactPerson_email { get; set; }

        // Relazione con School indisca la relazione in quale scuola è inscritto
        // sia che ia un professore che sia un alunno
        public Guid IdSchool { get; set; } //Funziona
        [ForeignKey(nameof(IdSchool))] //Ok funziona
        public School School { get; set; } // Ok Funziona


        // Relazione con  l esaminatore
        // un esaminatore può fare più esami

        public List<Exam>? Esami { get; set; } = null;// In questo caso l esame può essere fatto da molti eaminatori (utento con funzione teacher)


        /// inizio modifiche
        /// Relazine  Con La Tabelle Scheduler Tabella Prenotazione
        // lo studente sontirne uno o più esami
        /*
        [ForeignKey(nameof(SchedulerEcdl))]
        public Guid IdScheduler { get; set; }
        public ICollection<SchedulerEcdl> Reservation { get; set; }
        */
        ///  Fine Modifiche


    }
}
