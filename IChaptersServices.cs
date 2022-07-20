using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface IChaptersServices
    {
        IEnumerable<Chapter> GetSpecificCourseChapter();
    }
}
