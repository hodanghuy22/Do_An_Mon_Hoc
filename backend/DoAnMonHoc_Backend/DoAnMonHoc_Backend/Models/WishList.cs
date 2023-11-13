﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonHoc_Backend.Models
{
    public class WishList
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
