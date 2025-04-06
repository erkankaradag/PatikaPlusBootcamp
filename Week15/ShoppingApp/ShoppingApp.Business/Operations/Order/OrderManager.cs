using Microsoft.EntityFrameworkCore;
using ShoppingApp.Business.Operations.Order.Dtos;
using ShoppingApp.Business.Types;
using ShoppingApp.Data.Entities;
using ShoppingApp.Data.Repositories;
using ShoppingApp.Data.UnitOfWork;
using ShoppingApp.Business.Operations.Order.Dtos;
using ShoppingApp.Business.Types;
using ShoppingApp.Data.Entities;
using ShoppingApp.Data.Repositories;
using ShoppingApp.Data.UnitOfWork;

namespace ShoppingApp.Business.Operations.Order
{

    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<OrderEntity> _orderRepository;
        private readonly IRepository<ProductEntity> _productRepository;
        private readonly IRepository<OrderProductEntity> _orderProductRepository;

        public OrderManager(IUnitOfWork unitOfWork, IRepository<OrderEntity> repository, IRepository<OrderProductEntity> orderProductRepository, IRepository<ProductEntity> productRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = repository;
            _orderProductRepository = orderProductRepository;
            _productRepository = productRepository;
        }

        public async Task<ServiceMessage> AddOrder(AddOrderDto order)
        {
            // The save process will start, if there is a problem return here
            await _unitOfWork.BeginTransaction();

            var orderEntity = new OrderEntity
            {
                CustomerId = order.CustomerId,
                TotalAmount = 0
            };

            _orderRepository.Add(orderEntity);


            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Sipariş kaydı sırasında bir sorunla karşılaşıldı.");
            }

            foreach (var productId in order.ProductIds)
            {
                var orderProduct = new OrderProductEntity
                {
                    OrderId = orderEntity.Id,
                    ProductId = productId,
                    Quentity = order.Quentity
                };

                _orderProductRepository.Add(orderProduct);
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception("Sipariş ürünleri eklenirken bir hata ile karşılaşıldı.");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Sipariş ürünleri eklendi"
            };
        }

        public async Task<ServiceMessage> DeleteOrder(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Silinmek istenen ürün bulunamadı."
                };
            }

            _orderRepository.Delete(id);


            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Ürün silerken bir hata oluştu.");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Ürün silindi."
            };
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAll().Select(x => new OrderDto
            {
                Id = x.Id,
                CustomerName = x.User.FirstName + " " + x.User.LastName,
                CreatedDate = x.CreatedDate,
                OrderDate = x.ModifiedDate,
                TotalAmount = x.TotalAmount,
                Products = x.OrderProducts.Select(p => new OrderProductDto
                {
                    Id = p.Id,
                    Title = p.Product.ProductName
                }).ToList()
            }).ToListAsync();

            return orders;
        }

        public async Task<OrderDto> GetOrder(int id)
        {
            var order = await _orderRepository.GetAll(x => x.Id == id).Select(x => new OrderDto
            {
                Id = x.Id,
                CustomerName = x.User.FirstName + " " + x.User.LastName,
                CreatedDate = x.CreatedDate,
                OrderDate = x.ModifiedDate,
                TotalAmount = x.TotalAmount,
                Products = x.OrderProducts.Select(p => new OrderProductDto
                {
                    Id = p.Id,
                    Title = p.Product.ProductName
                }).ToList()
            }).FirstOrDefaultAsync();

            return order;
        }

        public async Task<ServiceMessage> UpdateOrder(UpdateOrderDto order)
        {
            var orderEntity = _orderRepository.GetById(order.Id);

            if (orderEntity is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Güncellenmek istenen sipariş bulunamadı."
                };
            }

            await _unitOfWork.BeginTransaction();

            orderEntity.CustomerId = order.CustomerId;

            _orderRepository.Update(orderEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception("Sipariş bilgileri güncellenirken bir hata ile karşılaşıldı.");
            }

            // Order products are being updated
            var orderProducts = _orderProductRepository.GetAll(x => x.OrderId == order.Id).ToList();

            foreach (var orderProduct in orderProducts)
            {
                _orderProductRepository.Delete(orderProduct, false);
            }


            foreach (var productId in order.ProductIds)
            {
                var orderProduct = new OrderProductEntity
                {
                    OrderId = orderEntity.Id,
                    ProductId = productId,
                    Quentity = order.Quentity
                };

                var hasProduct = _productRepository.GetById(productId);
                if (hasProduct == null)
                {
                    await _unitOfWork.RollBackTransaction();
                    throw new Exception($"Bu Id: {productId} de ürün bulunamadı.");
                }

                _orderProductRepository.Add(orderProduct);
            }


            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception("Sipariş bilgileri güncellenirken bir hata oluştu işlemler geriye alınıyor.");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Başarıyla güncellendi."
            };
        }
    }
}