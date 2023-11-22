﻿using AutoMapper;
using DoAnMonHoc_Backend.Dto;
using DoAnMonHoc_Backend.Interfaces;
using DoAnMonHoc_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonHoc_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public BrandsController(IUnitOfWork uow, IMapper mapper, IPhotoService photoService)
        {
            _uow = uow;
            _mapper = mapper;
            _photoService = photoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _uow.BrandRepository.GetBrands();
            var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brands);
            return Ok(brandsDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _uow.BrandRepository.GetBrand(id);
            var brandDto = _mapper.Map<BrandDto>(brand);
            return Ok(brandDto);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateBrand(Brand brand)
        {
            var checkBrand = await _uow.BrandRepository.BrandExist(brand.Id);
            if(checkBrand == true)
            {
                return BadRequest();
            }
            _uow.BrandRepository.CreateBrand(brand);
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
        public async Task<IActionResult> UpdateBrand(int id, Brand brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }
            return await _uow.BrandRepository.UpdateBrand(brand);
        }
        [HttpPut]
        [Route("DeleteBrand/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var pt = await _uow.BrandRepository.BrandExist(id);
            if (pt == false)
            {
                return NotFound();
            }
            await _uow.BrandRepository.DeleteBrand(id);
            var result = await _uow.SaveAsync();
            return Ok();
        }
        [HttpPost]
        [Route("add/photo/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBrandPhoto(int id,IFormFile file)
        {
            var result = await _photoService.UploadPhotoAsync(file);
            if(result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }
            var brand = await _uow.BrandRepository.GetBrand(id);
            if(brand != null && result != null && result.SecureUrl != null)
            {
                brand.FileHinh = result.SecureUrl.ToString();
            }
            await _uow.SaveAsync();
            return Ok(201);
        }
    }
}
