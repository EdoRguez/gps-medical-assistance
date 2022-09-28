using Entities.Models;

namespace Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id, bool trackChanges);
        Task<IEnumerable<User>> GetAllUsers(bool trackChanges);
        void CreateUser(User model);
    }
}
