using EcdlBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.Interfaces
{
    public interface IExamRepository : IGenericRepo<Exam>
    {

        //public List<SelectListItem> DownList_Rule_User(Guid? IdUserRole = null);
        List<Exam> VisualizzaEsami();
        List<Exam>VisualizzaEsamiDaSostenere();
       
        void Update(Exam esame);
    }
}
