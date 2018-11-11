using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data.EF;
using Infrastructure.Data.Entities;

namespace AgeOfClones.Areas.Management.Controllers
{
    [Area("Management")]
    public class ProfileController : Controller
    {
        ClonesContextEF _clonesContext;

        public ProfileController(ClonesContextEF clonesContext)
        {
            _clonesContext = clonesContext;
        }

        public IActionResult Index()
        {
            var model = _clonesContext.Profiles?.ToList();

            return View(model);
        }

        public IActionResult IndexAccount()
        {
            var model = _clonesContext.Accounts?.ToList();

            return View(model);
        }

        public IActionResult CreateProfile()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProfile(Profile profile)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _clonesContext.Add(profile);
                    _clonesContext.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Profile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(Account account)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _clonesContext.Add(account);
                    _clonesContext.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}