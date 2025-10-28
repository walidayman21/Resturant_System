using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resturant_System.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsSpicy = table.Column<bool>(type: "bit", nullable: false),
                    IsHealthy = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    PlacingOrder = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    PreparationTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Discounts = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DeliveryFee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TableNumber = table.Column<int>(type: "int", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    DeliveryTime = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsAvailable", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, false, "Appetizers", "Starter", null },
                    { 2, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, false, "Main Course", "Main", null },
                    { 3, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, false, "Desserts", "Dessert", null },
                    { 4, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, false, "Beverages", "Drinks", null },
                    { 5, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, false, "Salads", "Starter", null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "IsDeleted", "Name", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123 Main St, Cairo, Egypt", new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), false, "Ahmed Mohamed", "01012345678", null },
                    { 2, "456 Nile St, Giza, Egypt", new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), false, "Fatma Hassan", "01123456789", null },
                    { 3, "789 Pyramids Rd, Alexandria, Egypt", new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), false, "Omar Ali", "01234567890", null },
                    { 4, "321 Tahrir Sq, Cairo, Egypt", new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mona Ibrahim", "01545678901", null },
                    { 5, "654 Corniche St, Luxor, Egypt", new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), false, "Khaled Mahmoud", "01098765432", null }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImgUrl", "IsAvailable", "IsDeleted", "IsHealthy", "IsSpicy", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Crispy chicken wings with buffalo sauce", "/images/chicken-wings.jpg", true, false, false, true, "Chicken Wings", 85.00m, null },
                    { 2, 1, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Deep fried mozzarella with marinara sauce", "/images/mozzarella-sticks.jpg", true, false, false, false, "Mozzarella Sticks", 65.00m, null },
                    { 3, 1, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Vegetable spring rolls with sweet chili sauce", "/images/spring-rolls.jpg", true, false, true, false, "Spring Rolls", 55.00m, null },
                    { 4, 2, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Classic pizza with tomato, mozzarella and basil", "/images/margherita-pizza.jpg", true, false, false, false, "Margherita Pizza", 120.00m, null },
                    { 5, 2, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Juicy beef patty with lettuce, tomato and cheese", "/images/beef-burger.jpg", true, false, false, false, "Beef Burger", 95.00m, null },
                    { 6, 2, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Marinated grilled chicken breast with vegetables", "/images/grilled-chicken.jpg", true, false, true, false, "Grilled Chicken", 110.00m, null },
                    { 7, 2, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Creamy pasta with bacon and parmesan", "/images/pasta-carbonara.jpg", true, false, false, false, "Pasta Carbonara", 105.00m, null },
                    { 8, 2, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Red curry with chicken and vegetables", "/images/thai-curry.jpg", true, false, true, true, "Spicy Thai Curry", 115.00m, null },
                    { 9, 3, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Warm chocolate cake with molten center", "/images/lava-cake.jpg", true, false, false, false, "Chocolate Lava Cake", 60.00m, null },
                    { 10, 3, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Italian dessert with coffee and mascarpone", "/images/tiramisu.jpg", true, false, false, false, "Tiramisu", 70.00m, null },
                    { 11, 3, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "New York style cheesecake with berry compote", "/images/cheesecake.jpg", true, false, false, false, "Cheesecake", 65.00m, null },
                    { 12, 4, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Freshly squeezed orange juice", "/images/orange-juice.jpg", true, false, true, false, "Fresh Orange Juice", 25.00m, null },
                    { 13, 4, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Coca Cola, Sprite, or Fanta", "/images/soft-drink.jpg", true, false, false, false, "Soft Drink", 15.00m, null },
                    { 14, 4, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Cold brew coffee with milk", "/images/iced-coffee.jpg", true, false, false, false, "Iced Coffee", 35.00m, null },
                    { 15, 5, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Romaine lettuce with parmesan and croutons", "/images/caesar-salad.jpg", true, false, true, false, "Caesar Salad", 50.00m, null },
                    { 16, 5, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Tomatoes, cucumber, olives and feta cheese", "/images/greek-salad.jpg", true, false, true, false, "Greek Salad", 55.00m, null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "DeliveryAddress", "DeliveryFee", "DeliveryTime", "Discounts", "IsDeleted", "Notes", "OrderStatus", "PlacingOrder", "PreparationTimeMinutes", "Subtotal", "TableNumber", "Tax", "TotalAmount", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 0.00m, 0, 0.00m, false, "No onions please", 5, 1, 25, 240.00m, 5, 20.40m, 260.40m, null },
                    { 2, new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 2, "456 Nile St, Giza, Egypt", 30.00m, 30, 0.00m, false, "Call when arriving", 4, 3, 20, 180.00m, null, 15.30m, 225.30m, null },
                    { 3, new DateTime(2025, 10, 13, 0, 0, 0, 0, DateTimeKind.Utc), 3, null, 0.00m, 0, 0.00m, false, null, 3, 2, 15, 150.00m, null, 12.75m, 162.75m, null },
                    { 4, new DateTime(2025, 10, 13, 22, 0, 0, 0, DateTimeKind.Utc), 4, null, 0.00m, 0, 32.00m, false, "Extra spicy", 2, 1, 30, 320.00m, 12, 27.20m, 315.20m, null },
                    { 5, new DateTime(2025, 10, 13, 23, 0, 0, 0, DateTimeKind.Utc), 5, "654 Corniche St, Luxor, Egypt", 30.00m, 30, 0.00m, false, null, 1, 3, 15, 95.00m, null, 8.08m, 133.08m, null }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "MenuItemId", "Notes", "OrderId", "Quantity", "Subtotal", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), false, 4, null, 1, 2, 240.00m, 120.00m, null },
                    { 2, new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, 5, null, 2, 1, 95.00m, 95.00m, null },
                    { 3, new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, "Extra sauce", 2, 1, 85.00m, 85.00m, null },
                    { 4, new DateTime(2025, 10, 13, 0, 0, 0, 0, DateTimeKind.Utc), false, 15, null, 3, 1, 50.00m, 50.00m, null },
                    { 5, new DateTime(2025, 10, 13, 0, 0, 0, 0, DateTimeKind.Utc), false, 6, null, 3, 1, 110.00m, 110.00m, null },
                    { 6, new DateTime(2025, 10, 13, 22, 0, 0, 0, DateTimeKind.Utc), false, 7, null, 4, 2, 210.00m, 105.00m, null },
                    { 7, new DateTime(2025, 10, 13, 22, 0, 0, 0, DateTimeKind.Utc), false, 9, null, 4, 2, 120.00m, 60.00m, null },
                    { 8, new DateTime(2025, 10, 13, 23, 0, 0, 0, DateTimeKind.Utc), false, 5, null, 5, 1, 95.00m, 95.00m, null }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "OrderId", "PaymentMethod", "PaymentStatus", "TotalAmount", "TransactionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, 1, 2, 260.40m, "TXN001", null },
                    { 2, new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, 2, 2, 225.30m, "TXN002", null },
                    { 3, new DateTime(2025, 10, 13, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, 1, 2, 162.75m, "TXN003", null },
                    { 4, new DateTime(2025, 10, 13, 22, 0, 0, 0, DateTimeKind.Utc), false, 4, 3, 1, 315.20m, "TXN004", null },
                    { 5, new DateTime(2025, 10, 13, 23, 0, 0, 0, DateTimeKind.Utc), false, 5, 1, 1, 133.08m, "TXN005", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryId",
                table: "MenuItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
