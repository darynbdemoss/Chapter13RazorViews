using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Chapter13RazorViews.Models;
using Chapter13RazorViews.Data;
using Chapter13RazorViews.ViewModels;
using System.Threading;
using System.Linq;

namespace Chapter13RazorViews.Controllers
{
    public class EventsController : Controller
    {

        private EventDbContext context;

        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Event> events = context.Events.ToList();

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

                context.Events.Add(newEvent);
                context.SaveChanges();

                return Redirect("/Events");
            }

            return View(addEventViewModel);
        }

        public IActionResult Delete()
        {            
            ViewBag.events = context.Events.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }

            context.SaveChanges();

            return Redirect("/Events");
        }


        [HttpGet("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.edit = context.Events.Find(eventId);
            context.SaveChanges();
            return View();
            
        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description, string contactEmail, string eventLocation, int numberOfAttendees)
        {           

            Event newEdit = context.Events.Find(eventId);

            newEdit.Name = name;
            newEdit.Description = description;
            newEdit.ContactEmail = contactEmail;
            newEdit.EventLocation = eventLocation;
            newEdit.NumberOfAttendees = numberOfAttendees;

            context.SaveChanges();
            return Redirect("/Events");
            
        }
        

    }
}
