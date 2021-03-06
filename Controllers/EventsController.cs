﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
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

        [HttpPost("/events/add")]
        public IActionResult NewEvent(string name, string category)
        {
            Events.Add(name, category);

            return Redirect("/events");
        }
    }
}
