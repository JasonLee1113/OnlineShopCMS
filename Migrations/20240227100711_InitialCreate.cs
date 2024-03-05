using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopCMS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Category",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Category", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Order",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiverAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiverPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Total = table.Column<int>(type: "int", nullable: false),
            //        isPaid = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Order", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Product",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Price = table.Column<int>(type: "int", nullable: false),
            //        Stock = table.Column<int>(type: "int", nullable: false),
            //        Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
            //        CategoryId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Product", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Product_Category_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Category",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderItems",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OrderId = table.Column<int>(type: "int", nullable: false),
            //        ProductID = table.Column<int>(type: "int", nullable: false),
            //        Amount = table.Column<int>(type: "int", nullable: false),
            //        SubTotal = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderItems", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_Order_OrderId",
            //            column: x => x.OrderId,
            //            principalTable: "Order",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Comment",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Time = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ProductID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Comment", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Comment_Product_ProductID",
            //            column: x => x.ProductID,
            //            principalTable: "Product",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comment_ProductID",
            //    table: "Comment",
            //    column: "ProductID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_OrderId",
            //    table: "OrderItems",
            //    column: "OrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Product_CategoryId",
            //    table: "Product",
            //    column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Comment");

            //migrationBuilder.DropTable(
            //    name: "OrderItems");

            migrationBuilder.DropTable(
                name: "User");

            //migrationBuilder.DropTable(
            //    name: "Product");

            //migrationBuilder.DropTable(
            //    name: "Order");

            //migrationBuilder.DropTable(
            //    name: "Category");
        }
    }
}
