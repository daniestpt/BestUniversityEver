using BestUniversityEver.Models;
using BestUniversityEver.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestUniversityEver.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Course> repository = null;
        public HomeController()
        {
            this.repository = new Repository<Course>();
        }
        public HomeController(IRepository<Course> repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
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