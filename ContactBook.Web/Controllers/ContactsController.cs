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
    public class ContactsController : Controller
    {
        private readonly IDbService _context;

        public ContactsController(IDbService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var objList = _context.Query<Person>()
                .Include(item => item.LocationInfo)
                .Include(item => item.CompanyInfo)
                .ToList();

            return View(objList);
        }

        public IActionResult GetPerson(int id)
        {
            var obj = _context.Query<Person>()
                .Include(item => item.LocationInfo)
                .Include(item => item.CompanyInfo)
                .SingleOrDefault(item => item.Id == id);

            if (obj is null)
                return NotFound();

            return View(obj);
        }

        public IActionResult CreateBasicPerson()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBasicPerson(Person obj)
        {
            if(ModelState.IsValid)
            {
                _context.Create(obj);

                return RedirectToAction("index");
            }

            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var obj = _context.GetById<Person>(id);

            if (obj is null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Person obj)
        {
            if(ModelState.IsValid)
            {
                _context.Update(obj);

                return RedirectToAction("GetPerson", new { id = obj.Id });
            }

            return View(obj);
            
        }


        public IActionResult Delete(int id)
        {
            var obj = _context.GetById<Person>(id);

            if (obj is null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var obj = _context.GetById<Person>(id);

            if (obj is null)
                return NotFound();

            _context.Delete(obj);

            return RedirectToAction("index");
        }
    }
}
