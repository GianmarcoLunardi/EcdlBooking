using EcdlBooking.Models;
using EcdlBooking.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.Interfaces
{
    public interface IExamRepository : IGenericRepo<Exam>
    {

        //public List<SelectListItem> DownList_Rule_User(Guid? IdUserRole = null);
        List<Exam> VisualizzaEsami();
        List<Exam> VisualizzaEsamiDaSostenere();
        User_Studente_PrenotaEsame ViewModel( ApplicationUser studente,Exam Esame);

        Exam GetExam(Guid guid);
        
        void Update(Exam esame);
    }
}
