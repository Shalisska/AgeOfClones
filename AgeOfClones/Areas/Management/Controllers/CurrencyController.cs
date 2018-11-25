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
    public class CurrencyController : Controller
    {
        ICurrencyManagementService _currencyManagementService;
        IStockManagementService _stockManagementService;
        ITableEditorService _tableEditorService;

        public CurrencyController(
            ICurrencyManagementService currencyManagementService,
            IStockManagementService stockManagementService,
            ITableEditorService tableEditorService)
        {
            _currencyManagementService = currencyManagementService;
            _stockManagementService = stockManagementService;
            _tableEditorService = tableEditorService;
        }

        private TableEditorModel GetTableModel(IEnumerable<CurrencyManagementModel> currencies, CurrencyManagementModel currency)
        {
            var entityType = typeof(CurrencyManagementModel);

            var tableModel = new TableEditorModel("Currencies", entityType, "Id", currencies, currency);

            var stocks = _stockManagementService.GetStocks().OrderBy(s => s.Name);

            _tableEditorService.AddColumn(tableModel, "Id", null);
            _tableEditorService.AddColumn(tableModel, "Name", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "StockId", null, ControlType.Select, new SelectList(stocks, "Id", "Name"));

            return tableModel;
        }

        private TableEditorModel GetExchangeTableModel(IEnumerable<CurrencyExchangeRateManagementModel> currencyExchanges, CurrencyExchangeRateManagementModel currencyExchange, string currentCurrencyName)
        {
            var entityType = typeof(CurrencyExchangeRateManagementModel);

            var tableModel = new TableEditorModel(currentCurrencyName, entityType, "CurrencyPairId", currencyExchanges, currencyExchange);

            var currencies = _currencyManagementService.GetCurrencies().Where(c => c.Name != currentCurrencyName).OrderBy(s => s.Name);

            _tableEditorService.AddColumn(tableModel, "CurrencyId", null);
            _tableEditorService.AddColumn(tableModel, "CurrencyPairId", null, ControlType.Select, new SelectList(currencies, "Id", "Name"));
            _tableEditorService.AddColumn(tableModel, "Buy", null, ControlType.Input, null);
            _tableEditorService.AddColumn(tableModel, "Sell", null, ControlType.Input, null);

            return tableModel;
        }

        public IActionResult Index()
        {
            var currencies = _currencyManagementService.GetCurrencies();
            var tableModel = GetTableModel(currencies, null);

            var model = new ManagementTableViewModel(tableModel, nameof(CreateCurrency), nameof(EditCurrency), nameof(DeleteCurrency));

            return View(model);
        }

        public IActionResult CreateCurrency()
        {
            var tableModel = GetTableModel(null, null);
            var model = tableModel.GetNewRow().ToList();

            ViewData["Action"] = nameof(CreateCurrency);
            return PartialView("TableEditor/_TableCreate", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCurrency(CurrencyManagementModel currency)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _currencyManagementService.CreateCurrency(currency);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(CreateCurrency));
            }
        }

        public IActionResult EditCurrency(int id)
        {
            var currency = _currencyManagementService.GetCurrency(id);

            var tableModel = GetTableModel(null, currency);
            var model = tableModel.GetCurrentRow().ToList();

            ViewData["Action"] = nameof(EditCurrency);
            return PartialView("TableEditor/_TableEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCurrency(CurrencyManagementModel currency)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _currencyManagementService.UpdateCurrency(currency);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(EditCurrency));
            }
        }

        public IActionResult DeleteCurrency(int? id)
        {
            var model = _currencyManagementService.GetCurrency(id.Value);

            if (model == null)
                return RedirectToAction(nameof(Index));

            ViewData["Name"] = model.Name;
            ViewData["Action"] = nameof(DeleteCurrency);
            return PartialView("TableEditor/_TableDelete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCurrency(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _currencyManagementService.DeleteCurrency(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(DeleteCurrency));
            }
        }

        public IActionResult IndexExchangeRates(int id)
        {
            var currency = _currencyManagementService.GetCurrency(id);
            var tableModel = GetExchangeTableModel(currency.ExchangeRate, null, currency.Name);

            var model = new ManagementTableViewModel(tableModel, $"{nameof(CreateExchangeRate)}/{id}", nameof(EditExchangeRate), nameof(DeleteExchangeRate), editRouteValues: new Dictionary<string, string> { { "currencyId", id.ToString() } }, deleteRouteValues: new Dictionary<string, string> { { "currencyId", id.ToString() } });

            return View("TableEditor/_Table", model);
        }

        public IActionResult CreateExchangeRate(int id)
        {
            var currency = _currencyManagementService.GetCurrency(id);
            var tableModel = GetExchangeTableModel(null, null, currency.Name);
            var model = tableModel.GetNewRow(new Dictionary<string, string> { { "CurrencyId", id.ToString() } }).ToList();

            ViewData["Action"] = nameof(CreateExchangeRate);
            return PartialView("TableEditor/_TableCreate", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateExchangeRate(CurrencyExchangeRateManagementModel rate)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _currencyManagementService.CreateExchangeRate(rate);
                }

                return RedirectToAction(nameof(IndexExchangeRates), new { id = rate.CurrencyId });
            }
            catch
            {
                return RedirectToAction(nameof(CreateExchangeRate));
            }
        }

        public IActionResult EditExchangeRate(int id, int currencyId)
        {
            var currency = _currencyManagementService.GetCurrency(currencyId);
            var rate = currency.ExchangeRate.FirstOrDefault(r => r.CurrencyPairId == id);

            var tableModel = GetExchangeTableModel(null, rate, currency.Name);
            var model = tableModel.GetCurrentRow().ToList();

            ViewData["Action"] = nameof(EditExchangeRate);
            return PartialView("TableEditor/_TableEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExchangeRate(CurrencyExchangeRateManagementModel rate)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _currencyManagementService.UpdateExchangeRate(rate);
                }

                return RedirectToAction(nameof(IndexExchangeRates), new { id = rate.CurrencyId });
            }
            catch
            {
                return RedirectToAction(nameof(EditExchangeRate));
            }
        }

        public IActionResult DeleteExchangeRate(int? id, int currencyId)
        {
            var model = _currencyManagementService.GetCurrency(currencyId).ExchangeRate.FirstOrDefault(r => r.CurrencyPairId == id);

            if (model == null)
                return RedirectToAction(nameof(IndexExchangeRates));

            var data = new Dictionary<string, string>{
                { "CurrencyPairId", id.Value.ToString() },
                { "CurrencyId", currencyId.ToString() }
            };

            ViewData["Name"] = string.Empty;
            ViewData["Action"] = nameof(DeleteExchangeRate);
            ViewData["Data"] = data;
            return PartialView("TableEditor/_TableDelete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteExchangeRate(CurrencyExchangeRateManagementModel exchangeRate)
        {
            try
            {
                // TODO: Add delete logic here
                var rate = _currencyManagementService.GetCurrency(exchangeRate.CurrencyId).ExchangeRate.FirstOrDefault(r => r.CurrencyPairId == exchangeRate.CurrencyPairId);
                _currencyManagementService.DeleteExchangeRate(rate);

                return RedirectToAction(nameof(IndexExchangeRates), new { id = rate.CurrencyId });
            }
            catch
            {
                return RedirectToAction(nameof(DeleteCurrency));
            }
        }
    }
}