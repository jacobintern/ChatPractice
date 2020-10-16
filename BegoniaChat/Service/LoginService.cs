using BegoniaChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace BegoniaChat.Service
{
    public class LoginService
    {
        private readonly ChatEFEntities chatDB;

        public LoginService()
        {
            chatDB = new ChatEFEntities();
        }
        public bool VerifyUser(LoginModel model)
            => chatDB.Chat_Acc_M.Any(x => x.acc == model.Account && x.pswd == model.Password);

        public List<LoginModel> GetAllUser()
        {
            List<Chat_Acc_M> tmpModel = chatDB.Chat_Acc_M.ToList();
            List<LoginModel> model = new List<LoginModel>();
            foreach (var tmp in tmpModel)
            {
                model.Add(new LoginModel()
                {
                    Account = tmp.acc,
                    Email = tmp.email,
                    FullName = tmp.name,
                    Gender = tmp.gender
                });
            }
            return model;
        }
    }
}