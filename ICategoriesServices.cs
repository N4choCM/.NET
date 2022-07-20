using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICategoriesServices
    {
        IEnumerable<Category> GetSpecificCategory();
    }
}
