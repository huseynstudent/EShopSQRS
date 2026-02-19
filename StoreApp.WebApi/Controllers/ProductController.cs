using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Application.CQRS.Products.Command.Request;
using StoreApp.Application.CQRS.Products.Query.Request;

namespace StoreApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
    {
        return Ok(await Sender.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
    {
        return Ok(await Sender.Send(request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        return Ok(await Sender.Send(new DeleteProductCommandRequest { Id = id }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Sender.Send(new GetProductByIdQueryRequest { Id = id }));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(GetAllProductQueryRequest request)
    {
        return Ok(await Sender.Send(request));
    }
}