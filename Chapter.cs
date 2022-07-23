using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Chapter: BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Curso Course { get; set; } = new Curso();
        
        [Required]
        public string List { get; set; } = string.Empty;
    }
}
