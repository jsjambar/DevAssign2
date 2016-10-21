using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        static void Main(string[] args)
        {
            CreateAndPopulateDatabase();
            Console.ReadLine();
        }

        // Maybe split into two methods? 
        public static async void CreateAndPopulateDatabase()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("assignment2");

            var document = new BsonDocument
            {
                { "employees" , new BsonArray
                    {
                        new BsonDocument
                        {
                            { "bsn", "1234" },
                            { "first_name", "Andy" },
                            { "surname", "Bhadai" }
                        },
                        new BsonDocument
                        {
                            { "bsn", "5678" },
                            { "first_name", "Jason" },
                            { "surname", "Sjambar" }
                        },
                        new BsonDocument
                        {
                            { "bsn", "0001" },
                            { "first_name", "Pietje" },
                            { "surname", "Puk" }
                        }
                    }
                },
            };

            var collection = _database.GetCollection<BsonDocument>("restaurants");
            await collection.InsertOneAsync(document);
        }
    }
}
