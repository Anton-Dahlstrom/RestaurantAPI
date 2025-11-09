using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs;
using RestaurantAPI.Services.IServices;

namespace RestaurantAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TableController(ITableService tableService, IConfiguration config) : ControllerBase
	{
		private readonly ITableService _tableService = tableService;
		private readonly IConfiguration _config = config;

		[HttpGet]
		public async Task<ActionResult<List<TableDTO>>> GetAllTables()
		{
			List<TableDTO> tables = await _tableService.GetAllTablesAsync();

			return Ok(tables);
		}

		[HttpGet("AvailableTables")]
		public async Task<ActionResult<List<TableDTO>>> GetAvailableTables(DateTime dateTime, int guests)
		{
			List<TableDTO> tables = await _tableService.GetAvailableTablesAsync(dateTime, guests);

			return Ok(tables);
		}
	}
}