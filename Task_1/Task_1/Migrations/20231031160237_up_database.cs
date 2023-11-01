using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_1.Migrations
{
    /// <inheritdoc />
    public partial class up_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_categoryIdId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "categoryIdId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_categoryIdId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Category_Id",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "categoryIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_categoryIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_categoryIdId",
                table: "Products",
                column: "categoryIdId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
