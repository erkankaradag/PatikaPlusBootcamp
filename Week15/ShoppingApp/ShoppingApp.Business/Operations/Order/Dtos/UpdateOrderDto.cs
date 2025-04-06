namespace ShoppingApp.Business.Operations.Order.Dtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Quentity { get; set; }
        public List<int> ProductIds { get; set; }
    }
}