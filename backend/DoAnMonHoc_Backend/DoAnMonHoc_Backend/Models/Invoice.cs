﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DoAnMonHoc_Backend.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string ShippingInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public int TotalPrice { get; set; }
        public int TotalPriceAfterDiscount { get; set; }
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }
        public string OrderStatus { get; set; } = "Chua Xu Ly";
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
