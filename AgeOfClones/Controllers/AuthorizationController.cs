using Application.Interfaces;
using Application.Management.Interfaces;
using Application.Management.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AgeOfClones.Controllers
{
    public class AuthorizationController : Controller
    {
        IProfileManagementService _profileManagementService;
        IAuthorizationServiceM _authorizationService;

        public AuthorizationController(
            IProfileManagementService profileManagementService,
            IAuthorizationServiceM authorizationService)
        {
            _profileManagementService = profileManagementService;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _authorizationService.GetAccounts();
            return PartialView(model);
        }

        public async Task<IActionResult> Login(int id)
        {
            var account = _authorizationService.GetAccount(id);

            if (account == null)
                return RedirectToAction("Index", "Home");

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await Authenticate(account.Name, id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountManagementModel model)
        {
            if (ModelState.IsValid)
            {
                await Authenticate(model.Name, model.Id); // аутентификация

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private async Task Authenticate(string userName, int userId)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}