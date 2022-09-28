namespace Interfaces.Core
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IFamilyTypeRepository FamilyType { get; }
        IAuthenticationRepository AuthenticationRepository { get; }
        Task SaveAsync();
        void Rollback();
    }
}
