using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BegoniaChat.Models
{
    public class MongoDBContext
    {
        public IMongoDatabase GetDB(string dbName,string collectionName)
        {
            var client = new MongoClient("mongodb+srv://j_dev:passw0rd@jdev.y4x5s.gcp.mongodb.net/" + dbName + "?w=majority");

            return client.GetDatabase(dbName);
        }
    }
}