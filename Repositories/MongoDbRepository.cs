using System;
using System.Collections.Generic;
using DoggyCare.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DoggyCare.Repositories
{
    public class MongoDbRepository : IAnimalsRepository
    {
        private const string databaseName = "doggycare";
        private const string collectionName = "animals";

        private readonly IMongoCollection<Animal> animalsCollection;

        public MongoDbRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            animalsCollection = database.GetCollection<Animal>(collectionName);
        }

        public void CreateAnimal(Animal animal)
        {
            animalsCollection.InsertOne(animal);
        }

        public void DeleteAnimal(Guid id)
        {
            throw new NotImplementedException();
        }

        public Animal GetAnimal(Guid id)
        {
            throw new NotImplementedException();
        }

        public Animal GetAnimalName(string name)
        {
            throw new NotImplementedException();
        }

        public Animal GetAnimalOwner(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Animal> GetAnimals()
        {
            throw new NotImplementedException();
        }

        public void UpdateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
