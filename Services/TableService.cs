using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.DTOs;
using RestaurantAPI.Services.IServices;

namespace RestaurantAPI.Services
{
	public class TableService(AppDBContext context) : ITableService
	{
		public async Task<List<TableDTO>> GetAllTablesAsync()
		{
			var tables = await context.Tables.ToListAsync();

			var tablesDTO = tables.Select(t => new TableDTO
			{
				Id = t.Id,
				Capacity = t.Capacity
			}).ToList();

			return tablesDTO;
		}
		public async Task<List<TableDTO>> GetAvailableTablesAsync(DateTime desiredTime, int guests)
		{
			DateTime start = desiredTime.AddHours(-2);
			DateTime end = desiredTime.AddHours(2);

			var busyTables = (await context.Bookings.Where(b => b.DateTime > start && b.DateTime < end).Select(b => b.TableIdFk).ToListAsync()).ToHashSet();

			var availableTables = await context.Tables.Where(t => !busyTables.Contains(t.Id) && t.Capacity >= guests).ToListAsync();

			var tablesDTO = availableTables.Select(t => new TableDTO
			{
				Id = t.Id,
				Capacity = t.Capacity
			}).ToList();

			return tablesDTO;
		}
	}
}