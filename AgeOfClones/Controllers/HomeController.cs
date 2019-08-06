using Application.Interfaces;
using Application.Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgeOfClones.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<ProfileManagementModel>();

            return View(model);
        }
    }
}
