using Microsoft.AspNetCore.Mvc;
using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View(InMemoryDatabase.Events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event newEvent)
        {
            if (!ModelState.IsValid)
            {
                return View(newEvent);
            }

            newEvent.Id = InMemoryDatabase.Events.Count + 1;
            InMemoryDatabase.Events.Add(newEvent);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var selectedEvent = InMemoryDatabase.Events.FirstOrDefault(e => e.Id == id);
            if (selectedEvent == null)
            {
                return NotFound();
            }

            return View(selectedEvent);
        }
    }
}
