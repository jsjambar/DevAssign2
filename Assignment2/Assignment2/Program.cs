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
                { "employee_roles" , new BsonArray
                    {
                        new BsonDocument
                        {
                            { "employee", "1234" },
                            { "role", "Software Engineer" }
                        },
                        new BsonDocument
                        {
                            { "employee", "1234" },
                            { "role", "Web Developer" }
                        },
                        new BsonDocument
                        {
                            { "employee", "5678" },
                            { "role", "Software Engineer" }
                        },
                        new BsonDocument
                        {
                            { "employee", "5678" },
                            { "role", "CEO" }
                        },
                    }
                },
                { "employee_addresses" , new BsonArray
                    {
                        new BsonDocument
                        {
                            { "employee", "1234" },
                            { "address", new BsonArray {
                                new BsonDocument
                                {
                                    { "street", "Wijnhaven"},
                                    { "number", 107},
                                    { "city", "Rotterdam"}
                                }
                            } }
                        },
                        new BsonDocument
                        {
                            { "employee", "1234" },
                            { "address", new BsonArray {
                                new BsonDocument
                                {
                                    { "street", "Werkplaats 1"},
                                    { "number", 1},
                                    { "city", "Rotterdam"}
                                }
                            } }
                        },
                        new BsonDocument
                        {
                            { "employee", "5678" },
                            { "address", new BsonArray {
                                new BsonDocument
                                {
                                    { "street", "Wijnhaven"},
                                    { "number", 7},
                                    { "city", "Rotterdam"}
                                }
                            } }
                        },
                        new BsonDocument
                        {
                            { "employee", "5678" },
                            { "address", new BsonArray {
                                new BsonDocument
                                {
                                    { "street", "Sugoi Cherry Blossoms"},
                                    { "number", 1},
                                    { "city", "Amazing Japanese Citye31de"}
                                }
                            } }
                        }
                    }
                }
            };

            var collection = _database.GetCollection<BsonDocument>("restaurants");
            await collection.InsertOneAsync(document);
        }
    }
}
