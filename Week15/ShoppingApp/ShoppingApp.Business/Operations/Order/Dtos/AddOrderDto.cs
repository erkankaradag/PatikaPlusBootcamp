namespace ShoppingApp.Business.Operations.Order.Dtos
{
    public class AddOrderDto
    {
        public int CustomerId { get; set; }
        public int Quentity { get; set; }
        public List<int> ProductIds { get; set; }
    }
}