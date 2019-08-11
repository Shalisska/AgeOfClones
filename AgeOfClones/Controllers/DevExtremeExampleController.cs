using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AgeOfClones.Controllers
{
    public class DevExtremeExampleController : Controller
    {
        [Route("dev")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("SearchApi1")]
        public IActionResult SearchApi()
        {
            return View();
        }

        [Route("GroupedList1")]
        public IActionResult GroupedList()
        {
            return View();
        }
    }
}