namespace DoAnMonHoc_Backend.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int DiscountPercent { get; set; }
        public int DiscountMoney { get; set; }
        public int LimitMoney { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime Expiry { get; set; }
        public bool Status { get; set; }
        public List<Invoice> Invoices { get;}
    }
}
