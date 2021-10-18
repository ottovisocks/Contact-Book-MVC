using ContactBook.Core.Models;
using ContactBook.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly IDbService _context;

        public LocationController(IDbService context)
        {
            _context = context;
        }

        public IActionResult CreatePersonLocation(int id)
        {
            var obj = _context.GetById<Person>(id);

            if (obj is null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePersonLocation(Person obj)
        {
            obj.LocationInfo.PersonId = obj.Id;
            _context.Create(obj.LocationInfo);
            obj.LocationInfoId = obj.LocationInfo.Id;
            _context.Update(obj);

            return RedirectToAction("GetPerson", "Contacts", new { id = obj.Id });
        }

        public IActionResult EditLocation(int id)
        {
            var obj = _context.GetById<PersonLocation>(id);

            if (obj is null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLocation(PersonLocation obj)
        {
            if (ModelState.IsValid)
            {
                _context.Update(obj);

                return RedirectToAction("GetPerson", "Contacts", new { id = obj.PersonId });
            }

            return View(obj);

        }

        public IActionResult DeleteLocation(int id)
        {
            var obj = _context.GetById<PersonLocation>(id);

            if (obj is null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLocationPost(int id)
        {
            var obj = _context.GetById<PersonLocation>(id);

            var person = _context.GetById<Person>(obj.PersonId);

            if (obj is null)
                return NotFound();

            person.LocationInfo = null;
            _context.Update(person);
            _context.Delete(obj);

            return RedirectToAction("GetPerson", "Contacts", new { id = obj.PersonId });
        }
    }
}
