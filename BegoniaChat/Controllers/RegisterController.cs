using BegoniaChat.Models;
using BegoniaChat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BegoniaChat.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RegisterService _registerService;
        public RegisterController()
        {
            _registerService = new RegisterService();
        }
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("index", "register", model);
            }

            bool result = _registerService.CreateUser(model);

            if (result)
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                return RedirectToAction("index", "register");
            }
        }
    }
}