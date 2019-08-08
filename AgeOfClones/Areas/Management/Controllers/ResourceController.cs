using AgeOfClones.Utils;
using Application.Management.Interfaces;
using Application.Management.Models;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace AgeOfClones.Areas.Management.Controllers
{
    [Area("Management")]
    public class ResourceController : Controller
    {
        IResourceManagementService _resourceManagementService;

        public ResourceController(
            IResourceManagementService resourceManagementService)
        {
            _resourceManagementService = resourceManagementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("resources")]
        public object Resources(DataSourceLoadOptions loadOptions)
        {
            var source = _resourceManagementService.GetResources().Select(r => new
            {
                r.Id,
                r.Name,
                r.PriceBase,
                r.Price,
                r.StockId
            });

            loadOptions.PrimaryKey = new[] { "Id" };
            loadOptions.PaginateViaPrimaryKey = true;

            return DataSourceLoader.Load(source, loadOptions);
        }

        [HttpGet("stocks-lookup")]
        public object StocksLookup(DataSourceLoadOptions options)
        {
            return DataSourceLoader.Load(
                from s in _resourceManagementService.GetStocks()
                orderby s.Name
                select new
                {
                    Value = s.Id,
                    Text = s.Name
                },
                options
            );
        }

        [HttpPut("update-resource")]
        public IActionResult UpdateResource(int key, string values)
        {
            var res = _resourceManagementService.GetResource(key);
            if (res == null)
                return StatusCode(409, "Resource not found");

            JsonConvert.PopulateObject(values, res);

            if (!TryValidateModel(res))
                return BadRequest(ModelState.ToFullErrorString());

            _resourceManagementService.UpdateResource(res);

            return Ok();
        }

        [HttpPost("create-resource")]
        public IActionResult CreateResource(string values)
        {
            var resource = new ResourceManagementModel();
            JsonConvert.PopulateObject(values, resource);

            if (!TryValidateModel(resource))
                return BadRequest(ModelState.ToFullErrorString());

            _resourceManagementService.CreateResource(resource);

            return Json(resource.Id);
        }
        
        [HttpDelete("delete-resource")]
        public IActionResult DeleteOrder(int key)
        {
            var resource = _resourceManagementService.GetResource(key);
            if (resource == null)
                return StatusCode(409, "Resource not found");

            _resourceManagementService.DeleteResource(key);

            return Ok();
        }

        public ActionResult UpdateResourcesFromXML()
        {
            _resourceManagementService.UpdateFromXML();

            return RedirectToAction(nameof(Index));
        }
    }
}