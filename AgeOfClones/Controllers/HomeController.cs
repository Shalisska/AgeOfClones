using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
