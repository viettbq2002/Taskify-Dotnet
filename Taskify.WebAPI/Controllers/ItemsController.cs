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

        [HttpGet("{itemId:int}")]
        public string Get(int itemId)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItem request)
        {
            var response = await _itemService.CreateAsync(request);
            return Created(String.Empty, request);


        }

        [HttpPut("{itemId:int}")]
        public async Task<IActionResult> UpdateItem(int itemId, [FromBody] UpdateItem request)
        {
            var response = await _itemService.UpdateAsync(itemId, request);
            return Ok(response);

        }
        [HttpPut("complete-all")]
        public async Task<IActionResult> ClearCompletedTask()
        {
            await _itemService.ClearCompletedItemsAsync();
            return NoContent();

        }

        // DELETE api/<ItemController>/5
        [HttpDelete("clear-archived")]
        public async Task<IActionResult> Delete()
        {
            await _itemService.DeleteArchiveItemsAsync();
            return NoContent();
        }
    }
}
