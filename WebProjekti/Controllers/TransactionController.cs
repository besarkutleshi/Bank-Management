using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Cards;
using EntityLayer.Accounts;
using EntityLayer.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace WebProjekti.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly AccountRepository _accountRepository;
        private static Accounts CurrentAccount;
        public TransactionController(TransactionRepository transactionRepository, AccountRepository accountRepository)
        {
            this._transactionRepository = transactionRepository;
            this._accountRepository = accountRepository;
            CurrentAccount = _accountRepository.GetAccount((int)AccountController.CurrentClient.PersonId);
        }

        [HttpGet]
        public IActionResult Transfer()
        {
            if(CurrentAccount != null)
            {
                ViewBag.AccountNumber = CurrentAccount.AccountNumber;
                ViewBag.CardNumber = CurrentAccount.CardNumber;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(Transfer obj)
        {
            try
            {
                if (await _transactionRepository.Insert(obj) != null)
                {
                    return RedirectToAction("ConfirmTransaction");
                }
                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}