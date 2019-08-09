using AgeOfClones.Models;
using AgeOfClones.Utils;
using Application.Management.Interfaces;
using Application.Management.Models;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AgeOfClones.Areas.Management.Controllers
{
    [Area("Management")]
    public class StockController : Controller
    {
        IStockManagementService _stockManagementService;

        public StockController(
            IStockManagementService stockManagementService)
        {
            _stockManagementService = stockManagementService;
        }

        public IActionResult Index()
        {
            var loadActionName = "Stocks";
            var updateActionName = "UpdateStock";
            var createActionName = "CreateStock";
            var deleteActionName = "DeleteStock";

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

            var gridTable = new DEGridTable
            {
                DataSource = source,
                Columns = columns
            };

            return View("DevExpressTmpl/_GridTable", gridTable);
        }

        [HttpGet("stocks")]
        public object Stocks(DataSourceLoadOptions loadOptions)
        {
            var source = _stockManagementService.GetStocks().Select(r => new
            {
                r.Id,
                r.Name
            });

            loadOptions.PrimaryKey = new[] { "Id" };
            loadOptions.PaginateViaPrimaryKey = true;

            return DataSourceLoader.Load(source, loadOptions);
        }

        [HttpPut("update-stock")]
        public IActionResult UpdateStock(int key, string values)
        {
            var res = _stockManagementService.GetStock(key);
            if (res == null)
                return StatusCode(409, "Stock not found");

            JsonConvert.PopulateObject(values, res);

            if (!TryValidateModel(res))
                return BadRequest(ModelState.ToFullErrorString());

            _stockManagementService.UpdateStock(res);

            return Ok();
        }

        [HttpPost("create-stock")]
        public IActionResult CreateStock(string values)
        {
            var stock = new StockManagementModel();
            JsonConvert.PopulateObject(values, stock);

            if (!TryValidateModel(stock))
                return BadRequest(ModelState.ToFullErrorString());

            _stockManagementService.CreateStock(stock);

            return Json(stock.Id);
        }

        [HttpDelete("delete-stock")]
        public IActionResult DeleteStock(int key)
        {
            var stock = _stockManagementService.GetStock(key);
            if (stock == null)
                return StatusCode(409, "Stock not found");

            _stockManagementService.DeleteStock(key);

            return Ok();
        }
    }
}