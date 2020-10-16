using BegoniaChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BegoniaChat.Service
{
    public class RegisterService
    {
        private readonly ChatEFEntities chatDB;

        public RegisterService()
        {
            chatDB = new ChatEFEntities();
        }
        public bool CreateUser(LoginModel model)
        {
            bool r = false;
            try
            {
                // 資料交換
                Chat_Acc_M newModel = new Chat_Acc_M()
                {
                    acc = model.Account,
                    pswd = model.Password,
                    email = model.Email,
                    gender = model.Gender,
                    name = model.FullName
                };

                chatDB.Chat_Acc_M.Add(newModel);
                r = chatDB.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return r;
        }
    }
}