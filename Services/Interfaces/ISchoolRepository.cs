using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.Interfaces
{
    public interface ISchoolRepository : IGenericRepo<School>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(School school);
    }
}
