using EcdlBooking.Models;
using Microsoft.EntityFrameworkCore;


// Una basedati è un eggetto che eredita da DbContext
// Rappresenta una riproduzione in memoria del db
// La base dati è una classe i cui attributi sono tabelle
// BaseDati={T1, T2, T3,..... Tn}

namespace EcdlBooking.Data
{
    public class BaseDati : DbContext
    {
        // Gli attributi saranno le tabelle
        // o meglio Collezioni di instanze delle varie entità
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        //DbSet<Entità> rappresenta una collezione di instanze di una determinata entità

        public DbSet<School> Schools { get; set; }
        public DbSet<Modulo> Moduli { get; set; }
    }
}

// Schema Relazionale Della Base Dati
// https://dbdiagram.io/d/Diagramma-Booking-ECDL-68cc48c45779bb7265234be5