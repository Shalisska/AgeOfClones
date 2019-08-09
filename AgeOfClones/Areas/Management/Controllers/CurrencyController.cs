using AgeOfClones.Areas.Management.Models;
using AgeOfClones.Models;
using AgeOfClones.Utils;
using Application.Interfaces;
using Application.Management.Interfaces;
using Application.Management.Models;
using Application.Models.TableEditor;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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

        public IActionResult Index()
        {
            var loadActionName = "Currencies";
            var updateActionName = "UpdateCurrency";
            var createActionName = "CreateCurrency";
            var deleteActionName = "DeleteCurrency";
            var stocksLookupActionName = "StocksLookup";

            var source = new DEGridTableDataSource
            {
                Type = "createStore",
                Key = "id",
                LoadUrl = Url.Action(loadActionName),
                UpdateUrl = Url.Action(updateActionName),
                CreateUrl = Url.Action(createActionName),
                DeleteUrl = Url.Action(deleteActionName)
            };

            var columns = new List<DEGridTableColumn>();
            columns.Add(new DEGridTableColumn("id"));
            columns.Add(new DEGridTableColumn("name"));
            columns.Add(new DEGridTableColumn
            {
                IsSimple = false,
                DataField = "stockId",
                Caption = "Stock",
                Lookup = new DEGridTableLookup
                {
                    ValueExpr = "value",
                    DisplayExpr = "text",
                    DataSource = new DEGridTableDataSource
                    {
                        Type = "createStore",
                        Key = "value",
                        LoadUrl = Url.Action(stocksLookupActionName)
                    }
                }
            });

            var gridTable = new DEGridTable
            {
                DataSource = source,
                Columns = columns
            };

            return View(gridTable);
        }

        [HttpGet("currencies")]
        public object Currencies(DataSourceLoadOptions loadOptions)
        {
            var source = _currencyManagementService.GetCurrencies().Select(s => new
            {
                s.Id,
                s.Name,
                s.StockId
            });

            loadOptions.PrimaryKey = new[] { "Id" };
            loadOptions.PaginateViaPrimaryKey = true;

            return DataSourceLoader.Load(source, loadOptions);
        }

        [HttpGet]
        public object StocksLookup(DataSourceLoadOptions options)
        {
            return DataSourceLoader.Load(
                from s in _stockManagementService.GetStocks()
                orderby s.Name
                select new
                {
                    Value = s.Id,
                    Text = s.Name
                },
                options
            );
        }

        [HttpPut("update-currency")]
        public IActionResult UpdateCurrency(int key, string values)
        {
            var res = _currencyManagementService.GetCurrency(key);
            if (res == null)
                return StatusCode(409, "Currency not found");

            JsonConvert.PopulateObject(values, res);

            if (!TryValidateModel(res))
                return BadRequest(ModelState.ToFullErrorString());

            _currencyManagementService.UpdateCurrency(res);

            return Ok();
        }

        [HttpPost("create-currency")]
        public IActionResult CreateCurrency(string values)
        {
            var currency = new CurrencyManagementModel();
            JsonConvert.PopulateObject(values, currency);

            if (!TryValidateModel(currency))
                return BadRequest(ModelState.ToFullErrorString());

            _currencyManagementService.CreateCurrency(currency);

            return Json(currency.Id);
        }

        [HttpDelete("delete-currency")]
        public IActionResult DeleteCurrency(int key)
        {
            var currency = _currencyManagementService.GetCurrency(key);
            if (currency == null)
                return StatusCode(409, "Currency not found");

            _currencyManagementService.DeleteCurrency(key);

            return Ok();
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

        [HttpGet]
        public object ExchangeRates(int id, DataSourceLoadOptions loadOptions)
        {
            var source = _currencyManagementService.GetCurrency(id).ExchangeRate
                .Select(s => new
                {
                    s.CurrencyId,
                    s.CurrencyPairId,
                    s.Buy,
                    s.Sell
                });

            return DataSourceLoader.Load(source, loadOptions);
        }

        [HttpPut]
        public IActionResult UpdateExchangeRate(string key, string values)
        {
            var keys = new Dictionary<string, int>();
            JsonConvert.PopulateObject(key, keys);

            var rate = _currencyManagementService.GetExchangeRate(keys["currencyId"], keys["currencyPairId"]);

            if (rate == null)
                return StatusCode(409, "CurrencyRate not found");

            JsonConvert.PopulateObject(values, rate);

            if (!TryValidateModel(rate))
                return BadRequest(ModelState.ToFullErrorString());

            _currencyManagementService.UpdateExchangeRate(rate);

            return Ok();
        }

        [HttpPost]
        public IActionResult CreateExchangeRate(string values)
        {
            var rate = new CurrencyExchangeRateManagementModel();
            JsonConvert.PopulateObject(values, rate);

            if (!TryValidateModel(rate))
                return BadRequest(ModelState.ToFullErrorString());

            _currencyManagementService.CreateExchangeRate(rate);

            return Json(new { rate.CurrencyId, rate.CurrencyPairId });
        }

        [HttpDelete]
        public IActionResult DeleteExchangeRate(string key)
        {
            var keys = new Dictionary<string, int>();
            JsonConvert.PopulateObject(key, keys);

            var rate = _currencyManagementService.GetExchangeRate(keys["currencyId"], keys["currencyPairId"]);

            if (rate == null)
                return StatusCode(409, "CurrencyRate not found");

            _currencyManagementService.DeleteExchangeRate(rate);

            return Ok();
        }
    }
}