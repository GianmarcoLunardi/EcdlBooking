using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcdlBooking.Areas.Admin.Controllers
{
    /// <summary>
    /// Dare la priorità anche agli stundenti di poter visualizzare i prorio esami sensa però modificare
    /// il voto
    /// </summary>
    [Area("Admin")]
    public class SchedulerController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        // GET: SchedulerController
        public ActionResult Get()
        {
            return View();
        }

        // GET: SchedulerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SchedulerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchedulerController/Create
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

        // GET: SchedulerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SchedulerController/Edit/5
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

        // GET: SchedulerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SchedulerController/Delete/5
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
