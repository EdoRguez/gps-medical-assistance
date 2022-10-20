namespace Interfaces.Core
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IFamilyTypeRepository FamilyType { get; }
        IAuthenticationRepository Authentication { get; }
        IAlertRepository Alert { get; }
        Task SaveAsync();
        void Rollback();
    }
}
