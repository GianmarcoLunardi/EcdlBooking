using EcdlBooking.Services.Interfaces;
using EcdlBooking.Services.IService;
using EcdlBooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using LanguageExt;
using LanguageExt.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace EcdlBooking.Services.Service
{
    public class UteneteService : IUteneteService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public  UteneteService(
                UserManager<ApplicationUser> userManager
            )
        {
            _userManager= userManager;

        }

        //Funzione che ritorna la lista dei professori che poi sono esaminatori per esame
        
        
        
        
        
        
         async Task<List<SelectListItem>> IUteneteService.DownList_Esaminatori_Esame()
        {
            string ruoloInsegnante = Configurazione.Configurazione.Insegnante;


                var Utenti = _userManager.Users.ToList();
                var UtentiEsaminatori = new List<ApplicationUser>();

                foreach (var item in Utenti)
                {
                    if (await _userManager.IsInRoleAsync(item, ruoloInsegnante)){
                        UtentiEsaminatori.Add(item);
                    }
                };

                var DropMenuEsaminatori = UtentiEsaminatori
                    .Select(u => new SelectListItem
                    {
                        Text = $"{u.Name} {u.Surname}",
                        Value = u.Id
                    })
                    .ToList();
                return DropMenuEsaminatori ;



                //throw new NotImplementedException();
        }
    }
}


//            throw new NotImplementedException();
