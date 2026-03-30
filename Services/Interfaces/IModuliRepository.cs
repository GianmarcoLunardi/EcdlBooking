using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.Interfaces
{



    //robabilmente obsoleta
    public interface IModuliRepository : IGenericRepo<Modulo>
    {
        List<SelectListItem> GetModuliListForDropDown();
        Modulo Find(Guid id);
        void Update(Modulo moduli);
    }
}
