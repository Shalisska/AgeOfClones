using AgeOfClones.Areas.Management.Models;
using Application.Interfaces;
using Application.Management.Interfaces;
using Application.Management.Models;
using Application.Models.TableEditor;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AgeOfClones.Areas.Management.Controllers
{
    [Area("Management")]
    public class StockController : Controller
    {
        IStockManagementService _stockManagementService;
        ITableEditorService _tableEditorService;

        public StockController(
            IStockManagementService stockManagementService,
            ITableEditorService tableEditorService)
        {
            _stockManagementService = stockManagementService;
            _tableEditorService = tableEditorService;
        }

        public IActionResult Index()
        {
            var stocks = _stockManagementService.GetStocks();
            var tableModel = GetTableModel(stocks, null);

            var model = new ManagementTableViewModel(tableModel, nameof(CreateStock), nameof(EditStock), nameof(DeleteStock));

            return View("TableEditor/_Table", model);
        }

        public IActionResult CreateStock()
        {
            var tableModel = GetTableModel(null, null);
            var model = tableModel.GetNewRow().ToList();

            ViewData["Action"] = nameof(CreateStock);
            return PartialView("TableEditor/_TableCreate", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStock(StockManagementModel stock)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _stockManagementService.CreateStock(stock);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(CreateStock));
            }
        }

        public IActionResult EditStock(int id)
        {
            var stock = _stockManagementService.GetStock(id);

            var tableModel = GetTableModel(null, stock);
            var model = tableModel.GetCurrentRow().ToList();

            ViewData["Action"] = nameof(EditStock);
            return PartialView("TableEditor/_TableEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStock(StockManagementModel stock)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _stockManagementService.UpdateStock(stock);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(EditStock));
            }
        }

        public IActionResult DeleteStock(int? id)
        {
            var model = _stockManagementService.GetStock(id.Value);

            if (model == null)
                return RedirectToAction(nameof(Index));

            ViewData["Name"] = model.Name;
            ViewData["Action"] = nameof(DeleteStock);
            return PartialView("TableEditor/_TableDelete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStock(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _stockManagementService.DeleteStock(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(DeleteStock));
            }
        }

        private TableEditorModel GetTableModel(IEnumerable<StockManagementModel> stocks, StockManagementModel stock)
        {
            var entityType = typeof(StockManagementModel);

            var tableModel = new TableEditorModel("Stocks", entityType, "Id", stocks, stock);

            _tableEditorService.AddColumn(tableModel, "Id", null);
            _tableEditorService.AddColumn(tableModel, "Name", null, ControlType.Input, null);

            return tableModel;
        }
    }
}