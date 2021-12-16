namespace DoggyCare.DTOs
{
    public record UpdateAnimalDTO
    {
        public string Owner { get; set; }
        public string Allergy { get; set; }
    }
}