using EcdlBooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using LanguageExt.Common;
using LanguageExt;
namespace EcdlBooking.Services.Interfaces
{
    public interface IUserRepository : IGenericRepo<ApplicationUser>
    {
        // restituisce il ruoli di un id utente
        // restituisce i ruolo possbili

        public List<SelectListItem> DownList_Rule_User(IList<string> Ruoli);
        
        public Task<IList<string>> GetRulesIdAsync(ApplicationUser Utente);
        // Funzione dhe Dato l utente restitutisce la lista degli id sei ruoli  




        // task ritorna un TResult
        public Task<List<SelectListItem>> ListaEsaminatori();
        
        public Task<ApplicationUser> GetAsync(string IdUtente);

        void Update(ApplicationUser user);
    }
}
