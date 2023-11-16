using AutoMapper;
using DoAnMonHoc_Backend.Dto;
using DoAnMonHoc_Backend.Interfaces;
using DoAnMonHoc_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DoAnMonHoc_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(IUnitOfWork uow, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager  )
        {
            _uow = uow;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin(string Username, string Password, string Email)
        {
            return await _uow.UserRepositoty.RegisterAdmin(Username, Password, Email);
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(string Username, string Password, string Email)
        {
            return await _uow.UserRepositoty.Register(Username, Password, Email);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([Bind("Username,Password")] LoginModel account)
        {
            return await _uow.UserRepositoty.Login(account);
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _uow.UserRepositoty.GetUsers();
        }
        [HttpGet]
        [Route("GetUser")]
        public async Task<UserDto> GetUser(string id)
        {
            return await _uow.UserRepositoty.GetUser(id);
        }
    }
}
