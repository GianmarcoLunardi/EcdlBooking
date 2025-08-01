﻿
using EcdlBooking.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public string Classe { get; set; }

        // Relazione con School
        //public School School { get; set; }
        //public Guid IdSchool { get; set; } 


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
        public Guid IdSchool { get; set; }
        [ForeignKey(nameof(IdSchool))]
        public School School { get; set; }
        

        // Relazione con  l esaminatore
        // un esaminatore può fare più esami

        public List<Exam>? Esami { get; set; } = null;// In questo caso l esame può essere fatto da molti eaminatori (utento con funzione teacher)

    }
}
