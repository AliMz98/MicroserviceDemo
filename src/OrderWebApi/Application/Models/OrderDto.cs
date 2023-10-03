using OrderWebApi.Domain.Entities;

namespace OrderWebApi.Application.Models
{
    public class OrderDto
    {
        public string Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderedOn { get; set; }
        public List<OrderDetailDto> Details { get; set; }
    }
}
