//using System;
//using System.Collections.Generic;
//using System.Linq;
//using DoggyCare.Models;

//namespace DoggyCare.Repositories
//{
//    public class InMemoryAnimalsRepository : IAnimalsRepository
//    {
//        // In memory repository
//        private readonly List<Animal> animals = new()
//        {
//            new Animal { Id = Guid.NewGuid(), Type = 1, Name = "Johnny", Breed = "Chiuaua", Allergy = "None", Owner = "Karl", CreatedDate = DateTime.Now },
//            new Animal { Id = Guid.NewGuid(), Type = 1, Name = "Doggo", Breed = "Labrador", Allergy = "Tomato", Owner = "Luna", CreatedDate = DateTime.Now },
//            new Animal { Id = Guid.NewGuid(), Type = 1, Name = "Pipi", Breed = "Golden Retreiver", Allergy = "Chalk", Owner = "Olaf", CreatedDate = DateTime.Now }
//        };

//        // GET all animals
//        public IEnumerable<Animal> GetAnimals()
//        {
//            return animals;
//        }

//        // GET animal by ID
//        public Animal GetAnimal(Guid id)
//        {
//            return animals.SingleOrDefault(animal => animal.Id == id);
//        }

//        // GET animal by animal name
//        public Animal GetAnimalName(string name)
//        {
//            return animals.SingleOrDefault(animal => animal.Name.ToLower() == name.ToLower());
//        }

//        // GET animal by owner name
//        public Animal GetAnimalOwner(string owner)
//        {
//            return animals.SingleOrDefault(animal => animal.Owner.ToLower() == owner.ToLower());
//        }

//        // Create a new animal
//        public void CreateAnimal(Animal animal)
//        {
//            animals.Add(animal);
//        }

//        // Update animal by ID
//        public void UpdateAnimal(Animal animal)
//        {
//            var index = animals.FindIndex(existingAnimal => existingAnimal.Id == animal.Id);
//            animals[index] = animal;
//        }

//        // Delete animal by ID
//        public void DeleteAnimal(Guid id)
//        {
//            var index = animals.FindIndex(existingAnimal => existingAnimal.Id == id);
//            animals.RemoveAt(index);
//        }
//    }
//}