﻿namespace DoAnMonHoc_Backend.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }    
        public string Comment { get; set; }
        public string FileHinh { get; set; }
        public int Star { get; set; }
        public DateTime NgayDang { get; set; }
    }
}
