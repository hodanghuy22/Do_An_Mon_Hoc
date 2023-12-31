﻿using DoAnMonHoc_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonHoc_Backend.Interfaces
{
    public interface IWishlistRepository
    {
        Task CreateWishList(WishList wishList);
        Task<IEnumerable<WishList>> GetWishLists();
        Task<WishList> GetWishList(int id);
        Task<bool> WishListExist(int id);
        Task<IActionResult> UpdateWishList(WishList wishList);
        Task DeleteWishList(int id);
    }
}
