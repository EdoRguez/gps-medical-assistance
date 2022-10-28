using Entities.Models;
using Entities.RequestFeatures;

namespace Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id, List<IncludesGeneral> includes, bool trackChanges);
        Task<IEnumerable<User>> GetAllUsers(bool trackChanges);
        Task<IEnumerable<User>> GetAllUsers(UserParameters userParameters, bool trackChanges);
        void CreateUser(User model);
    }
}
