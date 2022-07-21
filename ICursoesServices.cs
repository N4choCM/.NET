using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICursoesServices
    {
        IEnumerable<Curso> GetCoursesWithSpecificCategory();
        IEnumerable<Curso> GetCoursesWithoutChapters();


    }
}
