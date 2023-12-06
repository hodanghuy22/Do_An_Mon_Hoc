﻿using DoAnMonHoc_Backend.Data;
using DoAnMonHoc_Backend.Interfaces;
using DoAnMonHoc_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnMonHoc_Backend.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly CSDLContext _context;
        public InvoiceRepository(CSDLContext context)
        {
            _context = context;
        }
        public async Task CreateInvoice(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
        }

        public async Task DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                invoice.OrderStatus = "Da Xoa Don Hang";
            }
        }

        public async Task<Invoice> GetInvoice(int id)
        {
            return await _context.Invoices.Include(i => i.Coupon)
                .Include(i => i.InvoiceDetails)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Invoice>> GetInvoices(string userID)
        {
            return await _context.Invoices.Include(i => i.Coupon)
                .Include(i => i.InvoiceDetails)
                .Where(i => i.UserId == userID)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByStatus(string userID,string status)
        {
            return await _context.Invoices.Include(i => i.Coupon)
                .Include(i => i.InvoiceDetails)
                .Where(i => i.UserId == userID && i.OrderStatus == status)
                .ToListAsync();
        }

        public async Task<bool> InvoiceExist(int id)
        {
            return await _context.Invoices.AnyAsync(b => b.Id == id);
        }

        public async Task<IActionResult> UpdateInvoice(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!await InvoiceExist(invoice.Id))
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
