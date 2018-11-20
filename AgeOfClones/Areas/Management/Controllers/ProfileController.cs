﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data.EF;
using Infrastructure.Data.Entities;
using Application.Management.Interfaces;
using Application.Interfaces;
using Application.Management.Models;
using AgeOfClones.Areas.Management.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgeOfClones.Areas.Management.Controllers
{
    [Area("Management")]
    public class ProfileController : Controller
    {
        IProfileManagementService _profileManagementService;
        IEntityEditorService _tableEditorService;

        public ProfileController(
            IProfileManagementService profileManagementService,
            IEntityEditorService tableEditorService)
        {
            _profileManagementService = profileManagementService;
            _tableEditorService = tableEditorService;
        }

        #region Profile
        public IActionResult Index()
        {
            var profiles = _profileManagementService.GetProfiles();
            var tableModel = GetTableModel(profiles, null);

            var model = new ManagementTableViewModel(tableModel, nameof(CreateProfile), nameof(EditProfile), nameof(DeleteProfile));

            return View("TableEditor/_Table", model);
        }

        private EntityEditorModel GetTableModel(IEnumerable<ProfileManagementModel> profiles, ProfileManagementModel profile)
        {
            var entityType = typeof(ProfileManagementModel);

            var tableModel = new EntityEditorModel(entityType, "Id", profiles, profile);

            tableModel.AddColumn("Id");
            tableModel.AddColumn("Name", ControlType.Input, _tableEditorService.GetValidationAttributes(entityType, "Name"), null, null);

            return tableModel;
        }

        public IActionResult CreateProfile()
        {
            var tableModel = GetTableModel(null, null);
            var model = tableModel.GetNewEntity().ToList();

            //var model = new ProfileManagementModel();
            ViewData["Action"] = "CreateProfile";
            return PartialView("TableEditor/_TableCreate", model);
        }

        // POST: Profile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProfile(ProfileManagementModel profile)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _profileManagementService.CreateProfile(profile);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("CreateProfile");
            }
        }

        // GET: Profile/Edit/5
        public IActionResult EditProfile(int id)
        {
            var profile = _profileManagementService.GetProfile(id);

            var tableModel = GetTableModel(null, profile);
            var model = tableModel.GetCurrentEntity().ToList();

            ViewData["Action"] = "EditProfile";
            return PartialView("TableEditor/_TableEdit", model);
        }

        // POST: Profile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfile(ProfileManagementModel profile)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _profileManagementService.UpdateProfile(profile);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("EditProfile");
            }
        }

        // GET: Profile/Delete/5
        public IActionResult DeleteProfile(int? id)
        {
            var model = _profileManagementService.GetProfile(id.Value);

            if(model==null)
                return RedirectToAction(nameof(Index));

            ViewData["Name"] = model.Name;
            ViewData["Action"] = "DeleteProfile";
            return PartialView("TableEditor/_TableDelete");
        }

        // POST: Profile/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProfile(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _profileManagementService.DeleteProfile(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("DeleteProfile");
            }
        }
        #endregion Profile

        #region Account
        public IActionResult IndexAccount()
        {
            var model = _profileManagementService.GetAccounts();

            return View(model);
        }

        public IActionResult CreateAccount()
        {
            var model = new AccountManagementModel();
            ViewData["Action"] = "CreateAccount";
            return PartialView("_Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(AccountManagementModel account)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _profileManagementService.CreateAccount(account);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(CreateAccount));
            }
        }

        public IActionResult EditAccount(int id)
        {
            var model = _profileManagementService.GetAccount(id);
            ViewData["Action"] = "EditAccount";
            return PartialView("_Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAccount(AccountManagementModel account)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _profileManagementService.UpdateAccount(account);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(EditAccount));
            }
        }

        public IActionResult DeleteAccount(int? id)
        {
            var model = _profileManagementService.GetAccount(id.Value);

            if (model == null)
                return RedirectToAction(nameof(Index));

            ViewData["Action"] = "DeleteAccount";
            return PartialView("_Delete", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAccount(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _profileManagementService.DeleteAccount(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(DeleteAccount));
            }
        }
        #endregion Account


    }
}