using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Persons;
using EntityLayer.Persons;
using Microsoft.AspNetCore.Mvc;

namespace WebProjekti.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientRepository _clientRepository;
        private static int ClID = 0;
        public ClientController(ClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        [HttpGet]
        public IActionResult InsertClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertClient(Clients obj)
        {
            if(await _clientRepository.Insert(obj) != null)
            {
                return RedirectToAction("ListClient");
            }
            ViewBag.ErrorTitle = "Registration not successful";
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (ModelState.IsValid)
            {
                if(await _clientRepository.Delete(id) != null)
                {
                    return RedirectToAction("ListClient");
                }
            }
            ViewBag.ErrorTitle = "Registration not successful";
            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateClient(int id)
        {
            ClID = id;
            var client = await _clientRepository.Read(id);
            if(client != null)
            {
                return View(client);
            }
            ViewBag.ErrorTitle = $"Client with id {id} not exist";
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClient(Clients obj)
        {
            if (ModelState.IsValid)
            {
                obj.PersonId = obj.Person.Id = ClID;
                if(await _clientRepository.Update(obj) != null)
                {
                    return RedirectToAction("ListClient");
                }
            }
            ClID = 0;
            ViewBag.ErrorTitle = "Registration not successful";
            return View("Error");
        }

        [HttpGet]
        public async Task< IActionResult> ListClient()
        {
            var cls = await _clientRepository.Read();
            ViewBag.IsPremiumCount = cls.Where(cl => cl.IsPremium == true).Count<Clients>();
            ViewBag.IsNotPremiumCount = cls.Where(cl => cl.IsPremium == false).Count<Clients>();
            return View(cls);
        }
    }
}