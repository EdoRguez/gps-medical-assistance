using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Core;
using Repository.Extensions;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public void CreateUser(User model)
        {
            Create(model);
        }

        public async Task<User> GetUser(int id, List<IncludesGeneral> includes, bool trackChanges)
        {
            return await FindSingleByCondition(x => x.Id.Equals(id), includes, trackChanges);
        }

        public async Task<IEnumerable<User>> GetAllUsers(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers(UserParameters userParameters, bool trackChanges)
        {
            return await FindAll(userParameters.Includes, trackChanges).FilterUsers(userParameters).ToListAsync();
        }
    }
}
