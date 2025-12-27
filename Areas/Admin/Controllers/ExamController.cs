using AutoMapper;
using EcdlBooking.Configurazione;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using EcdlBooking.Services.IService;
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
        private readonly IUteneteService _utenteService;



        public ExamController(
            IUnitOfWork unitOfWork,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IUteneteService uteneteService
            )
        { 
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _utenteService = uteneteService;
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

            x.LuogoEsameLista = _unitOfWork.School.GetCategoryListForDropDown(null).ToList();

            //x.EsaminatoreLista = await _unitOfWork.Utente.ListaEsaminatori();
            //Inserimento della drop list degli esaminatori
            x.EsaminatoreLista =await  _utenteService.DownList_Esaminatori_Esame();
            //string UtenteProf = Configurazione.Configurazione.Insegnante;
            //IList<ApplicationUser> ListaUtenti = _userManager.Users.ToList<ApplicationUser>();
            //x.EsaminatoreLista =
            //   ListaUtenti.Where(u => x is int ) ;



            //_userManager.IsInRoleAsync(u, UtenteProf).GetAwaiter().GetResult));





            //x.EsaminatoreLista = await _UserRepo.ListaEsaminatori();
            x.Data = DateTime.Now;
            return View(x);
            
        }

        private void toList()
        {
            throw new NotImplementedException();
        }

        async public Task<ActionResult> CreatePost(Admin_Exam_Create esame)
        {
            CreateExam(esame);
            return RedirectToAction(nameof(Index));
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
            Esame.School = _unitOfWork.School.Find(x.LuogoEsameId);
            Esame.IdSchool = x.LuogoEsameId;
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
        [HttpPost("/api/Exam/Add")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExam(Admin_Exam_Create esame)
        {
            if (ModelState.IsValid)
            {
                //Salvataggio dell' esame
                Exam newExam = _mapper.Map<Exam>(esame);
                // aggiungere le rlazioni
                newExam.Esaminatore = _unitOfWork.Utente.GetAll()
                   .FirstOrDefault(e => e.Id == esame.EsaminatoreId.ToString());

                newExam.School = _unitOfWork.School.GetAll()
                   .FirstOrDefault(s=> s.Id == esame.LuogoEsameId)
                   ;
                _unitOfWork.Esami.add(newExam);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return Ok(esame);
        }








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
