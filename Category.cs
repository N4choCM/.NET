using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Category: BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Curso> Courses { get; set; } = new List<Curso>();
    }
}
