using EcdlBooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.Interfaces
{
    public interface IUserRepository : IGenericRepo<ApplicationUser>
    {
        // restituisce il ruoli di un id utente
        // restituisce i ruolo possbili

        public List<SelectListItem> DownList_Rule_User(Guid? IdUserRole = null);
        public List<SelectListItem> DownList_Esaminatore();
        void Update(ApplicationUser user);
    }
}
