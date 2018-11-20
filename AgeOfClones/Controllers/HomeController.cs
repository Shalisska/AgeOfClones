using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgeOfClones.Models;
using Infrastructure.Data.EF;
using Application.Interfaces;

namespace AgeOfClones.Controllers
{
    public class HomeController : Controller
    {
        IAuthorizationService _authorizationService;

        public HomeController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public IActionResult Index()
        {
            var model = _authorizationService.GetProfiles();
            ViewData["User"] = User.Identity.Name ?? "none";

            return View(model);
        }

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
