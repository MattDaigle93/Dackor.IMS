using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Plugins.EFCore.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 1,
                column: "Size",
                value: "Letter");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 2,
                column: "Size",
                value: "Letter");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 3,
                column: "Size",
                value: "Letter");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 4,
                column: "Size",
                value: "Letter");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 5,
                column: "Size",
                value: "Letter");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 6,
                column: "Size",
                value: "Letter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Inventories");
        }
    }
}
