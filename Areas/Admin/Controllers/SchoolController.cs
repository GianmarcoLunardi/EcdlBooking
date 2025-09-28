using EcdlBooking.Data;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using EcdlBooking.Services.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

using System.Threading.Tasks;
using EcdlBooking.ViewModel;
using EcdlBooking.Services.Interfaces;
using EcdlBooking.Services.Repository;
using EcdlBooking.AutoMapper;
using AutoMapper;

namespace EcdlBooking.Controllers
{
    [Area("Admin")]
    public class SchoolController : Controller
    {
        private readonly ILogger<SchoolController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SchoolController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
             ILogger<SchoolController> logger
            )
        {
            _logger = logger;
        _unitOfWork = unitOfWork;
            _mapper = mapper;

        }



        // GET: SchoolController
        // collezione delle scuole
        public  ActionResult Index()
        {
           
            return View(  _unitOfWork.School.GetAll() );
        }
        /*
        [HttpGet]
        public async Task<ActionResult> IndexClass(Guid id) {
           
                  IEnumerable<School> lista = await RepoSchool.All();
                  //return View();
                  //return Ok();
                  //return Ok();
                  lista = lista.Where(x => x.id == Guid.Parse(id_school)).ToList();
                  return View(lista);*/

            // Data.leggere l inner joinn
           // School x = await _schoolRepository.Find(id);
              //  return View(x);
       // }
    
        // GET: SchoolController/Details/5
        public ActionResult Details(Guid id)
        {
            School Scuola =_unitOfWork.School.GetFirstOrDefault(s => s.Id == Guid.Parse(id.ToString()) );
            

            return View(_mapper.Map<CreateClassSchool>(Scuola));
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            School s = new School();
            return View(s);
        }

        // POST: SchoolController/Create
        [HttpPost]
       //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Scool(School Scuola)
        {
            await _unitOfWork.School.add(Scuola);
            await _unitOfWork.Save(); 
          
            return RedirectToAction(nameof(Index));
            

           
        }

        // Crea le classi di una scuola


        // GET: SchoolController/Create
       // pagina che visualizza le classi di una determinata scuola
        /*
        public async Task<ActionResult> IndexClass3( Guid id)
        {
            Guid x = id;
            return View(await repoSchool.Find(id));
        }
        */
        [HttpGet("AddClass/{id:Guid}")]
        public async Task<ActionResult> AddClass(Guid id)
        {
            CreateClassSchool x = new CreateClassSchool();
            x.Id_School = id;

            return View(x);
        }


        [HttpPost]
        public async Task<ActionResult> AddClass_Post(CreateClassSchool x)
        {
            //CreateClassSchool x = new CreateClassSchool();
            //x.Id_Classe = id;

            Class classe = new Class();
            //classe.Name = x.Classe;
            //classe.School = await _classRepository.Find(x.Id_School);
            classe.SchoolId = x.Id_School;



                    //classe.School.Add(await RepoSchool.Find(x.Id_School));
                    //classe.SchoolId = x.Id_School;
                    //classe.School.Add(await RepoSchool.Find(x.Id_School));

                    
                    // probabilmento dolo da aggiunstare
                   // await _classRepository.Add(classe);
          
            
            
            // Add Repo School

            //School scuola = await RepoSchool.Find(x.Id_School);
           // scuola.Classes.Add(classe);

            //await RepoSchool.Add(scuola);

            //School x2 = await RepoSchool.Find(x.Id_Classe);
            //x2.Classes.Add(classe);

            //await RepoSchool.Edit(x2);
            //return RedirectToAction("IndexClass", x.Id_School);
            return RedirectToAction("IndexClass", new { id = x.Id_School } );
            //return View(x);
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Classx(IFormCollection collection)
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

        // GET: SchoolController/Edit/5
        public ActionResult Edit(Guid id)
        {
            School scuola = _unitOfWork.School.GetFirstOrDefault(scuola => scuola.Id == id);

            return View(scuola);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public ActionResult Edit(int id, IFormCollection collection)
        public async Task<ActionResult> Edit(School Entity)
        {
            _unitOfWork.School.Update(Entity);
            await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));

        }

        // GET: SchoolController/Delete/5
       
        public ActionResult Delete(Guid id)
        {
            
            //Console.WriteLine($" entrata del delete {id}");

            //Ricerca Dell Entità School
            School scuola  = _unitOfWork.School.GetFirstOrDefault(x => x.Id == id);

            _logger.LogInformation("Siamo arrivati alla cancellazione -----> " + id);
           _unitOfWork.School.delete(scuola);
            /*
            _unitOfWork.School.delete(
                _unitOfWork.School.GetFirstOrDefault( s => s.id == id)
                );
            */
            return RedirectToAction(nameof(Index));
        }




        // POST: SchoolController/Delete/5
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
