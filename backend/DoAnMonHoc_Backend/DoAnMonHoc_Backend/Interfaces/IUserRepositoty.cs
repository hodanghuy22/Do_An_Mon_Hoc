using DoAnMonHoc_Backend.Dto;
using DoAnMonHoc_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonHoc_Backend.Interfaces
{
    public interface IUserRepositoty
    {
        Task<IActionResult> RegisterAdmin(string Username, string Password, string Email);
        Task<IActionResult> Register(string Username, string Password, string Email);
        Task<IActionResult> Login([Bind("Username,Password")] LoginModel account);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(string id);
    }
}
