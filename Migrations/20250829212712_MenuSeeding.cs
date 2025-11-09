using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantAPI.Migrations
{
	/// <inheritdoc />
	public partial class MenuSeeding : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "ImageUrl",
				table: "MenuItems",
				type: "nvarchar(2047)",
				maxLength: 2047,
				nullable: true);

			migrationBuilder.InsertData(
				table: "MenuItems",
				columns: new[] { "Id", "Description", "ImageUrl", "IsPopular", "Name", "Price" },
				values: new object[,]
				{
					{ 1, "Classic pizza with fresh mozzarella, basil, and tomato sauce.", "https://example.com/images/1", true, "Margherita Pizza", 10.99m },
					{ 2, "Creamy pasta with pancetta, parmesan, and black pepper.", "https://example.com/images/2", true, "Spaghetti Carbonara", 13.50m },
					{ 3, "Fresh salmon fillet grilled to perfection with lemon butter sauce.", "https://example.com/images/3", false, "Grilled Salmon", 18.99m },
					{ 4, "Romaine lettuce, parmesan, croutons, and Caesar dressing.", "https://example.com/images/4", true, "Caesar Salad", 9.50m },
					{ 5, "Juicy beef patty with cheddar, lettuce, tomato, and house sauce.", "https://example.com/images/5", true, "Beef Burger", 12.99m },
					{ 6, "Tender chicken in creamy spiced tomato sauce, served with rice.", "https://example.com/images/6", true, "Chicken Tikka Masala", 14.75m },
					{ 7, "Mixed vegetables sautéed in soy-ginger sauce, served with noodles.", "https://example.com/images/7", false, "Vegetable Stir Fry", 11.25m },
					{ 8, "Assorted nigiri and maki rolls with fresh fish and wasabi.", "https://example.com/images/8", true, "Sushi Platter", 21.00m },
					{ 9, "Rich beef broth with caramelized onions, topped with melted cheese.", "https://example.com/images/9", false, "French Onion Soup", 8.99m },
					{ 10, "12oz ribeye cooked to order, served with mashed potatoes and veggies.", "https://example.com/images/10", true, "Ribeye Steak", 24.50m },
					{ 11, "Warm chocolate cake with molten center, served with vanilla ice cream.", "https://example.com/images/11", true, "Chocolate Lava Cake", 7.99m },
					{ 12, "Classic Italian dessert with espresso-soaked ladyfingers and mascarpone.", "https://example.com/images/12", false, "Tiramisu", 6.75m }
				});

			migrationBuilder.CreateIndex(
				name: "IX_Bookings_CustomerIdFk",
				table: "Bookings",
				column: "CustomerIdFk");

			migrationBuilder.CreateIndex(
				name: "IX_Bookings_TableIdFk",
				table: "Bookings",
				column: "TableIdFk");

			migrationBuilder.AddForeignKey(
				name: "FK_Bookings_Customers_CustomerIdFk",
				table: "Bookings",
				column: "CustomerIdFk",
				principalTable: "Customers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Bookings_Tables_TableIdFk",
				table: "Bookings",
				column: "TableIdFk",
				principalTable: "Tables",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Bookings_Customers_CustomerIdFk",
				table: "Bookings");

			migrationBuilder.DropForeignKey(
				name: "FK_Bookings_Tables_TableIdFk",
				table: "Bookings");

			migrationBuilder.DropIndex(
				name: "IX_Bookings_CustomerIdFk",
				table: "Bookings");

			migrationBuilder.DropIndex(
				name: "IX_Bookings_TableIdFk",
				table: "Bookings");

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 3);

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 4);

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 5);

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 6);

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 7);

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 8);

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 9);

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 10);

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 11);

			migrationBuilder.DeleteData(
				table: "MenuItems",
				keyColumn: "Id",
				keyValue: 12);

			migrationBuilder.DropColumn(
				name: "ImageUrl",
				table: "MenuItems");
		}
	}
}