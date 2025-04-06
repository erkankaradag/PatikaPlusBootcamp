using ShoppingApp.Business.Types;
using ShoppingApp.Business.Types;
using ShoppingApp.Business.Operations.Product.Dtos;



namespace ShoppingApp.Business.Operations.Product
{
    // lifetime must be specified
    public interface IProductService
    {
        Task<ServiceMessage> AddProduct(AddProductDto product);
        Task<ServiceMessage> PriceUpdate(int id, decimal changeBy);
        Task<ServiceMessage> DeleteProdut(int id);
        Task<ServiceMessage> UpdateProduct(UpdateProductDto product);
        Task<ProductDto> GetProduct(int id);
        Task<List<ProductDto>> GetAllProducts();
    }
}