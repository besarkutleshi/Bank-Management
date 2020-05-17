using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Persons;
using DataAccessLayer.Cards;
using EntityLayer.Persons;
using EntityLayer.Accounts;
namespace WebProjekti.Controllers
{
    public class CardController : Controller
    {
        private readonly PersonRepository _personRepository;
        private readonly AccountRepository _accountRepository;
        public CardController(PersonRepository personRepository,
            AccountRepository savingAccounts)
        {
            _personRepository = personRepository;
            _accountRepository = savingAccounts;
        }
        [HttpGet]
        public async Task<IActionResult> InsertSavingAccount()
        {
            ViewBag.Clients = await _personRepository.GetPersons();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertSavingAccount(SavingAccounts obj)
        {
            obj.Account.StartDate = DateTime.Now;
            if (await _accountRepository.Insert(obj) != null)
            {
                return RedirectToAction("AccountsList");
            }
            ViewBag.ErrorTitle = $"Error";
            ViewBag.ErrorMessage = $"Not Register";
            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> InsertCheckingAccount()
        {
            ViewBag.Clients = await _personRepository.GetPersons();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertCheckingAccount(CheckingAccounts obj)
        {
            obj.Account.StartDate = DateTime.Now;
            if (await _accountRepository.Insert(obj) != null)
            {
                return RedirectToAction("AccountsList");
            }
            ViewBag.ErrorTitle = $"Error";
            ViewBag.ErrorMessage = $"Not Register";
            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> AccountsList()
        {
            var checkingaccounts = await _accountRepository.ReadChecking();
            ViewBag.CheckingAccountCount = checkingaccounts.Select(ch => ch).Count<CheckingAccounts>();
            var savingaccounts = await _accountRepository.ReadSaving();
            ViewBag.SavingAccountCount = savingaccounts.Select(ch => ch).Count<SavingAccounts>();
            List<Accounts> accounts = await _accountRepository.GetAccounts();
            return View(accounts);
        }


        [HttpGet]
        public async Task<IActionResult> MyCheckingAccounts(string email)
        {
            List<CheckingAccounts> checkingAccounts = await _accountRepository.ReadChecking(email);
            return View(checkingAccounts);
        }

        [HttpGet]
        public async Task<IActionResult> MySavingAccounts(string email)
        {
            List<SavingAccounts> savingAccounts = await _accountRepository.ReadSaving(email);
            return View(savingAccounts);
        }

        [HttpGet]
        public async Task<IActionResult> CheckingAccountDetails(string id)
        {
            CheckingAccounts obj = await _accountRepository.CheckingAccountsDetails(id);
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> SavingAccountDetails(string id)
        {
            SavingAccounts obj = await _accountRepository.SavingAccountsDetails(id);
            return View(obj);
        }
    }
}