namespace Artisanaux.Service.ProductAPI.Controllers;

using Artisanaux.Service.ProductAPI.Models.Dto;
using Artisanaux.Service.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


[Route("api/products")]
[ApiController]
public class ProductApiController : ControllerBase
{
   private readonly IProductRepository? _productRepository;
    private ResponseDto _response;

    public ProductApiController(IProductRepository? productRepository)
    {
        _productRepository = productRepository;
        _response = new ResponseDto();
    }

    [HttpGet]
    public async Task<object> Get() {
     IEnumerable<ProductDto> productDtos = await _productRepository!.GetProducts();
        _response.Result = productDtos;
        return Ok(_response);
    }
    [HttpGet("{id:int}")]
    public async Task<object> Get(int id)
    {
        ProductDto productDto = await _productRepository!.GetProductById(id);
        _response.Result = productDto;
        return Ok(_response);
    }
    [HttpPost]
    public async Task<object> Post(ProductDto productDto)
    {
        ProductDto product = await _productRepository!.CreateUpdateProduct(productDto);
        _response.Result = product;
        return Ok(_response);
    }

    [HttpPut]
    public async Task<object> Put(ProductDto productDto)
    {
        ProductDto product = await _productRepository!.CreateUpdateProduct(productDto);
        _response.Result = product;
        return Ok(_response);
    }
    [HttpDelete("{id:int}")]
    public async Task<object> Delete(int id)
    {
        bool isDeleted = await _productRepository!.DeleteProduct(id);
        _response.Result = isDeleted;
        return Ok(_response);
    }

}

