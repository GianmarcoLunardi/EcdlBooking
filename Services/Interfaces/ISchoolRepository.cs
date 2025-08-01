using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.Interfaces
{
    public interface ISchoolRepository : IGenericRepo<School>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown(Guid? idSchool);
        public School Find(Guid id);
        void Update(School school);
    }
}
