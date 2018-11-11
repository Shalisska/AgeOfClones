using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgeOfClones.Models;
using Infrastructure.Data.EF;

namespace AgeOfClones.Controllers
{
    public class HomeController : Controller
    {
        ClonesContextEF _clonesContext;

        public HomeController(ClonesContextEF clonesContext)
        {
            _clonesContext = clonesContext;
        }

        public IActionResult Index()
        {
            var model = _clonesContext.Profiles?.ToList();

            return View(model);
        }

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
