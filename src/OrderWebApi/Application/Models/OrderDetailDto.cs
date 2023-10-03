namespace OrderWebApi.Application.Models
{
    public class OrderDetailDto
    {
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
