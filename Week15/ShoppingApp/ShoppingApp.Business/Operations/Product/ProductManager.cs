using Microsoft.EntityFrameworkCore;
using ShoppingApp.Business.Types;
using ShoppingApp.Data.Entities;
using ShoppingApp.Data.Repositories;
using ShoppingApp.Data.UnitOfWork;
using ShoppingApp.Business.Operations.Product.Dtos;
using ShoppingApp.Business.Types;
using ShoppingApp.Data.Entities;
using ShoppingApp.Data.Repositories;
using ShoppingApp.Data.UnitOfWork;

namespace ShoppingApp.Business.Operations.Product
{

    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProductEntity> _repository;

        public ProductManager(IUnitOfWork unitOfWork, IRepository<ProductEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ServiceMessage> AddProduct(AddProductDto product)
        {
            var hasProduct = _repository.GetAll(x => x.ProductName.ToLower() == product.ProductName.ToLower()).Any();

            if (hasProduct)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu ürün bulunuyor."
                };
            }

            var productEntity = new ProductEntity
            {
                ProductName = product.ProductName,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            };

            _repository.Add(productEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Ürün kaydı sırasında bir hata oluştu.");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Ürün eklendi"
            };
        }

        public async Task<ServiceMessage> DeleteProdut(int id)
        {
            var product = _repository.GetById(id);

            if (product is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Silinmek istenen ürün bulunamadı."
                };
            }

            _repository.Delete(id);


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

        public Task<List<ProductDto>> GetAllProducts()
        {
            var products = _repository.GetAll().Select(x => new ProductDto
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                ProductName = x.ProductName,
                Price = x.Price,
                StockQuantity = x.StockQuantity
            }).ToListAsync();

            return products;
        }

        public Task<ProductDto> GetProduct(int id)
        {
            var product = _repository.GetAll(x => x.Id == id).Select(x => new ProductDto
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                ProductName = x.ProductName,
                Price = x.Price,
                StockQuantity = x.StockQuantity
            }).FirstOrDefaultAsync();

            return product;
        }

        public async Task<ServiceMessage> PriceUpdate(int id, decimal changeBy)
        {
            var product = _repository.GetById(id);

            if (product is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu id ye ait ürün bulunamadı."
                };
            }

            product.Price = changeBy;

            _repository.Update(product);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Ürün fiyatı güncellenirken bir hata oluştu.");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Ürün güncellendi."
            };
        }

        public async Task<ServiceMessage> UpdateProduct(UpdateProductDto product)
        {
            var productEntity = _repository.GetById(product.Id);

            if (productEntity is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Güncellenmek istenen ürün bulunamadı."
                };
            }

            await _unitOfWork.BeginTransaction();

            productEntity.ProductName = product.ProductName;
            productEntity.Price = product.Price;
            productEntity.StockQuantity = product.StockQuantity;

            _repository.Update(productEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception("Ürün bilgileri güncellenirken bir hata oluştu işlemler geriye alınıyor.");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Başarıyla güncellendi."
            };
        }
    }
}