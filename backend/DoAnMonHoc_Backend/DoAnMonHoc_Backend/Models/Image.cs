﻿namespace DoAnMonHoc_Backend.Models
{
    public class Image
    {
        public int  Id { get; set; }
        public string  Url { get; set; }
        public bool  Status { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
