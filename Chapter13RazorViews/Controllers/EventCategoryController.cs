using Chapter13RazorViews.Data;
using Chapter13RazorViews.Models;
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
    }
}
