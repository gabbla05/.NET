using Microsoft.AspNetCore.Mvc;
using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.Controllers
{
    public class ParticipantsController : Controller
    {
        public IActionResult Create(int eventId)
        {
            var participant = new Participant { EventId = eventId };
            return View(participant);
        }

        [HttpPost]
        public IActionResult Create(Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return View(participant);
            }

            participant.Id = InMemoryDatabase.Participants.Count + 1;
            InMemoryDatabase.Participants.Add(participant);

            return RedirectToAction("ListByEvent", new { eventId = participant.EventId });
        }

        public IActionResult ListByEvent(int eventId)
        {
            var eventObj = InMemoryDatabase.Events.FirstOrDefault(e => e.Id == eventId);
            if (eventObj == null) return NotFound();

            var participants = InMemoryDatabase.Participants
                .Where(p => p.EventId == eventId)
                .ToList();

            ViewBag.EventTitle = eventObj.Title;
            return View(participants);
        }
    }
}
