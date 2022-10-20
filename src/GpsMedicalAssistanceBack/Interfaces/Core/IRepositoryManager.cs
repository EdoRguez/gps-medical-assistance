namespace Interfaces.Core
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IFamilyTypeRepository FamilyType { get; }
        IAuthenticationRepository AuthenticationRepository { get; }
        IAlertRepository AlertRepository { get; }
        Task SaveAsync();
        void Rollback();
    }
}
