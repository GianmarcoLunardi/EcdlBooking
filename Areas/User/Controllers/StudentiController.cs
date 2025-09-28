using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using EcdlBooking.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EcdlBooking.Controllers
{
    [Area("User")]
    
    public class StudentiController : Controller
    {
        private readonly ILogger<StudentiController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IGenericRepository<Exam> _RepoExam;
        public StudentiController(
            ILogger<StudentiController> logger
            , UserManager<ApplicationUser> _userManager
            ,IUnitOfWork unitOfWork
                        

            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        // visualizza solo il contenuto del calendario degli esami
        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Exam> x =  _unitOfWork.Esami.VisualizzaEsamiDaSostenere();
                 return View(x);
           
        }


        
        [HttpPut]
        public IActionResult PrenotaEsame( Guid id)
        {

            return View(id);
        }
        


        public IActionResult VisualizzaEsami()
        {

            return View();
        }

        public IActionResult IndexProtetto()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> EsamiSostenuti()
        {
            //ClaimsPrincipal utenteLoggato =  User;
            ApplicationUser UtenteLoggato = await _userManager.GetUserAsync(User);

            return View(UtenteLoggato);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
