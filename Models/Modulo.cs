using System.ComponentModel.DataAnnotations;

namespace EcdlBooking.Models
{
    public class Modulo
    {
        [Key] 
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
