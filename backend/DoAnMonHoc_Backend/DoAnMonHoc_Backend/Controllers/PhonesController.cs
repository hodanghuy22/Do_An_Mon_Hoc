using AutoMapper;
using DoAnMonHoc_Backend.Dto;
using DoAnMonHoc_Backend.Interfaces;
using DoAnMonHoc_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DoAnMonHoc_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public PhonesController(IUnitOfWork uow, IMapper mapper, IPhotoService photoService)
        {
            _uow = uow;
            _mapper = mapper;
            _photoService = photoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPhones()
        {
            var phones = await _uow.PhoneRepository.GetPhones();
            var phonesDto = _mapper.Map<IEnumerable<PhoneDto>>(phones);
            return Ok(phonesDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPhone(int id)
        {
            var phone = await _uow.PhoneRepository.GetPhone(id);
            var phoneDto = _mapper.Map<PhoneDto>(phone);
            return Ok(phoneDto);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePhone(Phone phone)
        {
            var checkPhone = await _uow.PhoneRepository.PhoneExist(phone.Id);
            if (checkPhone == true)
            {
                return BadRequest();
            }
            _uow.PhoneRepository.CreatePhone(phone);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePhone(int id, Phone phone)
        {
            if (id != phone.Id)
            {
                return BadRequest();
            }
            return await _uow.PhoneRepository.UpdatePhone(phone);
        }
        [HttpPut]
        [Route("DeletePhone/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePhone(int id)
        {
            var pt = await _uow.PhoneRepository.PhoneExist(id);
            if (pt == false)
            {
                return NotFound();
            }
            await _uow.PhoneRepository.DeletePhone(id);
            var result = await _uow.SaveAsync();
            return Ok();
        }
        [HttpPost]
        [Route("add/photo/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPhonePhoto(int id, IFormFile file)
        {
            var result = await _photoService.UploadPhotoAsync(file);
            if (result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }
            var phone = await _uow.PhoneRepository.GetPhone(id);
            if (phone != null && result != null && result.SecureUrl != null)
            {
                phone.FileHinh = result.SecureUrl.ToString();
            }
            await _uow.SaveAsync();
            return Ok(201);
        }
    }
}
