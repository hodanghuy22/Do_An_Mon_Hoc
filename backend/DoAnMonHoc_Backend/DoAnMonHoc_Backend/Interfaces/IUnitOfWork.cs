namespace DoAnMonHoc_Backend.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepositoty UserRepositoty { get; }
        Task<bool> SaveAsync();
    }
}
