using System.ComponentModel.DataAnnotations;

namespace DoggyCare.DTOs
{
    public record CreateAnimalDTO
    {
        [Required]
        [Range(0, 1)]
        public int Type { get; set; }
        [Required]
        public string Name { get; init; }
        [Required]
        public string Breed { get; init; }
        [Required]
        public string Owner { get; set; }
        [Required]
        public string Allergy { get; set; }
    }
}