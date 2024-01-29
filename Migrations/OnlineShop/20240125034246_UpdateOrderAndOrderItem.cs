using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopCMS.Migrations.OnlineShop
{
    /// <inheritdoc />
    public partial class UpdateOrderAndOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 创建 Order 表
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    ReceiverName = table.Column<string>(nullable: true),
                    ReceiverAddress = table.Column<string>(nullable: true),
                    ReceiverPhone = table.Column<string>(nullable: true),
                    Total = table.Column<int>(nullable: false),
                    isPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            // 创建 OrderItem 表
            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    SubTotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    // 如果 Product 表存在，你可能还需要为 ProductId 添加一个外键约束
                });

            // 索引用于加速查询性能
            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }
                   
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        // 删除 OrderItem 表
        migrationBuilder.DropTable(
            name: "OrderItems");

        // 删除 Order 表
        migrationBuilder.DropTable(
            name: "Orders");
    }
    }
}
