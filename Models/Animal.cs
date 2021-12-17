using System;
using MongoDB.Bson;

namespace DoggyCare.Models
{
    // The definition of an animal
    public record Animal
    {
        public Guid Id { get; init; }
        public int Type { get; set; } // 0 = Other, 1 = Dog
        public string Name { get; init; }
        public string Breed { get; init; }
        public string Owner { get; set; }
        public string Allergy { get; set; }
        public DateTime CreatedDate { get; init; }
    }
}