using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;
using RestaurantAPI.Enums;

namespace RestaurantAPI.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Booking> Bookings { get; set; } 
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", PasswordHash = "AQAAAAEAACcQAAAAEBi97q4umw8bVqnM/FsxXHASbTUVVvGzGy6W+Jcjpwg4Vzgh+htLWxuEm7ff0/SyAg==", Role = Role.Admin },
                new User { Id = 2, Username = "alice", PasswordHash = "AQAAAAEAACcQAAAAEHyBdmeLELoMJNGfFeQ9GavSk8cjHFJDsugEYR8HBnXo7vU7EpJl/MHmkXMJ3/m2sQ==", Role = Role.Admin },
                new User { Id = 3, Username = "bob", PasswordHash = "AQAAAAEAACcQAAAAEKzkbclkB1AnzmD1ROyWzSdoo+dWdfwtPSlKWnYmaPkWGr6/wfPiD7yMzJrRChVtlQ==", Role = Role.Admin }
            );

            modelBuilder.Entity<Table>().HasData(
                new Table { Id = 1, Capacity = 2 },
                new Table { Id = 2, Capacity = 2 },
                new Table { Id = 3, Capacity = 4 },
                new Table { Id = 4, Capacity = 4 },
                new Table { Id = 5, Capacity = 4 },
                new Table { Id = 6, Capacity = 6 },
                new Table { Id = 7, Capacity = 6 },
                new Table { Id = 8, Capacity = 6 },
                new Table { Id = 9, Capacity = 8 },
                new Table { Id = 10, Capacity = 8 },
                new Table { Id = 11, Capacity = 10 },
                new Table { Id = 12, Capacity = 12 }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Margherita Pizza", Price = 10.99m, Description = "Classic pizza with fresh mozzarella, basil, and tomato sauce.", IsPopular = true, ImageUrl = "https://example.com/images/1" },
                new MenuItem { Id = 2, Name = "Spaghetti Carbonara", Price = 13.50m, Description = "Creamy pasta with pancetta, parmesan, and black pepper.", IsPopular = true, ImageUrl = "https://example.com/images/2" },
                new MenuItem { Id = 3, Name = "Grilled Salmon", Price = 18.99m, Description = "Fresh salmon fillet grilled to perfection with lemon butter sauce.", IsPopular = false, ImageUrl = "https://example.com/images/3" },
                new MenuItem { Id = 4, Name = "Caesar Salad", Price = 9.50m, Description = "Romaine lettuce, parmesan, croutons, and Caesar dressing.", IsPopular = true, ImageUrl = "https://example.com/images/4" },
                new MenuItem { Id = 5, Name = "Beef Burger", Price = 12.99m, Description = "Juicy beef patty with cheddar, lettuce, tomato, and house sauce.", IsPopular = true, ImageUrl = "https://example.com/images/5" },
                new MenuItem { Id = 6, Name = "Chicken Tikka Masala", Price = 14.75m, Description = "Tender chicken in creamy spiced tomato sauce, served with rice.", IsPopular = true, ImageUrl = "https://example.com/images/6" },
                new MenuItem { Id = 7, Name = "Vegetable Stir Fry", Price = 11.25m, Description = "Mixed vegetables sautéed in soy-ginger sauce, served with noodles.", IsPopular = false, ImageUrl = "https://example.com/images/7" },
                new MenuItem { Id = 8, Name = "Sushi Platter", Price = 21.00m, Description = "Assorted nigiri and maki rolls with fresh fish and wasabi.", IsPopular = true, ImageUrl = "https://example.com/images/8" },
                new MenuItem { Id = 9, Name = "French Onion Soup", Price = 8.99m, Description = "Rich beef broth with caramelized onions, topped with melted cheese.", IsPopular = false, ImageUrl = "https://example.com/images/9" },
                new MenuItem { Id = 10, Name = "Ribeye Steak", Price = 24.50m, Description = "12oz ribeye cooked to order, served with mashed potatoes and veggies.", IsPopular = true, ImageUrl = "https://example.com/images/10" },
                new MenuItem { Id = 11, Name = "Chocolate Lava Cake", Price = 7.99m, Description = "Warm chocolate cake with molten center, served with vanilla ice cream.", IsPopular = true, ImageUrl = "https://example.com/images/11" },
                new MenuItem { Id = 12, Name = "Tiramisu", Price = 6.75m, Description = "Classic Italian dessert with espresso-soaked ladyfingers and mascarpone.", IsPopular = false, ImageUrl = "https://example.com/images/12" }
            );
        }
    }
}
