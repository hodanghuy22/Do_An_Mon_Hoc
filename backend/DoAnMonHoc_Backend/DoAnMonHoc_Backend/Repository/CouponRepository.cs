﻿using DoAnMonHoc_Backend.Data;
using DoAnMonHoc_Backend.Interfaces;
using DoAnMonHoc_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnMonHoc_Backend.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CSDLContext _context;
        public CouponRepository(CSDLContext context)
        {
            _context = context;
        }
        public async Task<bool> CouponExist(int id)
        {
            return await _context.Coupons.AnyAsync(b => b.Id == id);
        }

        public async Task CreateCoupon(Coupon coupon)
        {
            await _context.Coupons.AddAsync(coupon);
        }

        public async Task DeleteCoupon(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon != null)
            {
                coupon.Status = false;
            }
        }

        public async Task<Coupon> GetCoupon(int id)
        {
            return await _context.Coupons.Include(c => c.Invoices)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Coupon>> GetCoupons()
        {
            return await _context.Coupons.Include(c => c.Invoices)
                .ToListAsync();
        }

        public async Task<IActionResult> UpdateCoupon(Coupon coupon)
        {
            _context.Entry(coupon).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!await CouponExist(coupon.Id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }
            return new OkResult();
        }
    }
}
