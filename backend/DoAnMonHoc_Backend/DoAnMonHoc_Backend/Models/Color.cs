namespace DoAnMonHoc_Backend.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public bool Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
