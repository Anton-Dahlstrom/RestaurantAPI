using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.DTOs;
using RestaurantAPI.Models;
using RestaurantAPI.Services.IServices;

namespace RestaurantAPI.Services
{
	public class MenuService(AppDBContext context) : IMenuService
	{
		public async Task<List<MenuItem>> GetAllMenuItemsAsync()
		{
			return await context.MenuItems.ToListAsync();
		}

		public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
		{
			return await context.MenuItems.FindAsync(id);
		}

		public async Task<MenuItem> CreateMenuItemAsync(MenuItemCreateDTO menuItemDTO)
		{
			MenuItem menuItem = new()
			{
				Name = menuItemDTO.Name,
				Price = menuItemDTO.Price!.Value,
				Description = menuItemDTO.Description,
				ImageUrl = menuItemDTO.ImageUrl,
			};
			context.MenuItems.Add(menuItem);
			await context.SaveChangesAsync();
			return menuItem;
		}

		public async Task<MenuItem?> UpdateMenuItemAsync(int id, MenuItemUpdateDTO updated)
		{
			var existing = await context.MenuItems.FindAsync(id);
			if (existing == null) return null;
			if (updated.Name != null) existing.Name = updated.Name;
			if (updated.Price != null) existing.Price = updated.Price.Value;
			if (updated.Description != null) existing.Description = updated.Description;
			if (updated.IsPopular != null) existing.IsPopular = updated.IsPopular.Value;
			if (updated.ImageUrl != null) existing.ImageUrl = updated.ImageUrl;

			await context.SaveChangesAsync();
			return existing;
		}

		public async Task<bool> DeleteMenuItemAsync(int id)
		{
			var existing = await context.MenuItems.FindAsync(id);
			if (existing == null) return false;

			context.MenuItems.Remove(existing);
			await context.SaveChangesAsync();
			return true;
		}
	}
}