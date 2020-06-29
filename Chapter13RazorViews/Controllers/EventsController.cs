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
using Chapter13RazorViews.ViewModels;

namespace Chapter13RazorViews.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventsData.GetAll());

            return View(events);
        }

        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    EventLocation = addEventViewModel.EventLocation,
                    NumberOfAttendees = addEventViewModel.NumberOfAttendees
                };

                EventsData.Add(newEvent);

                return Redirect("/Events");
            }

            return View(addEventViewModel);
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
        public IActionResult SubmitEditEventForm(int eventId, string name, string description, string contactEmail, string eventLocation, int numberOfAttendees)
        {           

            Event newEdit = EventsData.GetById(eventId);

            newEdit.Name = name;
            newEdit.Description = description;
            newEdit.ContactEmail = contactEmail;
            newEdit.EventLocation = eventLocation;
            newEdit.NumberOfAttendees = numberOfAttendees;

            return Redirect("/Events");
        }


    }
}
