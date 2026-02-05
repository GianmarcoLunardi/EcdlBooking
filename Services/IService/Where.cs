using EcdlBooking.Models;

namespace EcdlBooking.Services.IService
{
    public class Where
    {

        public async Task<IList<string>> GetRulesIdAsync(ApplicationUser Utente)
        {


            IList<string> ListaIdRuoli = new List<string>();

            // Selezionare un sottoinsieme del insieme UserRoles
            IList<string> IdRuoliUtenti = _db.UserRoles.Where(ur => ur.UserId == Utente.Id);
            // _db rapprenta la una copia in memoria della baseDati
            //Attributo UserRole è una tabella , quindi una collezione di elementi
            //IdRuoliUtenti ⊂ UserRoles = { ur | ur∈UserRoles and ur.UserId == Utente.Id }  
            return IdRuoliUtenti;
        }

    }
}
