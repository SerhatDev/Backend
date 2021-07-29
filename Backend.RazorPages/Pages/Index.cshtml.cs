using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.RazorPages.Pages
{

    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {

        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICountryRepository _countryRepository;

        public string resultMessage { get; set; }

        public IndexModel(
            IUserRepository userRepo,
            ITransactionRepository transactionRepo,
            ICountryRepository countryRepository)
        {
            this._userRepository = userRepo;
            this._transactionRepository = transactionRepo;
            this._countryRepository = countryRepository;
        }

        public IActionResult OnGetUser(int userId)
        {
            var user = _userRepository.Query(x => x.Id == userId).SingleOrDefault();

            return new JsonResult(user);
        }
        public IActionResult OnGetAllUsers()
        {
            return new JsonResult(_userRepository.GetAll());
        }

        public IActionResult OnPostDeposit(int userId,decimal amount)
        {
            var user = _userRepository.Query(x => x.Id == userId).SingleOrDefault();
            var transactionResult= _transactionRepository.Deposit(user, amount);

            return new JsonResult(transactionResult);
        }
        public IActionResult OnPostWithdraw(int userId,decimal amount)
        {
            var user = _userRepository.Query(x => x.Id == userId).SingleOrDefault();
            var transactionResult = _transactionRepository.Withdraw(user, amount);

            return new JsonResult(transactionResult);
        }

        public void OnGet()
        {
            var testUser = _userRepository.Query(x => x.Id == 1).SingleOrDefault();

            var result = _transactionRepository.Deposit(testUser, 10);

            resultMessage = result.exceptionMessage;
        }
    }
}
