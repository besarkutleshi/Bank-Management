using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Credit;
using DataAccessLayer.Persons;
using EntityLayer.Credits;
using EntityLayer.Persons;
using Microsoft.AspNetCore.Mvc;

namespace WebProjekti.Controllers
{
    public class CreditController : Controller
    {
        private readonly CreditRepository _creditRepository;
        private readonly ClientRepository _clientRepository;

        public CreditController(CreditRepository creditRepository, ClientRepository clientRepository)
        {
            _creditRepository = creditRepository;
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> InsertCredit()
        {
            ViewBag.Clients = await _clientRepository.Read();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertCredit(Credits obj)
        {
            if(await _creditRepository.InsertCredit(obj) != null)
            {
                return RedirectToAction("ListCredits");
            }
            ViewBag.ErrorTitle = $"Error";
            ViewBag.ErrorMessage = $"Not Register";
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCredit(int id)
        {
            if(await _creditRepository.DeleteCredit(id) != -1)
            {
                return RedirectToAction("ListCredits");
            }
            ViewBag.ErrorTitle = $"Error";
            ViewBag.ErrorMessage = $"Not Deleted";
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCredit(Credits obj)
        {
            if(await _creditRepository.UpdateCredit(obj) != null)
            {
                return RedirectToAction("ListCredits");
            }
            ViewBag.ErrorTitle = $"Error";
            ViewBag.ErrorMessage = $"Not Upddated";
            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> ListCredits()
        {
            List<Credits> credits = await _creditRepository.GetCredits();
            return View(credits);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCredit(int id)
        {
            Credits obj = await _creditRepository.GetCredit(id);
            List<Persons> persons = new List<Persons>();
            persons.Add(obj.Client);
            ViewBag.Persons = persons;
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> CreditDetails(int id)
        {
            Credits obj = await _creditRepository.GetCredit(id);
            return View(obj);
        }

    }
}