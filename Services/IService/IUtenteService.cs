using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcdlBooking.Services.IService
{
    public interface IUteneteService
    {
        public Task<List<SelectListItem>> DownList_Esaminatori_Esame();
    }
}
