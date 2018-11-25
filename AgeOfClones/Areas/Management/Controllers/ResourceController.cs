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
    public class ResourceController : Controller
    {
        IResourceManagementService _resourceManagementService;
        ITableEditorService _tableEditorService;

        public ResourceController(
            IResourceManagementService resourceManagementService,
            ITableEditorService tableEditorService)
        {
            _resourceManagementService = resourceManagementService;
            _tableEditorService = tableEditorService;
        }

        private TableEditorModel GetTableModel(IEnumerable<ResourceManagementModel> entities, ResourceManagementModel entity)
        {
            var entityType = typeof(ResourceManagementModel);

            var tableModel = new TableEditorModel("Resources", entityType, "Id", entities, entity);

            var stocks = _resourceManagementService.GetStocks().OrderBy(s => s.Name);

            _tableEditorService.AddColumn(tableModel, "Id", null);
            _tableEditorService.AddColumn(tableModel, "Name", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "PriceBase", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "Price", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "Performance", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "StockId", null, ControlType.Select, new SelectList(stocks, "Id", "Name"));

            return tableModel;
        }

        public IActionResult Index()
        {
            var resources = _resourceManagementService.GetResources();
            var tableModel = GetTableModel(resources, null);

            var model = new ManagementTableViewModel(tableModel, nameof(CreateResource), nameof(EditResource), nameof(DeleteResource));

            return View(model);
        }

        public IActionResult CreateResource()
        {
            var tableModel = GetTableModel(null, null);
            var model = tableModel.GetNewRow().ToList();

            ViewData["Action"] = nameof(CreateResource);
            return PartialView("TableEditor/_TableCreate", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateResource(ResourceManagementModel resource)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _resourceManagementService.CreateResource(resource);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(CreateResource));
            }
        }

        public IActionResult EditResource(int id)
        {
            var resource = _resourceManagementService.GetResource(id);

            var tableModel = GetTableModel(null, resource);
            var model = tableModel.GetCurrentRow().ToList();

            ViewData["Action"] = nameof(EditResource);
            return PartialView("TableEditor/_TableEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditResource(ResourceManagementModel resource)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _resourceManagementService.UpdateResource(resource);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(EditResource));
            }
        }

        public IActionResult DeleteResource(int? id)
        {
            var model = _resourceManagementService.GetResource(id.Value);

            if (model == null)
                return RedirectToAction(nameof(Index));

            ViewData["Name"] = model.Name;
            ViewData["Action"] = nameof(DeleteResource);
            return PartialView("TableEditor/_TableDelete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteResource(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _resourceManagementService.DeleteResource(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(DeleteResource));
            }
        }

        public ActionResult UpdateResourcesFromXML()
        {
            _resourceManagementService.UpdateFromXML();

            return RedirectToAction(nameof(Index));
        }
    }
}