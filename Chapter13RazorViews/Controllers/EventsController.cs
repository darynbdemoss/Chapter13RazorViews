using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Chapter13RazorViews.Models;
using Chapter13RazorViews.Data;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Chapter13RazorViews.Controllers
{
    public class EventsController : Controller
    {
        

        [HttpGet]
        public IActionResult Index()
        {                 

            ViewBag.events = EventsData.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("/Events/Add")]        
        public IActionResult NewEvent(Event newEvent)
        {
            EventsData.Add(newEvent);
            
            return Redirect("/Events");
        }

        public IActionResult Delete()
        {            
            ViewBag.events = EventsData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventsData.Remove(eventId);
            }

            return Redirect("/Events");
        }


        [HttpGet("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.edit = EventsData.GetById(eventId);
            return View();
        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {           

            Event newEdit = EventsData.GetById(eventId);

            newEdit.Name = name;
            newEdit.Description = description;

            return Redirect("/Events");
        }


    }
}
