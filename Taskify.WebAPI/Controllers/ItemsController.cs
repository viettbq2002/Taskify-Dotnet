using Microsoft.AspNetCore.Mvc;
using Taskify.Application.DTOs.Item;
using Taskify.Application.DTOs.SubItem;
using Taskify.Application.Interfaces;


namespace Taskify.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ISubItemService _subItemService;

        public ItemsController(IItemService itemService, ISubItemService subItemService)
        {
            _itemService = itemService;
            _subItemService = subItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems(bool isArchived = false)
        {
            var response = await _itemService.GetListAsync(isArchived);
            return Ok(response);
        }
        [HttpPost("{itemId:int}/sub-items")]
        public async Task<IActionResult> AddSubItem(int itemId, [FromBody] CreateSubItem request)
        {
            var response = await _subItemService.CreateAsync(request, itemId);
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
