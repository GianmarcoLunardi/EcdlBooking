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

namespace EcdlBooking.Controllers
{
    [Area("User")]
    public class HomeControlleunor : Controller
    {
        private readonly ILogger<HomeControlleunor> _logger;
       // private readonly IExamRepository _RepoExam;
        //private readonly IGenericRepository<Exam> _RepoExam;
        public HomeControlleunor(ILogger<HomeControlleunor> logger

           // IExamRepository repoExam
            )
        {
            _logger = logger;
            //_RepoExam = repoExam;
        }

        public IActionResult Index()
        {
            return View();
            //return View( _RepoExam.All() );
        }

       
        public IActionResult IndexProtetto()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
