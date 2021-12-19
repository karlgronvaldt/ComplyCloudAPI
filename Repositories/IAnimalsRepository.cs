using System;
using System.Collections.Generic;
using DoggyCare.Models;

namespace DoggyCare.Repositories
{
    public interface IAnimalsRepository
    {
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimal(Guid id);
        Animal GetAnimalName(string name);
        Animal GetAnimalOwner(string owner);
        void CreateAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void DeleteAnimal(Guid id);
    }
}