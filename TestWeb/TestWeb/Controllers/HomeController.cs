using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var context = new TestDatabaseEntities();
            var personal = new tblPersonal()
            {
                FirstName = "Juan",
                LastName = "Dela Cruz",
                MiddleName = "Pedro"
            };
            context.tblPersonals.Add(personal);
            await context.SaveChangesAsync();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}