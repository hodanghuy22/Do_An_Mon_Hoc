namespace DoAnMonHoc_Backend.Models
{
    public class Capacity
    {
        public int Id { get; set; }
        public string TotalCapacity { get; set; }
        public bool Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
