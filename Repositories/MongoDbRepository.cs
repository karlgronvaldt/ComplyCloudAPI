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
        private readonly FilterDefinitionBuilder<Animal> filterBuilder = Builders<Animal>.Filter;

        public MongoDbRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            animalsCollection = database.GetCollection<Animal>(collectionName);
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return animalsCollection.Find(new BsonDocument()).ToList();
        }

        public Animal GetAnimal(Guid id)
        {
            var filter = filterBuilder.Eq(animal => animal.Id, id);
            return animalsCollection.Find(filter).SingleOrDefault();
        }

        // TODO: Return (IEnumerable<Animal>?) all animals with the given name instead of one or null
        public Animal GetAnimalName(string name)
        {
            var filter = filterBuilder.Eq(animal => animal.Name, name);
            return animalsCollection.Find(filter).SingleOrDefault();
        }

        // TODO: Return (IEnumerable<Animal>?) all owners with the given name instead of one or null
        public Animal GetAnimalOwner(string owner)
        {
            var filter = filterBuilder.Eq(animal => animal.Owner, owner);
            return animalsCollection.Find(filter).SingleOrDefault();
        }

        public void CreateAnimal(Animal animal)
        {
            animalsCollection.InsertOne(animal);
        }

        public void DeleteAnimal(Guid id)
        {
            var filter = filterBuilder.Eq(animal => animal.Id, id);
            animalsCollection.DeleteOne(filter);
        }

        public void UpdateAnimal(Animal animal)
        {
            var filter = filterBuilder.Eq(existingAnimal => existingAnimal.Id, animal.Id);
            animalsCollection.ReplaceOne(filter, animal);
        }
    }
}
