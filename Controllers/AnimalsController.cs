using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DoggyCare.Repositories;
using DoggyCare.Models;
using DoggyCare.DTOs;

namespace DoggyCare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        // Dependency injection of in memory repository (local database so to speak)
        private readonly IAnimalsRepository repository;

        public AnimalsController(IAnimalsRepository repository)
        {
            this.repository = repository;
        }

        // Get all animals
        // GET: api/animals
        [HttpGet]
        public IEnumerable<AnimalDTO> Get()
        {
            return repository.GetAnimals().Select(animal => animal.AsDTO());
        }

        // Get animal by ID
        // GET api/animals/{id}
        [HttpGet("{id}")]
        public ActionResult<AnimalDTO> Get(Guid id)
        {
            var animal = repository.GetAnimal(id);

            if (animal is null)
                return NotFound();

            return animal.AsDTO();
        }

        // Get animal by name
        // GET api/animals/name/{name}
        [HttpGet("name/{name}")]
        public ActionResult<AnimalDTO> GetName(string name)
        {
            var animal = repository.GetAnimalName(name);

            if (animal is null)
                return NotFound();

            return animal.AsDTO();
        }

        // Get animal by owner name
        // GET api/animals/owner/{name}
        [HttpGet("owner/{name}")]
        public ActionResult<AnimalDTO> GetOwner(string name)
        {
            var animal = repository.GetAnimalOwner(name);

            if (animal is null)
                return NotFound();

            return animal.AsDTO();
        }

        // Create a new animal
        // POST api/animals
        [HttpPost]
        public ActionResult<AnimalDTO> Create(CreateAnimalDTO animalDTO)
        {
            Animal animal = new()
            {
                Id = Guid.NewGuid(),
                Type = animalDTO.Type,
                Name = animalDTO.Name,
                Breed = animalDTO.Breed,
                Owner = animalDTO.Owner,
                Allergy = animalDTO.Allergy,
                CreatedDate = DateTime.Now
            };

            repository.CreateAnimal(animal);

            return CreatedAtAction(nameof(Get), new { Id = animal.Id }, animal.AsDTO());
        }

        // Update existing animal
        // PUT api/animals/{id}
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, UpdateAnimalDTO animalDTO)
        {
            var existingAnimal = repository.GetAnimal(id);

            if (existingAnimal is null)
                return NotFound();

            // Keep original if not updated
            Animal updatedAnimal = existingAnimal with
            {
                Owner = (animalDTO.Owner is null) ? existingAnimal.Owner : animalDTO.Owner,
                Allergy = (animalDTO.Allergy is null) ? existingAnimal.Allergy : animalDTO.Allergy
            };

            repository.UpdateAnimal(updatedAnimal);

            return NoContent();
        }

        // DELETE api/animals/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var existingAnimal = repository.GetAnimal(id);

            if (existingAnimal is null)
                return NotFound();

            repository.DeleteAnimal(id);

            return NoContent();
        }
    }
}
