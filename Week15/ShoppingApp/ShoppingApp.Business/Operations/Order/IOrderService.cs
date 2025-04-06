using ShoppingApp.Business.Operations.Order.Dtos;
using ShoppingApp.Business.Types;
using ShoppingApp.Business.Operations.Order.Dtos;
using ShoppingApp.Business.Types;

namespace ShoppingApp.Business.Operations.Order
{
    // lifetime must be specified
    public interface IOrderService
    {
        Task<ServiceMessage> AddOrder(AddOrderDto order);
        Task<OrderDto> GetOrder(int id);
        Task<List<OrderDto>> GetAllOrders();
        Task<ServiceMessage> DeleteOrder(int id);
        Task<ServiceMessage> UpdateOrder(UpdateOrderDto order);
    }
}