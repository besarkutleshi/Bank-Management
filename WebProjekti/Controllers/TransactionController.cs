using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Cards;
using DataAccessLayer.Credit;
using DataAccessLayer.Reports;
using EntityLayer.Accounts;
using EntityLayer.Credits;
using EntityLayer.Transactions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebProjekti.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly AccountRepository _accountRepository;
        private readonly AccountReports _accountReports;
        private readonly CreditRepository _creditRepository;
        private static Accounts CurrentAccount;
        public TransactionController(TransactionRepository transactionRepository, AccountRepository accountRepository, AccountReports accountReports
            ,CreditRepository creditRepository)
        {
            this._transactionRepository = transactionRepository;
            this._accountRepository = accountRepository;
            this._accountReports = accountReports;
            this._creditRepository = creditRepository;
        }

        [HttpGet]
        public IActionResult Transfer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakeTransfer(Transfer obj)
        {
            try
            {
                obj.ClientID = _accountRepository.GetId(obj.AccountNumber);
                obj.ExecutionDate = DateTime.Now;
                Accounts toAcc = _accountRepository.GetAccount(obj.ToAccountNumber);
                if(toAcc == null)
                {
                    return DisplayError("Not Successful", "This Account Not Exist");
                }
                if (await _transactionRepository.Insert(obj) != null)
                {
                    return RedirectToAction("ConfirmTransaction");
                }
                return DisplayError("Not Successful", "Something went wrong");
            }
            catch (Exception ex)
            {
                return DisplayError("Not Successful", ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ConfirmTransaction()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Deposit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakeDeposit(Deposit obj)
        {
            try
            {
                GetAtributes(obj);
                Accounts acc = _accountRepository.GetAccount(obj.AccountNumber);
                if (acc == null)
                {
                    return DisplayError("Not Successful", "This Account Not Exist");
                }
                if (await _transactionRepository.Insert(obj) != null)
                {
                    return RedirectToAction("ConfirmTransaction");
                }
                return DisplayError("Not Successful", "Something went wrong");
            }
            catch (Exception ex)
            {
                return DisplayError("Not Successful", ex.Message);
            }
        }

        private IActionResult DisplayError(string title ,string message)
        {
            ViewBag.ErrorTitle = title;
            ViewBag.ErrorMessage = message;
            return View("Error");
        }

        private void GetAtributes(Transaction obj)
        {
            obj.ClientID = (int)AccountController.CurrentClient.Id;
            obj.ExecutionDate = DateTime.Now;
        }

        [HttpGet]
        public IActionResult WithDrawal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakeWithDrawal(WithDrawal obj)
        {
            try
            {
                GetAtributes(obj);
                Accounts acc = _accountRepository.GetAccount(obj.AccountNumber);
                if (acc == null)
                {
                    return DisplayError("Not Successful", "This Account Not Exist");
                }
                if (await _transactionRepository.Insert(obj) != null)
                {
                    return RedirectToAction("ConfirmTransaction");
                }
                return DisplayError("Not Successful", "Something went wrong");
            }
            catch (Exception ex)
            {
                return DisplayError("Not Successful", ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListDeposits()
        {
            List<Deposit> deposits = await _transactionRepository.GetDeposits((int)AccountController.CurrentClient.Id);
            ViewBag.DepositsCount = Count(deposits);
            ViewBag.TransferCount = Count(await _transactionRepository.GetTransfers((int)AccountController.CurrentClient.Id));
            ViewBag.DrawalsCount = Count(await _transactionRepository.GetWithDrawals((int)AccountController.CurrentClient.Id));
            return View(deposits);
        } 

        private int Count<T>(List<T> ts)
        {
            if(ts == null)
            {
                return 0;
            }
            return ts.Count;
        }

        [HttpGet]
        public async Task<IActionResult> ListTransfers()
        {
            List<Transfer> transfers = await _transactionRepository.GetTransfers((int)AccountController.CurrentClient.Id);
            ViewBag.TransferCount = Count(transfers);
            ViewBag.DrawalsCount = Count(await _transactionRepository.GetWithDrawals((int)AccountController.CurrentClient.Id));
            ViewBag.DepositsCount = Count(await _transactionRepository.GetDeposits((int)AccountController.CurrentClient.Id));
            return View(transfers);
        }

        [HttpGet]
        public async Task<IActionResult> ListDrawals()
        {
            List<WithDrawal> drawals = await _transactionRepository.GetWithDrawals((int)AccountController.CurrentClient.Id);
            ViewBag.DrawalsCount = Count(drawals);
            ViewBag.TransferCount = Count(await _transactionRepository.GetTransfers((int)AccountController.CurrentClient.Id));
            ViewBag.DepositsCount = Count(await _transactionRepository.GetDeposits((int)AccountController.CurrentClient.Id));
            return View(drawals);
        }

        [HttpGet]
        public async Task<IActionResult> Balance(string id)
        {
            ViewBag.Balance = _accountRepository.GetBalance(id);
            ViewBag.DataDeposits = JsonConvert.SerializeObject(await _accountReports.GetRaports(id, "sp_GetDepositsForMonth"));
            ViewBag.DataTransfers = JsonConvert.SerializeObject(await _accountReports.GetRaports(id, "sp_GetTransfersForMonth"));
            ViewBag.DataDrawals = JsonConvert.SerializeObject(await _accountReports.GetRaports(id, "sp_GetDrawalsForMonth"));
            ViewBag.LastDeposits = await _accountReports.GetDeposits(id);
            ViewBag.LastTransfers = await _accountReports.GetTransfers(id);
            ViewBag.LastDrawals = await _accountReports.GetWithDrawals(id);
            return View();
        }

        [HttpGet]
        public IActionResult PayCredit()
        {
            return View();
        }

        public async Task<IActionResult> PayCredit(PayCredit payCredit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetAtributes(payCredit);
                    Credits credits = await _creditRepository.GetCredit(payCredit.CreditNumber);
                    if (credits == null)
                    {
                        return DisplayError("Not Successful", "This Credit Not Exist");
                    }
                    Accounts acc = _accountRepository.GetAccount(payCredit.AccountNumber);
                    if (acc == null)
                    {
                        return DisplayError("Not Successful", "This Account Not Exist");
                    }
                    if (await _transactionRepository.PayCredit(payCredit) != null)
                    {
                        return RedirectToAction("ConfirmTransaction");
                    }
                }
                return DisplayError("Not Successful", "This Account Not Exist");
            }
            catch (Exception ex)
            { 
                return DisplayError("Not Successful", ex.Message);
            }
        }

        public async Task<IActionResult> ListPayment(string email)
        {

        }

    }
}