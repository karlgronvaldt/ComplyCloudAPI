using DoggyCare.DTOs;
using DoggyCare.Models;

namespace DoggyCare
{
    public static class Extensions
    {
        // Create DTO from animal record
        public static AnimalDTO AsDTO(this Animal animal)
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

        // Create DTO from user record
        public static UserDTO AsDTO(this User user)
        {
            return new UserDTO
            {
                Username = user.Username,
                Password = user.Password,
                Role = user.Role
            };
        }
    }
}