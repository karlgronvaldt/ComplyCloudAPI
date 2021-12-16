using System;
using System.Collections.Generic;
using DoggyCare.Models;

namespace DoggyCare.Repositories
{
    public interface IAnimalsRepository
    {
        IEnumerable<AnimalModel> GetAnimals();
        AnimalModel GetAnimal(Guid id);
        AnimalModel GetAnimalName(string name);
        AnimalModel GetAnimalOwner(string name);
        void CreateAnimal(AnimalModel animal);
        void UpdateAnimal(AnimalModel animal);
        void DeleteAnimal(Guid id);
    }
}