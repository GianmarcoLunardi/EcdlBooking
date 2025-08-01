using AutoMapper;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using EcdlBooking.ViewModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcdlBooking.Controllers
{
    [Area("admin")]
    public class ExamController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;



        public ExamController(
            IUnitOfWork unitOfWork,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper
            )
        { 
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: ControllerController
        public ActionResult Index()
        {
            return View(_unitOfWork.Esami.VisualizzaEsami());
        }

        // GET: ControllerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ControllerController/Create
        async public Task<ActionResult> Create()
        {

            //Creazione di un nuovo ViewModel Riguardante L' esame
            Admin_Exam_Create x = new Admin_Exam_Create();

            x.PlaceList = _unitOfWork.School.GetCategoryListForDropDown(null).ToList();

            //Inserimento della drop list degli esaminatori

            string UtenteProf = Configurazione.Configurazione.Insegnante;
            x.EsaminatoreLista = _userManager.Users
                //.where(u =>  await _userManager.IsInRoleAsync(u, UtenteProf) )
                
                .Select(p => new SelectListItem
                {
                    Text = p.Name + " " + p.Surname,
                    Value = p.Id,
                })
              
                .ToList();
            



            //x.EsaminatoreLista = await _UserRepo.ListaEsaminatori();
            x.Data = DateTime.Now;
            return View(x);
            
        }

        // Inizio dell API



        #region Api

        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<ActionResult> Create(Admin_Exam_Create x)
        {
            //Relazione Sul Luogo Dell Asame
            Exam Esame = _mapper.Map<Exam>(x);
            // Inserisco i l oggetto Scuola in cui si fa l esame
            Esame.School = _unitOfWork.School.Find(x.PlaceSelected);
            Esame.IdSchool = x.PlaceSelected;
            //Relazione 
            Esame.Esaminatore =await  _userManager.FindByIdAsync(x.EsaminatoreId.ToString());
            Esame.IdEsaminatore = x.EsaminatoreId;
            _unitOfWork.Esami.add(Esame);
            _unitOfWork.Save();
            // return Redirect("/home");
            return Redirect("/Admin/Exam/index");
        }

        // GET api/bookchapters/guid
        [HttpGet]
        public List<Exam> Get()
        {
            return _unitOfWork.Esami.VisualizzaEsami();
        }


                #endregion

                        // POST: ControllerController/Create
                        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createx(IFormCollection collection)
        {
            /*
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            */
            return View();
        }

        // GET: ControllerController/Edit/5
        /*
        public ActionResult Edit(int id)
        {
            return View();
        }
        
        // POST: ControllerController/Edit/5
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
                return View();
            }
        }
        */

        // POST: ControllerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromBody] Admin_Users_User Utente)
        {

                return RedirectToAction(nameof(Index));

        }


        // GET: ControllerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ControllerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            /*
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            */

            return View();
        }
        
    }
}
