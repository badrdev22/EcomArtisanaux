using Artisanaux.Web.Models;

namespace Artisanaux.Web.Services.IServices;

public class ProductService : BaseServise,IProductService
{
    private readonly IHttpClientFactory _clientFactory;

    public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async  Task<T> CreateProductAsync<T>(ProductDto product)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = product,
            Url = SD.ProductApiBase + "/api/products",
            //Token = token
        });
    }

    public async Task<T> DeleteProductAsync<T>(int id)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.ProductApiBase + "/api/products/"+id,
            //Token = token
        }) ;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task<T> GetAllProductsAsync<T>()
    {
       return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductApiBase + "/api/products",
           //Token = token
        });
    }

    public async Task<T> GetProductByIdAsync<T>(int id)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductApiBase + "/api/products/"+id,
            //Token = token
        });
    }

   

    public async Task<T> UpdateProductAsync<T>(ProductDto product)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.PUT,
            Data= product,
            Url = SD.ProductApiBase + "/api/products",
            //Token = token
        });
    }
}
