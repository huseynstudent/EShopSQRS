using Microsoft.AspNetCore.Mvc;
using StoreApp.Application.CQRS.Categories.Command.Request;
using StoreApp.Application.CQRS.Categories.Query.Request;
using MediatR;

namespace StoreApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
        {
            return Ok(await Sender.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            return Ok(await Sender.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok( await Sender.Send(new DeleteCategoryCommandRequest { Id = id }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await Sender.Send(new GetCategoryByIdQueryRequest { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory(GetAllCategoryQueryRequest request)
        {
            return Ok(await Sender.Send(request));
        }
    }
}