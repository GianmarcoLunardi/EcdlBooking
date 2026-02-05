using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.Interfaces
{
    public interface IModuliRepository : IGenericRepo<Modulo>
    {
        List<SelectListItem> GetModuliListForDropDown();
        Modulo Find(Guid id);
        void Update(Modulo moduli);
    }
}
