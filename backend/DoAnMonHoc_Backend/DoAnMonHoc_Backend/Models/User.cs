using Microsoft.AspNetCore.Identity;

namespace DoAnMonHoc_Backend.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public List<Comment> Comments { get; set; } 
        public List<Invoice> Invoices { get; set; } 
    }
}
