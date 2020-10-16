using BegoniaChat.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BegoniaChat.Service
{
    public class RegisterService
    {
        private readonly MongoDBContext chatDB;
        private readonly IMongoDatabase _chat_acc;

        public RegisterService()
        {
            chatDB = new MongoDBContext();
            _chat_acc = chatDB.GetDB("chat_db", "chat_acc");
        }

        public bool CreateUser(LoginModel model)
        {
            bool r = false;
            try
            {
                var collection = _chat_acc.GetCollection<LoginModel>("chat_acc");
                collection.InsertOne(model);
                r = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return r;
        }
    }
}