using AutoMapper;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using EcdlBooking.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        private readonly IdentityRole _identityRole;
        private readonly UserManager<ApplicationUser> _userManager;
        // Attenzione Procedura in fase di 
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly ILogger _Logger;
        private readonly IMapper _Mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController( UserManager<ApplicationUser> userManager
            ,IMapper Mapper
            , IUnitOfWork unitOfWork
            , RoleManager<IdentityRole> RoleManager
            )
        {
            _userManager = userManager;
            _Mapper = Mapper;
            _unitOfWork = unitOfWork;
            _RoleManager = RoleManager;
        }

        // visualizzs gòi utenti

        public ActionResult Index()
        {
            // La view :
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

        public ActionResult User(Guid id)
        {
            ApplicationUser utente = _userManager.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            Admin_Users_User Maschera = _Mapper.Map<Admin_Users_User>(utente);
            Maschera.ListSchool = _unitOfWork.School.GetCategoryListForDropDown(Maschera.IdSchool).ToList();
            Maschera.ListRuoli = _unitOfWork.Utente.DownList_Rule_User();
            //Maschera.ListRuoli = _unitOfWork.U
            // Compilazione del Munu della tendina dei ruoli
            /*
             Maschera.ListRuoli = _RoleManager.Roles


             */
            //.Select<List<SelectListItem>>(r => new SelectListItem() );
            //Maschera.IdRuolo = _userManager<ApplicationUser>(utente);

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Admin_Users_User Utente)
        {
            if (ModelState.IsValid)
            {
                //ApplicationUser ModelUtente = _Mapper.Map<ApplicationUser>(Utente);

                ApplicationUser ModelUtente = _userManager.FindByIdAsync(Utente.Id).GetAwaiter().GetResult();

                
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

                    //string IDRuole = _RoleManager.GetRoleNameAsync()
                    // Ruolo = await _RoleManager.FindByIdAsync(IDRuole);

 
                
                    // aggiorno l utente
                    IdentityResult RisultatoInseriemento = await _userManager.UpdateAsync(ModelUtente) ;
                   // ritorno alla pagina di tutti gli utenti
                    return RedirectToAction(nameof(Index));
             
            }
            else
            {
                //return RedirectToAction(nameof(Index));
                //return NoContent();*/
                return View();
            }
        }
        // GET: UsersController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {

           //var user = await _userManager.FindByIdAsync(id.ToString());
            //await _userManager.DeleteAsync(user); 
            return RedirectToAction(nameof(Index));
            // la cancellazione funziona ...
            return View();
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
