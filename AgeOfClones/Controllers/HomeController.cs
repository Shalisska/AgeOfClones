using Application.Interfaces;
using Application.Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgeOfClones.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("SearchApi")]
        public IActionResult SearchApi()
        {
            return View();
        }

        [Route("GroupedList")]
        public IActionResult GroupedList()
        {
            return View();
        }

        //public IActionResult Index()
        //{
        //    var model = new List<ProfileManagementModel>();

        //    return View(model);
        //}
    }
}
