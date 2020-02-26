using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccountsCodingChallenge.Models;

namespace AccountsCodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAccountService _accountService;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public IActionResult AccountStatuses()
        {
            var accounts = _accountService.GetAccountsAsync().Result;
            if(accounts.Count == 0)
            {
                return Error();
            }

            var accountLists = new AccountListsModel()
            {
                activeAccounts = _accountService.GetActiveAccounts(accounts),
                inactiveAccounts = _accountService.GetInctiveAccounts(accounts),
                overdueAccounts = _accountService.GetOverdueAccounts(accounts)
            };

            return View(accountLists);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
