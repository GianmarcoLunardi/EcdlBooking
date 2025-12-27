using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.Interfaces
{
    public interface ISchedulerEcdl : IGenericRepo<SchedulerEcdl>
    {
        //IEnumerable<SelectListItem> GetCategoryListForDropDown(Guid? idSchool);
       //public School Find(Guid id);
        void Update(SchedulerEcdl esame);
    }
}


//SchedulerEcdl