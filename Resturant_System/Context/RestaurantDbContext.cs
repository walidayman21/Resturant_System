using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resturant_System.Models;
using Resturant_System.Models.Enums;
using Resturant_System.ViewModels;

namespace Resturant_System.Context
{
    public class RestaurantDbContext : IdentityDbContext<ApplicationUser>
    {
        public RestaurantDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Customer> Customers {  get; set; }
        public DbSet<MenuItem> MenuItems {  get; set; }
        public DbSet<Order> Orders {  get; set; }
        public DbSet<OrderItem> OrderItems {  get; set; }
        public DbSet<Payment> Payments {  get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("data source =.; database = RestaurantSystem; integrated security = true; encrypt = false");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var SeedDateTime = new DateTime(2025, 10, 14, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasQueryFilter(x => !x.IsDeleted);
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasQueryFilter(p => !p.IsDeleted);

                entity.HasOne(x => x.Category)
                .WithMany(x => x.MenuItems)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasQueryFilter(p => !p.IsDeleted);

                entity.HasOne(x => x.MenuItem)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasQueryFilter(p => !p.IsDeleted);
                entity.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Payment>(entity => {
                entity.HasQueryFilter(p => !p.IsDeleted);

                entity.HasOne(x => x.Order)
                .WithOne(x => x.Payment)
                .HasForeignKey<Payment>(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Appetizers",
                    Type = "Starter",
                    IsAvailable = true,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 2,
                    Name = "Main Course",
                    Type = "Main",
                    IsAvailable = true,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 3,
                    Name = "Desserts",
                    Type = "Dessert",
                    IsAvailable = true,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 4,
                    Name = "Beverages",
                    Type = "Drinks",
                    IsAvailable = true,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 5,
                    Name = "Salads",
                    Type = "Starter",
                    IsAvailable = true,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                }
            );

            // ========================================
            // 2. MENU ITEMS
            // ========================================
            modelBuilder.Entity<MenuItem>().HasData(
                // Appetizers
                new MenuItem
                {
                    Id = 1,
                    Name = "Chicken Wings",
                    Description = "Crispy chicken wings with buffalo sauce",
                    Price = 85.00m,
                    ImgUrl = "/images/chicken-wings.jpg",
                    IsAvailable = true,
                    IsSpicy = true,
                    IsHealthy = false,
                    CategoryId = 1,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Mozzarella Sticks",
                    Description = "Deep fried mozzarella with marinara sauce",
                    Price = 65.00m,
                    ImgUrl = "/images/mozzarella-sticks.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = false,
                    CategoryId = 1,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Spring Rolls",
                    Description = "Vegetable spring rolls with sweet chili sauce",
                    Price = 55.00m,
                    ImgUrl = "/images/spring-rolls.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = true,
                    CategoryId = 1,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },

                // Main Course
                new MenuItem
                {
                    Id = 4,
                    Name = "Margherita Pizza",
                    Description = "Classic pizza with tomato, mozzarella and basil",
                    Price = 120.00m,
                    ImgUrl = "/images/margherita-pizza.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = false,
                    CategoryId = 2,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new MenuItem
                {
                    Id = 5,
                    Name = "Beef Burger",
                    Description = "Juicy beef patty with lettuce, tomato and cheese",
                    Price = 95.00m,
                    ImgUrl = "/images/beef-burger.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = false,
                    CategoryId = 2,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new MenuItem
                {
                    Id = 6,
                    Name = "Grilled Chicken",
                    Description = "Marinated grilled chicken breast with vegetables",
                    Price = 110.00m,
                    ImgUrl = "/images/grilled-chicken.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = true,
                    CategoryId = 2,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new MenuItem
                {
                    Id = 7,
                    Name = "Pasta Carbonara",
                    Description = "Creamy pasta with bacon and parmesan",
                    Price = 105.00m,
                    ImgUrl = "/images/pasta-carbonara.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = false,
                    CategoryId = 2,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new MenuItem
                {
                    Id = 8,
                    Name = "Spicy Thai Curry",
                    Description = "Red curry with chicken and vegetables",
                    Price = 115.00m,
                    ImgUrl = "/images/thai-curry.jpg",
                    IsAvailable = true,
                    IsSpicy = true,
                    IsHealthy = true,
                    CategoryId = 2,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },

                // Desserts
                new MenuItem
                {
                    Id = 9,
                    Name = "Chocolate Lava Cake",
                    Description = "Warm chocolate cake with molten center",
                    Price = 60.00m,
                    ImgUrl = "/images/lava-cake.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = false,
                    CategoryId = 3,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new MenuItem
                {
                    Id = 10,
                    Name = "Tiramisu",
                    Description = "Classic Italian dessert with coffee and mascarpone",
                    Price = 70.00m,
                    ImgUrl = "/images/tiramisu.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = false,
                    CategoryId = 3,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new MenuItem
                {
                    Id = 11,
                    Name = "Cheesecake",
                    Description = "New York style cheesecake with berry compote",
                    Price = 65.00m,
                    ImgUrl = "/images/cheesecake.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = false,
                    CategoryId = 3,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },

                // Beverages
                new MenuItem
                {
                    Id = 12,
                    Name = "Fresh Orange Juice",
                    Description = "Freshly squeezed orange juice",
                    Price = 25.00m,
                    ImgUrl = "/images/orange-juice.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = true,
                    CategoryId = 4,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new MenuItem
                {
                    Id = 13,
                    Name = "Soft Drink",
                    Description = "Coca Cola, Sprite, or Fanta",
                    Price = 15.00m,
                    ImgUrl = "/images/soft-drink.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = false,
                    CategoryId = 4,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new MenuItem
                {
                    Id = 14,
                    Name = "Iced Coffee",
                    Description = "Cold brew coffee with milk",
                    Price = 35.00m,
                    ImgUrl = "/images/iced-coffee.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = false,
                    CategoryId = 4,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },

                // Salads
                new MenuItem
                {
                    Id = 15,
                    Name = "Caesar Salad",
                    Description = "Romaine lettuce with parmesan and croutons",
                    Price = 50.00m,
                    ImgUrl = "/images/caesar-salad.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = true,
                    CategoryId = 5,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new MenuItem
                {
                    Id = 16,
                    Name = "Greek Salad",
                    Description = "Tomatoes, cucumber, olives and feta cheese",
                    Price = 55.00m,
                    ImgUrl = "/images/greek-salad.jpg",
                    IsAvailable = true,
                    IsSpicy = false,
                    IsHealthy = true,
                    CategoryId = 5,
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                }
            );

            // ========================================
            // 3. CUSTOMERS
            // ========================================
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Ahmed Mohamed",
                    PhoneNumber = "01012345678",
                    Address = "123 Main St, Cairo, Egypt",
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new Customer
                {
                    Id = 2,
                    Name = "Fatma Hassan",
                    PhoneNumber = "01123456789",
                    Address = "456 Nile St, Giza, Egypt",
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new Customer
                {
                    Id = 3,
                    Name = "Omar Ali",
                    PhoneNumber = "01234567890",
                    Address = "789 Pyramids Rd, Alexandria, Egypt",
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new Customer
                {
                    Id = 4,
                    Name = "Mona Ibrahim",
                    PhoneNumber = "01545678901",
                    Address = "321 Tahrir Sq, Cairo, Egypt",
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                },
                new Customer
                {
                    Id = 5,
                    Name = "Khaled Mahmoud",
                    PhoneNumber = "01098765432",
                    Address = "654 Corniche St, Luxor, Egypt",
                    CreatedAt = SeedDateTime,
                    IsDeleted = false
                }
            );

            // ========================================
            // 4. ORDERS
            // ========================================
            modelBuilder.Entity<Order>().HasData(
                // Order 1 - Dine In
                new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    PlacingOrder = OrderType.DinIn,
                    OrderStatus = OrderStatus.Completed,
                    TableNumber = 5,
                    Subtotal = 240.00m,
                    Tax = 20.40m,          // 8.5%
                    Discounts = 0.00m,
                    DeliveryFee = 0.00m,
                    TotalAmount = 260.40m,
                    PreparationTimeMinutes = 25,
                    DeliveryTime = 0,
                    Notes = "No onions please",
                    CreatedAt = SeedDateTime.AddDays(-5),
                    IsDeleted = false
                },
                // Order 2 - Delivery
                new Order
                {
                    Id = 2,
                    CustomerId = 2,
                    PlacingOrder = OrderType.Delivery,
                    OrderStatus = OrderStatus.OntheWay,
                    DeliveryAddress = "456 Nile St, Giza, Egypt",
                    Subtotal = 180.00m,
                    Tax = 15.30m,
                    Discounts = 0.00m,
                    DeliveryFee = 30.00m,
                    TotalAmount = 225.30m,
                    PreparationTimeMinutes = 20,
                    DeliveryTime = 30,
                    Notes = "Call when arriving",
                    CreatedAt = SeedDateTime.AddDays(-2),
                    IsDeleted = false
                },
                // Order 3 - Takeout
                new Order
                {
                    Id = 3,
                    CustomerId = 3,
                    PlacingOrder = OrderType.Takeout,
                    OrderStatus = OrderStatus.Ready,
                    Subtotal = 150.00m,
                    Tax = 12.75m,
                    Discounts = 0.00m,
                    DeliveryFee = 0.00m,
                    TotalAmount = 162.75m,
                    PreparationTimeMinutes = 15,
                    DeliveryTime = 0,
                    CreatedAt = SeedDateTime.AddDays(-1),
                    IsDeleted = false
                },
                // Order 4 - Dine In (Pending)
                new Order
                {
                    Id = 4,
                    CustomerId = 4,
                    PlacingOrder = OrderType.DinIn,
                    OrderStatus = OrderStatus.Preparing,
                    TableNumber = 12,
                    Subtotal = 320.00m,
                    Tax = 27.20m,
                    Discounts = 32.00m,    // 10% bulk discount
                    DeliveryFee = 0.00m,
                    TotalAmount = 315.20m,
                    PreparationTimeMinutes = 30,
                    DeliveryTime = 0,
                    Notes = "Extra spicy",
                    CreatedAt = SeedDateTime.AddHours(-2),
                    IsDeleted = false
                },
                // Order 5 - Delivery (Pending)
                new Order
                {
                    Id = 5,
                    CustomerId = 5,
                    PlacingOrder = OrderType.Delivery,
                    OrderStatus = OrderStatus.Pending,
                    DeliveryAddress = "654 Corniche St, Luxor, Egypt",
                    Subtotal = 95.00m,
                    Tax = 8.08m,
                    Discounts = 0.00m,
                    DeliveryFee = 30.00m,
                    TotalAmount = 133.08m,
                    PreparationTimeMinutes = 15,
                    DeliveryTime = 30,
                    CreatedAt = SeedDateTime.AddHours(-1),
                    IsDeleted = false
                }
            );

            // ========================================
            // 5. ORDER ITEMS
            // ========================================
            modelBuilder.Entity<OrderItem>().HasData(
                // Order 1 Items
                new OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    MenuItemId = 4,  // Margherita Pizza
                    Quantity = 2,
                    UnitPrice = 120.00m,
                    Subtotal = 240.00m,
                    CreatedAt = SeedDateTime.AddDays(-5),
                    IsDeleted = false
                },

                // Order 2 Items
                new OrderItem
                {
                    Id = 2,
                    OrderId = 2,
                    MenuItemId = 5,  // Beef Burger
                    Quantity = 1,
                    UnitPrice = 95.00m,
                    Subtotal = 95.00m,
                    CreatedAt = SeedDateTime.AddDays(-2),
                    IsDeleted = false
                },
                new OrderItem
                {
                    Id = 3,
                    OrderId = 2,
                    MenuItemId = 1,  // Chicken Wings
                    Quantity = 1,
                    UnitPrice = 85.00m,
                    Subtotal = 85.00m,
                    Notes = "Extra sauce",
                    CreatedAt = SeedDateTime.AddDays(-2),
                    IsDeleted = false
                },

                // Order 3 Items
                new OrderItem
                {
                    Id = 4,
                    OrderId = 3,
                    MenuItemId = 15, // Caesar Salad
                    Quantity = 1,
                    UnitPrice = 50.00m,
                    Subtotal = 50.00m,
                    CreatedAt = SeedDateTime.AddDays(-1),
                    IsDeleted = false
                },
                new OrderItem
                {
                    Id = 5,
                    OrderId = 3,
                    MenuItemId = 6,  // Grilled Chicken
                    Quantity = 1,
                    UnitPrice = 110.00m,
                    Subtotal = 110.00m,
                    CreatedAt = SeedDateTime.AddDays(-1),
                    IsDeleted = false
                },

                // Order 4 Items
                new OrderItem
                {
                    Id = 6,
                    OrderId = 4,
                    MenuItemId = 7,  // Pasta Carbonara
                    Quantity = 2,
                    UnitPrice = 105.00m,
                    Subtotal = 210.00m,
                    CreatedAt = SeedDateTime.AddHours(-2),
                    IsDeleted = false
                },
                new OrderItem
                {
                    Id = 7,
                    OrderId = 4,
                    MenuItemId = 9,  // Chocolate Lava Cake
                    Quantity = 2,
                    UnitPrice = 60.00m,
                    Subtotal = 120.00m,
                    CreatedAt = SeedDateTime.AddHours(-2),
                    IsDeleted = false
                },

                // Order 5 Items
                new OrderItem
                {
                    Id = 8,
                    OrderId = 5,
                    MenuItemId = 5,  // Beef Burger
                    Quantity = 1,
                    UnitPrice = 95.00m,
                    Subtotal = 95.00m,
                    CreatedAt = SeedDateTime.AddHours(-1),
                    IsDeleted = false
                }
            );

            // ========================================
            // 6. PAYMENTS
            // ========================================
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    OrderId = 1,
                    PaymentMethod = PaymentMethod.Cash,
                    TotalAmount = 260.40m,
                    PaymentStatus = PaymentStatus.Paid,
                    TransactionId = "TXN001",
                    CreatedAt = SeedDateTime.AddDays(-5),
                    IsDeleted = false
                },
                new Payment
                {
                    Id = 2,
                    OrderId = 2,
                    PaymentMethod = PaymentMethod.CreditCard,
                    TotalAmount = 225.30m,
                    PaymentStatus = PaymentStatus.Paid,
                    TransactionId = "TXN002",
                    CreatedAt = SeedDateTime.AddDays(-2),
                    IsDeleted = false
                },
                new Payment
                {
                    Id = 3,
                    OrderId = 3,
                    PaymentMethod = PaymentMethod.Cash,
                    TotalAmount = 162.75m,
                    PaymentStatus = PaymentStatus.Paid,
                    TransactionId = "TXN003",
                    CreatedAt = SeedDateTime.AddDays(-1),
                    IsDeleted = false
                },
                new Payment
                {
                    Id = 4,
                    OrderId = 4,
                    PaymentMethod = PaymentMethod.OnlinePayment,
                    TotalAmount = 315.20m,
                    PaymentStatus = PaymentStatus.Pending,
                    TransactionId = "TXN004",
                    CreatedAt = SeedDateTime.AddHours(-2),
                    IsDeleted = false
                },
                new Payment
                {
                    Id = 5,
                    OrderId = 5,
                    PaymentMethod = PaymentMethod.Cash,
                    TotalAmount = 133.08m,
                    PaymentStatus = PaymentStatus.Pending,
                    TransactionId = "TXN005",
                    CreatedAt = SeedDateTime.AddHours(-1),
                    IsDeleted = false
                }
            );
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = null;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Resturant_System.ViewModels.RegisterUserVM> RegisterUserVM { get; set; } = default!;
        public DbSet<Resturant_System.ViewModels.LoginVM> LoginVM { get; set; } = default!;
        //public DbSet<Resturant_System.ViewModels.OrderItemVM> OrderItemVM { get; set; } = default!;
        //public DbSet<Resturant_System.ViewModels.OrderVM> OrderVM { get; set; } = default!;
    }
}
        
    

