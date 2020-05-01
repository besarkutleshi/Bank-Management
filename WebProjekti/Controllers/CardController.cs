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
        private readonly ClientRepository _clientRepository;
        private readonly CheckingAccountRepository _accountRepository;
        public CardController(ClientRepository clientRepository, CheckingAccountRepository accountRepository)
        {
            _clientRepository = clientRepository;
            _accountRepository = accountRepository;
        }
        [HttpGet]
        public async Task<IActionResult> CreateCard()
        {
            ViewBag.Clients = await _clientRepository.Read();
            return View();
        }

        public async Task<IActionResult> CreateCard(Accounts obj,string type,decimal interes)
        {
            switch (type)
            {
                case "CheckingAccount":
                    CheckingAccounts checkingAccounts = new CheckingAccounts();
                    obj.StartDate = DateTime.Now;
                    checkingAccounts.Account = obj;
                    checkingAccounts.Interes = interes;
                    if (await _accountRepository.Insert(checkingAccounts) != null)
                        return RedirectToAction("ListCards");
                    break;
                case "SavingAccount":
                    SavingAccounts savingAccounts = new SavingAccounts();
                    savingAccounts.Account = obj;
                    if (await _accountRepository.Insert(savingAccounts) != null)
                        return RedirectToAction("ListCards");
                    break;
            }
            ViewBag.ErrorMessage = "Registration not successful";
            return View("Error");
        }
    }
}