using AutoMapper;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using EcdlBooking.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EcdlBooking.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {

        //private readonly IdentityRole _identityRole;
        private readonly UserManager<ApplicationUser> _userManager;
        // Attenzione Procedura in fase di 
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UsersController> _Logger;
        private readonly IMapper _Mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController( 
            UserManager<ApplicationUser> userManager,
            IMapper Mapper,
            IUnitOfWork unitOfWork,
            RoleManager<IdentityRole> RoleManager,
            ILogger<UsersController> Logger
            )
        {
            _userManager = userManager;
            _Mapper = Mapper;
            _unitOfWork = unitOfWork;
            _roleManager = RoleManager;
            _Logger = Logger;
        }

        // visualizzs gòi utenti

        public ActionResult Index()
        {
            // @model IEnumerable<EcdlBooking.Models.ApplicationUser>;

            //  _Logger.LogInformation("UsersController Index method called");
            
            IList<ApplicationUser> ListaUtenti = new List<ApplicationUser>();

            ListaUtenti = _unitOfWork.Utente.GetAll(null,null,"School").ToList();

            //return View( _userManager.Users.ToList());
            return View(ListaUtenti);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(Guid id)
        {

            return View();
        }

        // maschera che fornisce i degli di un certo utente
        [HttpGet]
        public async Task<ActionResult> User(Guid id)
        {
            ApplicationUser utente = _userManager.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            Admin_Users_User Maschera = _Mapper.Map<Admin_Users_User>(utente);

            Maschera.ListSchool = _unitOfWork.School.GetCategoryListForDropDown(Maschera.IdSchool).ToList();
            Maschera.ListRuoli = _unitOfWork.Utente.DownList_Rule_User( await _userManager.GetRolesAsync(utente)).ToList();
            
            Maschera.IdRuoli = _unitOfWork.Utente.GetRulesIdAsync(utente).GetAwaiter().GetResult();


            return View(Maschera); 
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }






        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        /*
        public ActionResult Edit(int id)
        {
            return View();
        }
        
        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
           var user =  _userManager.FindByIdAsync(id.ToString());

                return View();
            }
        }
        */
        // Prova Di Post Per la modifica Di Dati
        [HttpPost]
        public async Task<IActionResult> Edit(Admin_Users_User Utente)
        {
            _Logger.LogInformation("inizio procedura aggiornamento utente");

            if (ModelState.IsValid)
            {

                _Logger.LogInformation("ModelView Validato");

                ApplicationUser ModelUtente = _userManager.FindByIdAsync(Utente.Id.ToString()).GetAwaiter().GetResult();


                // aggiornamento assegnazione dei permessi all utente




                //ModelUtente.UserName = Utente.UserName;
                ModelUtente.Email = Utente.Email;
                ModelUtente.PhoneNumber = Utente.PhoneNumber;
                ModelUtente.Name = Utente.Name;
                ModelUtente.Surname = Utente.Surname;
                ModelUtente.Born = Utente.Born;
                ModelUtente.Address = Utente.Address;
                ModelUtente.City = Utente.City;
                ModelUtente.Country = Utente.Country;
                ModelUtente.familyContactPerson = Utente.familyContactPerson;
                ModelUtente.familyContactPerson_phone = Utente.familyContactPerson_phone;
                ModelUtente.familyContactPerson_email = Utente.familyContactPerson_email;
                ModelUtente.IdSchool = Utente.IdSchool;

                // Inserimento dei valori dei dati per il ruolo




                // Recupero i ruoli attuali
                var currentRoles = await _userManager.GetRolesAsync(ModelUtente);

                // Rimuovo tutti i ruoli esistenti
                IdentityResult ResultSub = await _userManager.RemoveFromRolesAsync(ModelUtente, currentRoles);

                // Aggiungo i nuovi ruoli
                IList<string> newRoles = new List<string>();
                IdentityRole identityrole;
                //stare attenti al nulla 
                foreach (string ruolo in  Utente.IdRuoli)
                    {
                    identityrole = await _roleManager.FindByIdAsync(ruolo);
                    newRoles.Add(identityrole.Name);
                    }

               //     Utente.IdRuoli.Select(IdRuolo => (_roleManager.FindByIdAsync(IdRuolo).GetAwaiter().GetResult()).Name) ;
                //new List<string> { "Manager", "Editor" };
                //IList<string> ListaNomiRuole = newRoles.Select(r => _roleManager.FindByIdAsync(r).GetAwaiter().GetResult()); 

                IdentityResult ResultAdd = await _userManager.AddToRolesAsync(ModelUtente, newRoles);

                _Logger.LogInformation("Risultato della modifica dei ruolo" + ResultAdd.Succeeded.ToString());



                // Codice da ricontrollare 
                //string IDRuole = _RoleManager.GetRoleNameAsync(role => role.)
                //IList<string>  NuovoRuolo = await _userManager.GetRolesAsync(_Mapper.Map<ApplicationUser>(Utente));
                //IdentityRole NuovoRuoloOggetto = await _roleManager.FindByIdAsync(Utente.IdRuolo.ToString());
                //string NuovoRuolo = await _roleManager.GetRoleNameAsync(NuovoRuoloOggetto);
                //IdentityRole VecchioRuolo = await _roleManager.FindByIdAsync(Utente.IdRuolo.ToString());
                //IList<string> ListaVecchioRuolo = new List<string> {VecchioRuolo.ToString()};

                //await _userManager.RemoveFromRolesAsync(ModelUtente, ListaVecchioRuolo);
                //IdentityResult RisultatoAggiuntaRuolo = await _userManager.AddToRoleAsync(ModelUtente, NuovoRuolo );


                // aggiorno l utente
                // IdentityResult RisultatoInseriemento = await _userManager.UpdateAsync(ModelUtente) ;

                //Result.Succeeded?_Logger.LogInformation("ruoli agiornato") ? _Logger.LogError("Errore nell aggiornamento dei ruoli");

                // ritorno alla pagina di tutti gli utenti
                return RedirectToAction(nameof(Index));
             
            }
            else
            {
                _Logger.LogError("Errore nella modifica dei dati dell'utente");
                return RedirectToAction(nameof(Index));
                //return NoContent();*/
                //return View();
            }
        }
        // GET: UsersController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {

            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user); 
            return RedirectToAction(nameof(Index));
            // la cancellazione funziona ...
            
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
