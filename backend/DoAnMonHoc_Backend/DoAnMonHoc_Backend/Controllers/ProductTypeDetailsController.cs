﻿using DoAnMonHoc_Backend.Dto;
using DoAnMonHoc_Backend.Interfaces;
using DoAnMonHoc_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonHoc_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public ProductTypeDetailsController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public async Task<IActionResult> ProductTypeDetails()
        {
            var ProductTypeDetail = await _uow.ProductTypeDetailRepository.GetProductTypeDetails();
            return Ok(ProductTypeDetail);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductTypeDetail(int id)
        {
            var ProductTypeDetail = await _uow.ProductTypeDetailRepository.GetProductTypeDetail(id);
            return Ok(ProductTypeDetail);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProductTypeDetail(ProductTypeDetail productTypeDetail)
        {
            var checkProductTypeDetail = await _uow.ProductTypeDetailRepository.ProductTypeDetailExist(productTypeDetail.Id);
            if (checkProductTypeDetail == true)
            {
                return BadRequest();
            }
            _uow.ProductTypeDetailRepository.CreateProductTypeDetail(productTypeDetail);
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
        public async Task<IActionResult> UpdateProductTypeDetail(int id, ProductTypeDetail productTypeDetail)
        {
            if (id != productTypeDetail.Id)
            {
                return BadRequest();
            }
            return await _uow.ProductTypeDetailRepository.UpdateProductTypeDetail(productTypeDetail);
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProductTypeDetail(int id)
        {
            var pt = await _uow.ProductTypeDetailRepository.GetProductTypeDetail(id);
            if (pt == null)
            {
                return NotFound();
            }
            await _uow.ProductTypeDetailRepository.DeleteProductTypeDetail(pt);
            var result = await _uow.SaveAsync();
            if(result == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
