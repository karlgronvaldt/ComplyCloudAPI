using DoggyCare.DTOs;
using DoggyCare.Models;

namespace DoggyCare
{
    public static class Extensions
    {
        // Create DTO from animal record
        public static AnimalDTO AsDTO(this AnimalModel animal)
        {
            return new AnimalDTO
            {
                Id = animal.Id,
                Type = animal.Type,
                Name = animal.Name,
                Breed = animal.Breed,
                Allergy = animal.Allergy,
                Owner = animal.Owner,
                CreatedDate = animal.CreatedDate
            };
        }
    }
}