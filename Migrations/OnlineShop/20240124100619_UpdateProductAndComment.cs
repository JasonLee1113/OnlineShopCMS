using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopCMS.Migrations.OnlineShop
{
    /// <inheritdoc />
    public partial class UpdateProductAndComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
          name: "Comments",
          columns: table => new
          {
              Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
              UserName = table.Column<string>(nullable: true),
              Content = table.Column<string>(nullable: true),
              Time = table.Column<DateTime>(nullable: false),
              ProductID = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
              table.PrimaryKey("PK_Comments", x => x.Id);
              table.ForeignKey(
                  name: "FK_Comments_Products_ProductID",
                  column: x => x.ProductID,
                  principalTable: "Product",
                  principalColumn: "Id",
                  onDelete: ReferentialAction.Cascade);
          });

            // 为 ProductID 创建索引，以便更高效地执行联接
            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductID",
                table: "Comments",
                column: "ProductID");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 删除 Comments 表
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
