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
        private IAlertRepository _alertRepository;

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

        public IAlertRepository AlertRepository
        {
            get
            {
                if (_alertRepository == null)
                    _alertRepository = new AlertRepository(_context);

                return _alertRepository;
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
