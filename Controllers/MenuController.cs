using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using RestaurantAPI.Services.IServices;

namespace RestaurantAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MenuController : ControllerBase
	{
		private readonly IMenuService _menuService;

		public MenuController(IMenuService menuService)
		{
			_menuService = menuService;
		}

		[HttpGet]
		public async Task<ActionResult<List<MenuItem>>> GetAll()
		{
			var items = await _menuService.GetAllMenuItemsAsync();
			return Ok(items);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<MenuItem>> GetById(int id)
		{
			var item = await _menuService.GetMenuItemByIdAsync(id);
			if (item == null)
				return NotFound();

			return Ok(item);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<ActionResult<MenuItem>> Create([FromBody] MenuItemCreateDTO dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var created = await _menuService.CreateMenuItemAsync(dto);

			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[Authorize(Roles = "Admin")]
		[HttpPatch("{id}")]
		public async Task<ActionResult<MenuItem>> Update(int id, [FromBody] MenuItemUpdateDTO dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var updated = await _menuService.UpdateMenuItemAsync(id, dto);

			if (updated == null)
				return NotFound();

			return Ok(updated);
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var success = await _menuService.DeleteMenuItemAsync(id);

			if (!success)
				return NotFound();

			return NoContent();
		}
	}
}