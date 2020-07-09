using Chapter13RazorViews.Data;
using Chapter13RazorViews.Models;
using Chapter13RazorViews.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Chapter13RazorViews.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext _context;

        public EventCategoryController(EventDbContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index()
        {
            List<EventCategory> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            AddEventCategoryViewModel viewModel = new AddEventCategoryViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(AddEventCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newEventCategory = new EventCategory
                {
                    Name = viewModel.Name
                    
                };

                _context.Categories.Add(newEventCategory);
                _context.SaveChanges();

                return Redirect("/EventCategory");
            }

            return View(viewModel);
        }
    }
}
