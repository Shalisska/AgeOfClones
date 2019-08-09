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
    public class ProfileController : Controller
    {
        IProfileManagementService _profileManagementService;
        ITableEditorService _tableEditorService;

        public ProfileController(
            IProfileManagementService profileManagementService,
            ITableEditorService tableEditorService)
        {
            _profileManagementService = profileManagementService;
            _tableEditorService = tableEditorService;
        }

        #region Profile
        public IActionResult Index()
        {
            var loadActionName = "Profiles";
            var updateActionName = "UpdateProfile";
            var createActionName = "CreateProfile";
            var deleteActionName = "DeleteProfile";

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

        [HttpGet("profiles")]
        public object Profiles(DataSourceLoadOptions loadOptions)
        {
            var source = _profileManagementService.GetProfiles().Select(r => new
            {
                r.Id,
                r.Name
            });

            loadOptions.PrimaryKey = new[] { "Id" };
            loadOptions.PaginateViaPrimaryKey = true;

            return DataSourceLoader.Load(source, loadOptions);
        }

        [HttpPut("update-profile")]
        public IActionResult UpdateProfile(int key, string values)
        {
            var profile = _profileManagementService.GetProfile(key);
            if (profile == null)
                return StatusCode(409, "Profile not found");

            JsonConvert.PopulateObject(values, profile);

            if (!TryValidateModel(profile))
                return BadRequest(ModelState.ToFullErrorString());

            _profileManagementService.UpdateProfile(profile);

            return Ok();
        }

        [HttpPost("create-profile")]
        public IActionResult CreateProfile(string values)
        {
            var profile = new ProfileManagementModel();
            JsonConvert.PopulateObject(values, profile);

            if (!TryValidateModel(profile))
                return BadRequest(ModelState.ToFullErrorString());

            _profileManagementService.CreateProfile(profile);

            return Json(profile.Id);
        }

        [HttpDelete("delete-profile")]
        public IActionResult DeleteProfile(int key)
        {
            var profile = _profileManagementService.GetProfile(key);
            if (profile == null)
                return StatusCode(409, "Profile not found");

            _profileManagementService.DeleteProfile(key);

            return Ok();
        }
        #endregion Profile

        #region Account
        public IActionResult IndexAccount()
        {
            var loadActionName = "Accounts";
            var updateActionName = "UpdateAccount";
            var createActionName = "CreateAccount";
            var deleteActionName = "DeleteAccount";
            var profileLookupActionName = "ProfileLookup";

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
                DataField = "profileId",
                Caption = "Profile",
                Lookup = new DEGridTableLookup
                {
                    ValueExpr = "value",
                    DisplayExpr = "text",
                    DataSource = new DEGridTableDataSource
                    {
                        Type = "createStore",
                        Key = "value",
                        LoadUrl = Url.Action(profileLookupActionName)
                    }
                }
            });

            var gridTable = new DEGridTable
            {
                DataSource = source,
                Columns = columns
            };

            return View("DevExpressTmpl/_GridTable", gridTable);
        }

        [HttpGet("accounts")]
        public object Accounts(DataSourceLoadOptions loadOptions)
        {
            var source = _profileManagementService.GetAccounts().Select(s => new
            {
                s.Id,
                s.Name,
                s.ProfileId
            });

            loadOptions.PrimaryKey = new[] { "Id" };
            loadOptions.PaginateViaPrimaryKey = true;

            return DataSourceLoader.Load(source, loadOptions);
        }

        [HttpGet("profile-lookup")]
        public object ProfileLookup(DataSourceLoadOptions options)
        {
            return DataSourceLoader.Load(
                from s in _profileManagementService.GetProfiles()
                orderby s.Name
                select new
                {
                    Value = s.Id,
                    Text = s.Name
                },
                options
            );
        }

        [HttpPut("update-account")]
        public IActionResult UpdateAccount(int key, string values)
        {
            var res = _profileManagementService.GetAccount(key);
            if (res == null)
                return StatusCode(409, "Account not found");

            JsonConvert.PopulateObject(values, res);

            if (!TryValidateModel(res))
                return BadRequest(ModelState.ToFullErrorString());

            _profileManagementService.UpdateAccount(res);

            return Ok();
        }

        [HttpPost("create-account")]
        public IActionResult CreateAccount(string values)
        {
            var account = new AccountManagementModel();
            JsonConvert.PopulateObject(values, account);

            if (!TryValidateModel(account))
                return BadRequest(ModelState.ToFullErrorString());

            _profileManagementService.CreateAccount(account);

            return Json(account.Id);
        }

        [HttpDelete("delete-account")]
        public IActionResult DeleteAccount(int key)
        {
            var account = _profileManagementService.GetAccount(key);
            if (account == null)
                return StatusCode(409, "Account not found");

            _profileManagementService.DeleteAccount(key);

            return Ok();
        }
        #endregion Account
    }
}