using AgeOfClones.Models;
using Application.Interfaces;
using Application.Management.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AgeOfClones.Controllers
{
    public class HomeController : Controller
    {
        IAuthorizationServiceM _authorizationService;
        IAccountService _accountService;
        ICurrencyManagementService _currencyManagementService;

        public HomeController(
            IAuthorizationServiceM authorizationService,
            IAccountService accountService,
            ICurrencyManagementService currencyManagementService)
        {
            _authorizationService = authorizationService;
            _accountService = accountService;
            _currencyManagementService = currencyManagementService;
        }

        public IActionResult Index()
        {
            var model = _accountService.GetProfiles();

            ViewData["User"] = User.Identity.Name ?? "none";

            return View(model);
        }

        [Authorize]
        public IActionResult BuyCurrency(int currencyId)
        {
            var currencies = _currencyManagementService.GetCurrencies();

            var model = new TransactionViewModel(
                $"Home/{nameof(UpdateCurrency)}",
                currencyId,
                currencies.FirstOrDefault(c => c.Id == currencyId).Name,
                new SelectList(currencies, "Id", "Name"),
                0,
                0,
                false);

            return PartialView("_Transaction", model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuyCurrency(int currencyId, decimal value, int correspondingId, bool canDoOperation)
        {
            var accountId = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var accountIdInt = int.Parse(accountId);
            var account = _accountService.GetAccount(accountIdInt);

            _accountService.BuyCurrency(account, currencyId, correspondingId, value);

            return RedirectToAction(nameof(Index));
        }

        //[Authorize]
        [HttpPost]
        public IActionResult UpdateCurrency([FromBody] TransactionInput input)
        {
            var currencies = _currencyManagementService.GetCurrencies();
            var pricePerOne = currencies.FirstOrDefault(c => c.Id == input.CurrencyId).ExchangeRate.FirstOrDefault(r => r.CurrencyPairId == input.CorrespondingId).Sell;

            var model = new TransactionViewModel(
                $"Home/{nameof(UpdateCurrency)}",
                input.CurrencyId,
                currencies.FirstOrDefault(c => c.Id == input.CurrencyId).Name,
                new SelectList(currencies, "Id", "Name"),
                input.Value,
                pricePerOne,
                true);

            return PartialView("_Transaction", model);
        }

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
