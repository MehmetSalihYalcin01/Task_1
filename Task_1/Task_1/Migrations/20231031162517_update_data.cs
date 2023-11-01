using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_1.Migrations
{
    /// <inheritdoc />
    public partial class update_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category_Id",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
