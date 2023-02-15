using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Plugins.EFCore.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsItemActive",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 1,
                column: "IsItemActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 2,
                column: "IsItemActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 3,
                column: "IsItemActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 4,
                column: "IsItemActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 5,
                column: "IsItemActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 6,
                column: "IsItemActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsItemActive",
                table: "Inventories");
        }
    }
}
