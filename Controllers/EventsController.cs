﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("/events/add")]
        public IActionResult NewEvent(string name, string description)
        {
            EventData.Add(new Event(name, description));

            return Redirect("/events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/events");
        }

        [HttpGet("/events/edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.eventToEdit = EventData.GetById(eventId);
            return View();
        }

        [HttpPost("/events/edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            EventData.GetById(eventId).Name = name;
            EventData.GetById(eventId).Description = description;

            return Redirect("/events");


        }
    }
}
