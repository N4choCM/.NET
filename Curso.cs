using System.ComponentModel.DataAnnotations;


namespace UniversityApiBackend.Models.DataModels
{
    public class Curso: BaseEntity
    {
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string LongDescription { get; set; } = string.Empty;

        [Required]
        public string TargetPublic { get; set; } = string.Empty;

        [Required]
        public string Goals { get; set; } = string.Empty;

        [Required]
        public string Requirements { get; set; } = string.Empty;

        public enum Level { Básico, Intermedio, Avanzado}
    }
}
