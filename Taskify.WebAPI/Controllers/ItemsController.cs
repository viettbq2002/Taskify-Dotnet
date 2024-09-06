using Microsoft.AspNetCore.Mvc;
using Taskify.Application.DTOs.Item;
using Taskify.Application.Interfaces;


namespace Taskify.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems(bool isArchived = false)
        {
            var response = await _itemService.GetListAsync(isArchived);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItem request)
        {
            var response = await _itemService.CreateAsync(request);
            return Created(String.Empty, request);


        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
