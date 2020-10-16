using BegoniaChat.Models;
using BegoniaChat.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BegoniaChat.ApiControllers
{
    public class UsersController : ApiController
    {

        private readonly LoginService _loginService;

        public UsersController()
        {
            _loginService = new LoginService();
        }

        [HttpGet]
        public List<LoginModel> Get()
        {
            return _loginService.GetAllUser();
        }
    }
}
