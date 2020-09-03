using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Repositories
{
    public class MongoDB_Repository
    {
        public MongoClient client;
        public IMongoDatabase database;

        public MongoDB_Repository()
        {
            client = new MongoClient("mongodb://127.0.0.1:27017");
            database = client.GetDatabase("Inventory");
        }
    }
}
