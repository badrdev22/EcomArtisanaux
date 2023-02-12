using Artisanaux.Web.Models;

namespace Artisanaux.Web.Services.IServices;

public interface IProductService:IBaseServise
{
    Task<T> GetAllProductsAsync<T>();
    Task<T> GetProductByIdAsync<T>(int id);
    Task<T> CreateProductAsync<T>(ProductDto product);
    Task<T> UpdateProductAsync<T>(ProductDto product);
    Task<T> DeleteProductAsync<T>(int id);

}
