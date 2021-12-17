using System;
using System.Collections.Generic;
using DoggyCare.Models;
using MongoDB.Bson;

namespace DoggyCare.Repositories
{
    public interface IAnimalsRepository
    {
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimal(Guid id);
        Animal GetAnimalName(string name);
        Animal GetAnimalOwner(string name);
        void CreateAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void DeleteAnimal(Guid id);
    }
}