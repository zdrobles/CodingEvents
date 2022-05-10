using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //static private List<string> Events = new List<string>();
        static private Dictionary<string, string> Events = new Dictionary<string, string>();
        //[HttpGet]
        public IActionResult Index()
        {
            //Events.Add("Strange Loops");
            //Events.Add("Grace Hopper");
            //Events.Add("Code with Pride");
            ViewBag.events = Events;

            return View();
        }

        //[HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("/Events/Add")]
        public IActionResult NewEvent(string name, string desc = "")
        {
            Events.Add(name, desc);
            return Redirect("/Events");
        }
    }
}
