using AutoMapper;
using DoAnMonHoc_Backend.Interfaces;
using DoAnMonHoc_Backend.Models;
using DoAnMonHoc_Backend.Repository;
using Microsoft.AspNetCore.Identity;

namespace DoAnMonHoc_Backend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CSDLContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UnitOfWork(CSDLContext context, 
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, IMapper mapper)
        {
            this._context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
            _configuration = configuration;
            this._mapper = mapper;
        }
        public IUserRepositoty UserRepositoty =>
                new UserRepository(_context, _userManager, _roleManager, _configuration,_mapper);

        public IProductTypeRepository ProductTypeRepository =>
            new ProductTypeRepository(_context);
        public IBrandRepository BrandRepository =>
            new BrandRepository(_context);

        public IColorRepository ColorRepository => 
            new ColorRepository(_context);

        public ICapacityRepository CapacityRepository =>
            new CapacityRepository(_context);

        public IPhoneRepository PhoneRepository => 
            new PhoneRepository(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
