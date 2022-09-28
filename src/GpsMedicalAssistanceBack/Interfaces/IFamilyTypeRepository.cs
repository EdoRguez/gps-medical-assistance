using Entities.Models;

namespace Interfaces
{
    public interface IFamilyTypeRepository
    {
        Task<FamilyType> GetFamilyType(int id, bool trackChanges);
        Task<IEnumerable<FamilyType>> GetAllFamilyTypes(bool trackChanges);
        Task<bool> AreIdsValid(List<int> ids);
    }
}
