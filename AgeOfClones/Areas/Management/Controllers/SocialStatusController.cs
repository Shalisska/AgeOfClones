using AgeOfClones.Areas.Management.Models;
using Application.Interfaces;
using Application.Management.Interfaces;
using Application.Management.Models;
using Application.Models.TableEditor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AgeOfClones.Areas.Management.Controllers
{
    [Area("Management")]
    public class SocialStatusController : Controller
    {
        ISocialStatusManagementService _socialStatusManagementService;
        ITableEditorService _tableEditorService;

        public SocialStatusController(
            ISocialStatusManagementService socialStatusManagementService,
            ITableEditorService tableEditorService)
        {
            _socialStatusManagementService = socialStatusManagementService;
            _tableEditorService = tableEditorService;
        }

        private TableEditorModel GetTableModel(IEnumerable<SocialStatusManagementModel> entities, SocialStatusManagementModel entity)
        {
            var entityType = typeof(SocialStatusManagementModel);

            var tableModel = new TableEditorModel("SocialStatuses", entityType, "Id", entities, entity);

            _tableEditorService.AddColumn(tableModel, "Id", null);
            _tableEditorService.AddColumn(tableModel, "Name", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "PerformanceCostPerDay", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "Weight", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "Benefit", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "BenefitTimeDays", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "ReferralPaymentsClonero", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "LicenseCount", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "LicensePrice", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "TimeToGetLicenceHours", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "PriceForAllLicenses", null, ControlType.Input, null);

            _tableEditorService.AddColumn(tableModel, "HaveKingdom", null, ControlType.Checkbox, null);
            _tableEditorService.AddColumn(tableModel, "UniversityLevel", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "HavePalace", null, ControlType.Checkbox, null);
            _tableEditorService.AddColumn(tableModel, "RaiseFlag", null, ControlType.Checkbox, null);
            _tableEditorService.AddColumn(tableModel, "HaveTown", null, ControlType.Checkbox, null);
            _tableEditorService.AddColumn(tableModel, "TownManufacturingLevel", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "MaxFields", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "MaxNumberOfLivestock", null, ControlType.Input, null);

            return tableModel;
        }

        public IActionResult Index()
        {
            var entities = _socialStatusManagementService.GetSocialStatuses();
            var tableModel = GetTableModel(entities, null);

            var model = new ManagementTableViewModel(tableModel, nameof(CreateSocialStatus), nameof(EditSocialStatus), nameof(DeleteSocialStatus));

            return View("TableEditor/_Table", model);
        }

        public IActionResult CreateSocialStatus()
        {
            var tableModel = GetTableModel(null, null);
            var model = tableModel.GetNewRow().ToList();

            ViewData["Action"] = nameof(CreateSocialStatus);
            return PartialView("TableEditor/_TableCreate", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSocialStatus(SocialStatusManagementModel socialStatus)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _socialStatusManagementService.CreateSocialStatus(socialStatus);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(CreateSocialStatus));
            }
        }

        public IActionResult EditSocialStatus(int id)
        {
            var status = _socialStatusManagementService.GetSocialStatus(id);

            var tableModel = GetTableModel(null, status);
            var model = tableModel.GetCurrentRow().ToList();

            ViewData["Action"] = nameof(EditSocialStatus);
            return PartialView("TableEditor/_TableEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSocialStatus(SocialStatusManagementModel socialStatus)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _socialStatusManagementService.UpdateSocialStatus(socialStatus);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(EditSocialStatus));
            }
        }

        public IActionResult DeleteSocialStatus(int? id)
        {
            var model = _socialStatusManagementService.GetSocialStatus(id.Value);

            if (model == null)
                return RedirectToAction(nameof(Index));

            ViewData["Name"] = model.Name;
            ViewData["Action"] = nameof(DeleteSocialStatus);
            return PartialView("TableEditor/_TableDelete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSocialStatus(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _socialStatusManagementService.DeleteSocialStatus(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(DeleteSocialStatus));
            }
        }
    }
}