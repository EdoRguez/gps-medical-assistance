using Entities;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Core;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public void CreateUser(User model)
        {
            Create(model);
        }

        public async Task<User> GetUser(int id, bool trackChanges)
        {
            return await FindSingleByCondition(x => x.Id.Equals(id), trackChanges);
        }

        public async Task<IEnumerable<User>> GetAllUsers(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
    }
}
