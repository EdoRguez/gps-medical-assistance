using Entities.Models;
using Entities.RequestFeatures;

namespace Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id, List<string> includes, bool trackChanges);
        Task<IEnumerable<User>> GetAllUsers(UserParameters userParameters, bool trackChanges);
        void CreateUser(User model);
    }
}
