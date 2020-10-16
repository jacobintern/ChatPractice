using BegoniaChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BegoniaChat.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index(LoginModel model)
        {
            return View(model);
        }
    }
}