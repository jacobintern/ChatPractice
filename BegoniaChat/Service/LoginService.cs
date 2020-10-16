using BegoniaChat.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Web;

namespace BegoniaChat.Service
{
    public class LoginService
    {
        private readonly MongoDBContext chatDB;
        private readonly IMongoDatabase _chat_acc;
        public LoginService()
        {
            chatDB = new MongoDBContext();
            _chat_acc = chatDB.GetDB("chat_db", "chat_acc");
        }
        public bool VerifyUser(LoginModel model)
        {
            var filter = Builders<LoginModel>.Filter.Eq("acc", model.acc)
                & Builders<LoginModel>.Filter.Eq("pswd", model.pswd);
            var collection = _chat_acc.GetCollection<LoginModel>("chat_acc");
            return collection.Find(filter).Any();
        }

        public List<LoginModel> GetAllUser()
            => _chat_acc.GetCollection<LoginModel>("chat_acc").Find(_ => true).ToList();

    }
}