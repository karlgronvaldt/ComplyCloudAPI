using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DoggyCare.Repositories;
using DoggyCare.Models;
using DoggyCare.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace DoggyCare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        // Dependency injection of DB repository
        private readonly IAnimalsRepository _repository;

        public AnimalsController(IAnimalsRepository repository)
        {
            _repository = repository;
        }

        // Get all animals
        // GET: api/animals
        [HttpGet]
        public IEnumerable<AnimalDTO> Get()
        {
            return _repository.GetAnimals().Select(animal => animal.AsDTO());
        }

        // Get animal by ID
        // GET api/animals/{id}
        [HttpGet("{id}")]
        public ActionResult<AnimalDTO> GetId(Guid id)
        {
            var animal = _repository.GetAnimal(id);

            if (animal is null)
                return NotFound();

            return animal.AsDTO();
        }

        // Get animal by name
        // GET api/animals/name/{name}
        [HttpGet("name/{name}")]
        public ActionResult<AnimalDTO> GetName(string name)
        {
            var animal = _repository.GetAnimalName(name);

            if (animal is null)
                return NotFound();

            return animal.AsDTO();
        }

        // Get animal by owner name
        // GET api/animals/owner/{name}
        [HttpGet("owner/{name}")]
        public ActionResult<AnimalDTO> GetOwner(string name)
        {
            var animal = _repository.GetAnimalOwner(name);

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
                Id = new Guid(),
                Type = animalDTO.Type,
                Name = animalDTO.Name,
                Breed = animalDTO.Breed,
                Owner = animalDTO.Owner,
                Allergy = animalDTO.Allergy,
                CreatedDate = DateTime.Now
            };

            _repository.CreateAnimal(animal);

            return CreatedAtAction(nameof(Get), new { animal.Id }, animal.AsDTO());
        }

        // Update existing animal
        // PUT api/animals/{id}
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, UpdateAnimalDTO animalDTO)
        {
            var existingAnimal = _repository.GetAnimal(id);

            if (existingAnimal is null)
                return NotFound();

            // Keep original if not updated
            Animal updatedAnimal = existingAnimal with
            {
                Owner = (animalDTO.Owner is null) ? existingAnimal.Owner : animalDTO.Owner,
                Allergy = (animalDTO.Allergy is null) ? existingAnimal.Allergy : animalDTO.Allergy
            };

            _repository.UpdateAnimal(updatedAnimal);

            return NoContent();
        }

        // Delete an animal
        // DELETE api/animals/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var existingAnimal = _repository.GetAnimal(id);

            if (existingAnimal is null)
                return NotFound();

            _repository.DeleteAnimal(id);

            return NoContent();
        }
    }
}
