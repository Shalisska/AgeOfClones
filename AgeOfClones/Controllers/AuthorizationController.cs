using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Management.Interfaces;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.Management.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AgeOfClones.Controllers
{
    public class AuthorizationController : Controller
    {
        IProfileManagementService _profileManagementService;
        IAuthorizationService _authorizationService;

        public AuthorizationController(
            IProfileManagementService profileManagementService,
            IAuthorizationService authorizationService)
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
            await Authenticate(account.Name);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountManagementModel model)
        {
            if (ModelState.IsValid)
            {
                await Authenticate(model.Name); // аутентификация

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
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