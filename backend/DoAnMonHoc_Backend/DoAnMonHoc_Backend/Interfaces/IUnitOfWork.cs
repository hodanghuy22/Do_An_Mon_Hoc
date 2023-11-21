namespace DoAnMonHoc_Backend.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepositoty UserRepositoty { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        Task<bool> SaveAsync();
    }
}
