using Entities;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Core;

namespace Repository
{
    public class FamilyTypeRepository : RepositoryBase<FamilyType>, IFamilyTypeRepository
    {
        public FamilyTypeRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<FamilyType>> GetAllFamilyTypes(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<FamilyType> GetFamilyType(int id, bool trackChanges)
        {
            return await FindSingleByCondition(x => x.Id.Equals(id), trackChanges);
        }

        public async Task<bool> AreIdsValid(List<int> ids)
        {
            return await IsCollectionIdValid(x => x.Id, ids.AsQueryable());
        }
    }
}
