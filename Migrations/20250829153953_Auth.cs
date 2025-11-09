using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantAPI.Migrations
{
	/// <inheritdoc />
	public partial class Auth : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_Users",
				table: "Users");

			migrationBuilder.DeleteData(
				table: "Users",
				keyColumn: "Username",
				keyValue: "admin");

			migrationBuilder.DeleteData(
				table: "Users",
				keyColumn: "Username",
				keyValue: "alice");

			migrationBuilder.DeleteData(
				table: "Users",
				keyColumn: "Username",
				keyValue: "bob");

			migrationBuilder.RenameColumn(
				name: "Passwordhash",
				table: "Users",
				newName: "PasswordHash");

			migrationBuilder.AlterColumn<string>(
				name: "Username",
				table: "Users",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)");

			migrationBuilder.AddColumn<int>(
				name: "Id",
				table: "Users",
				type: "int",
				nullable: false,
				defaultValue: 0)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AddColumn<string>(
				name: "Email",
				table: "Users",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Users",
				table: "Users",
				column: "Id");

			migrationBuilder.InsertData(
				table: "Users",
				columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
				values: new object[,]
				{
					{ 1, "", "AQAAAAEAACcQAAAAEBi97q4umw8bVqnM/FsxXHASbTUVVvGzGy6W+Jcjpwg4Vzgh+htLWxuEm7ff0/SyAg==", 1, "admin" },
					{ 2, "", "AQAAAAEAACcQAAAAEHyBdmeLELoMJNGfFeQ9GavSk8cjHFJDsugEYR8HBnXo7vU7EpJl/MHmkXMJ3/m2sQ==", 1, "alice" },
					{ 3, "", "AQAAAAEAACcQAAAAEKzkbclkB1AnzmD1ROyWzSdoo+dWdfwtPSlKWnYmaPkWGr6/wfPiD7yMzJrRChVtlQ==", 1, "bob" }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_Users",
				table: "Users");

			migrationBuilder.DeleteData(
				table: "Users",
				keyColumn: "Id",
				keyColumnType: "int",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "Users",
				keyColumn: "Id",
				keyColumnType: "int",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "Users",
				keyColumn: "Id",
				keyColumnType: "int",
				keyValue: 3);

			migrationBuilder.DropColumn(
				name: "Id",
				table: "Users");

			migrationBuilder.DropColumn(
				name: "Email",
				table: "Users");

			migrationBuilder.RenameColumn(
				name: "PasswordHash",
				table: "Users",
				newName: "Passwordhash");

			migrationBuilder.AlterColumn<string>(
				name: "Username",
				table: "Users",
				type: "nvarchar(450)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Users",
				table: "Users",
				column: "Username");

			migrationBuilder.InsertData(
				table: "Users",
				columns: new[] { "Username", "Passwordhash", "Role" },
				values: new object[,]
				{
					{ "admin", "AQAAAAEAACcQAAAAEBi97q4umw8bVqnM/FsxXHASbTUVVvGzGy6W+Jcjpwg4Vzgh+htLWxuEm7ff0/SyAg==", 1 },
					{ "alice", "AQAAAAEAACcQAAAAEHyBdmeLELoMJNGfFeQ9GavSk8cjHFJDsugEYR8HBnXo7vU7EpJl/MHmkXMJ3/m2sQ==", 1 },
					{ "bob", "AQAAAAEAACcQAAAAEKzkbclkB1AnzmD1ROyWzSdoo+dWdfwtPSlKWnYmaPkWGr6/wfPiD7yMzJrRChVtlQ==", 1 }
				});
		}
	}
}