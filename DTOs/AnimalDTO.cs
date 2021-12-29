using System;

namespace DoggyCare.DTOs
{
    // Object to carry animal data from and to the service layer and presentation layer
    public record AnimalDTO
    {
        public Guid Id { get; init; }
        public int Type { get; set; }
        public string Name { get; init; }
        public string Breed { get; init; }
        public string Owner { get; set; }
        public string[] Allergy { get; set; }
        public DateTime CreatedDate { get; init; }
    }
}