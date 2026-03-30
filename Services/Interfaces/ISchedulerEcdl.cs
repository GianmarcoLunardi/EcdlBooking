using EcdlBooking.Models;
using LanguageExt;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.Interfaces
{
    public interface ISchedulerEcdlRepository : Interfaces.IGenericRepo<SchedulerEcdl>
    {

        //public List<SelectListItem> DownList_Rule_User(Guid? IdUserRole = null);
        List<SchedulerEcdl> VisualizzaEsami();
        List<Exam> VisualizzaEsamiDaSostenere();
        public Task<int> PrenotazioneAsync(SchedulerEcdl prenotazione);

        public Task<Unit> PremotaEsami(SchedulerEcdl prenotazione); //Ok
        void Update(SchedulerEcdl esame);
    }
}

 //   SchedulerEcdl
 //   Metodi implementati e uti