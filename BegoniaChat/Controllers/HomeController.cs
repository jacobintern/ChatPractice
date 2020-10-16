using BegoniaChat.Models;
using BegoniaChat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Microsoft.Ajax.Utilities;

namespace BegoniaChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoginService _loginService;

        public HomeController()
        {
            _loginService = new LoginService();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Login(LoginModel model)
        {
            if (model == null)
            {
                return RedirectToAction("index","home");
            }
            else
            {
                if (_loginService.VerifyUser(model))
                {
                    return RedirectToAction("index", "chat", model);
                }
                
                return RedirectToAction("index", "home");
            }
        }
    }
}