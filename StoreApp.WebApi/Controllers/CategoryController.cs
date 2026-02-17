using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Application.CQRS.Categories.Command.Request;
using StoreApp.Application.CQRS.Categories.Query.Request;

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
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await Sender.Send(new GetAllCategoryQueryRequest()));
        }
    }
}
