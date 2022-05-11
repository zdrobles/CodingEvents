using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {      
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventsIds)
        {
            foreach(int eventId in eventsIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/Events");
        }

        [HttpGet("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            Event eventToEdit = EventData.GetById(eventId);
            ViewBag.eventToEdit = eventToEdit;
            ViewBag.title = $"Edit Event {eventToEdit.Name}(id = {eventId})";
            return View();
        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            Event editedEvent = EventData.GetById(eventId);
            editedEvent.Name = name;
            editedEvent.Description = description;
            return Redirect("/Events");
        }

    }
}
