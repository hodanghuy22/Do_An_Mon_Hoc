namespace DoAnMonHoc_Backend.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepositoty UserRepositoty { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        IBrandRepository BrandRepository { get; }
        IColorRepository ColorRepository { get; }
        ICapacityRepository CapacityRepository { get; }
        IPhoneRepository PhoneRepository { get; }
        IProductTypeDetailRepository ProductTypeDetailRepository { get; }
        IProductRepository ProductRepository { get; }
        IWishlistRepository WishlistRepository { get; }
        Task<bool> SaveAsync();
    }
}
