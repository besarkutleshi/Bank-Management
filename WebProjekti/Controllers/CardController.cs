using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Persons;
using DataAccessLayer.Cards;
using EntityLayer.Persons;

namespace WebProjekti.Controllers
{
    public class CardController : Controller
    {
        private readonly ClientRepository _clientRepository;
        private readonly AccountRepository _accountRepository;
        public CardController(ClientRepository clientRepository, AccountRepository accountRepository)
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
    }
}