using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter13RazorViews.Controllers
{
    public class EventsController : Controller
    {
        static private Dictionary<string, string> Events = new Dictionary<string, string>();

        [HttpGet]
        public IActionResult Index()
        {                 

            ViewBag.events = Events;

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public ActionResult NewEvent(string name, string desc)
        {
            Events.Add(name, desc);
            
            return Redirect("/Events");
        }   


    }
}
