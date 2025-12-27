using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.Interfaces
{
    public interface ISchedulerEcdlRepository : Interfaces.IGenericRepo<SchedulerEcdl>
    {

        //public List<SelectListItem> DownList_Rule_User(Guid? IdUserRole = null);
        List<SchedulerEcdl> VisualizzaEsami();
        List<Exam> VisualizzaEsamiDaSostenere();
       
        void Update(SchedulerEcdl esame);
    }
}

 //   SchedulerEcdl
//