﻿using AutoMapper;
using DoAnMonHoc_Backend.Data;
using DoAnMonHoc_Backend.Dto;
using DoAnMonHoc_Backend.Interfaces;
using DoAnMonHoc_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoAnMonHoc_Backend.Repository
{
    public class UserRepository : IUserRepositoty
    {
        private readonly CSDLContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserRepository(CSDLContext context, 
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return usersDto;
        }

        public async Task<IActionResult> Login([Bind(new[] { "Username,Password" })] LoginModel account)
        {
            var user = await _userManager.FindByNameAsync(account.Username);
            if (user == null)
            {
                return new UnauthorizedResult();
            }
            if(await _userManager.CheckPasswordAsync(user, account.Password) == false)
            {
                return new UnauthorizedResult();
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            var userDto = _mapper.Map<UserDto>(user);  
            return new OkObjectResult(new
            {
                userDto,
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        public async Task<IActionResult> Register(string Username, string Password, string Email)
        {
            var userExist = await _userManager.FindByNameAsync(Username);
            if(userExist != null)
            {
                var errorResponse = new { Message = "User already exists" };
                return new BadRequestObjectResult(errorResponse);
            }
            User user = new User()
            {
                UserName = Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = Email
            };
            var result = await _userManager.CreateAsync(user, Password);
            if (!result.Succeeded)
            {
                var errorResponse = new { Message = "Something went wrong!" };
                return new BadRequestObjectResult(errorResponse);
            }
            if (await _roleManager.RoleExistsAsync("User"))
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return new OkResult();

        }

        public async Task<IActionResult> RegisterAdmin(string Username, string Password, string Email)
        {
            var userExists = await _userManager.FindByNameAsync(Username);
            if (userExists != null)
            {
                var errorResponse = new { Message = "User already exists" };
                return new BadRequestObjectResult(errorResponse);
            }
            User user = new User()
            {
                Email = Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = Username
            };
            var result = await _userManager.CreateAsync(user, Password);
            if (!result.Succeeded)
            {
                var errorResponse = new { Message = "Something went wrong!" };
                return new BadRequestObjectResult(errorResponse);
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await _roleManager.RoleExistsAsync("User"))
                await _roleManager.CreateAsync(new IdentityRole("User"));

            if (await _roleManager.RoleExistsAsync("Admin"))
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            return new OkResult();
        }

        public async Task<IActionResult> UpdateUser(string id, UserDto userDto)
        {
            var userDB = await _userManager.FindByIdAsync(id);
            Console.WriteLine("trc " + userDB.Name);
            if (userDB == null)
            {
                return new NotFoundResult();
            }
            _mapper.Map(userDto, userDB);
            Console.WriteLine("sau " + userDB.Name);

            // Thực hiện cập nhật thông tin người dùng trong cơ sở dữ liệu
            var result = await _userManager.UpdateAsync(userDB);
            if (result.Succeeded)
            {
                return new OkResult();
            }

            return new BadRequestObjectResult(result.Errors);
        }

        public async Task<bool> UserExist(string id)
        {
            return await _context.Users.AnyAsync(b => b.Id == id);
        }

        public async Task<User> GetUser(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IActionResult> ChangePassword(string id,ChangePasswordModel changePasswordModel)
        {
            var user = await GetUser(id);

            if (user == null)
            {
                return new BadRequestObjectResult("Invalid user");
            }

            var changePasswordResult = await _userManager
                .ChangePasswordAsync(user, 
                changePasswordModel.CurrentPassword,
                changePasswordModel.NewPassword);

            if (!changePasswordResult.Succeeded)
            {
                return new BadRequestObjectResult(changePasswordResult.Errors);
            }

            return new OkObjectResult("Password changed successfully");
        }

        //public async Task<IActionResult> ResetPasswordAsync(string email)
        //{
        //    var user = await GetUserByEmail(email);
        //    if(user == null)
        //    {
        //        return new BadRequestObjectResult("No User Associated with this email!");
        //    }
        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    var encodeToken = Encoding.UTF8.GetBytes(token);
        //    var validToken = WebEncoders.Base64UrlEncode(encodeToken);
        //    string url = $"https://localhost:7068/ResetPassword?email={email}&token={validToken}";
        //}
    }
}
