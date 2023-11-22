﻿namespace DoAnMonHoc_Backend.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepositoty UserRepositoty { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        IBrandRepository BrandRepository { get; }
        IColorRepository ColorRepository { get; }
        ICapacityRepository CapacityRepository { get; }
        Task<bool> SaveAsync();
    }
}
