using Entities;
using Interfaces;
using Interfaces.Core;
using Microsoft.EntityFrameworkCore;

namespace Repository.Core
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private IUserRepository _userRepository;
        private IFamilyTypeRepository _familyTypeRepository;
        private IAuthenticationRepository _authenticationRepository;

        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);

                return _userRepository;
            }
        }

        public IFamilyTypeRepository FamilyType
        {
            get
            {
                if(_familyTypeRepository == null)
                    _familyTypeRepository = new FamilyTypeRepository(_context);

                return _familyTypeRepository;
            }
        }

        public IAuthenticationRepository AuthenticationRepository
        {
            get
            {
                if (_authenticationRepository == null)
                    _authenticationRepository = new AuthenticationRepository(_context);

                return _authenticationRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.ChangeTracker.Clear();
        }
    }
}
