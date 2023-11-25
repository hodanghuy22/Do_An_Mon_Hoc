using DoAnMonHoc_Backend.Models;
using Microsoft.AspNetCore.Mvc;
namespace DoAnMonHoc_Backend.Interfaces
{
    public interface IInvoiceRepository
    {
        Task CreateInvoice(Invoice invoice);
        Task<IEnumerable<Invoice>> GetInvoices();
        Task<Invoice> GetInvoice(int id);
        Task<bool> InvoiceExist(int id);
        Task<IActionResult> UpdateInvoice(Invoice invoice);
        Task DeleteInvoice(int id);
    }
}
