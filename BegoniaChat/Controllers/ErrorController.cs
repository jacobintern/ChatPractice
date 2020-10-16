using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BegoniaChat.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult DefaultErrorPage()
        {
            return View();
        }
    }
}