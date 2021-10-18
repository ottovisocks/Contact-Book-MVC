using ContactBook.Core.Models;
using ContactBook.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IDbService _context;

        public CompanyController(IDbService context)
        {
            _context = context;
        }

        public IActionResult CreateCompany(int id)
        {
            var obj = _context.GetById<Person>(id);

            if (obj is null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCompany(Person obj)
        {
            obj.CompanyInfo.PersonId = obj.Id;
            _context.Create(obj.CompanyInfo);
            obj.CompanyInfoId = obj.CompanyInfo.Id;
            _context.Update(obj);

            return RedirectToAction("GetPerson", "Contacts", new { id = obj.Id });
        }

        public IActionResult EditCompany(int id)
        {
            var obj = _context.GetById<Company>(id);

            if (obj is null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCompany(Company obj)
        {
            if (ModelState.IsValid)
            {
                _context.Update(obj);

                return RedirectToAction("GetPerson", "Contacts", new { id = obj.PersonId });
            }

            return View(obj);

        }

        public IActionResult DeleteCompany(int id)
        {
            var obj = _context.GetById<Company>(id);

            if (obj is null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCompanyPost(int id)
        {
            var obj = _context.GetById<Company>(id);

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
