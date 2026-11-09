using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFKChangeDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Warehouse_WarehouseId1",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Brands_BrandId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_BrandId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_WarehouseId1",
                table: "InventoryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "WarehouseId1",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "BrandId1",
                table: "Warehouse",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseId",
                table: "StockMovement",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BrandId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseId",
                table: "InventoryItem",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BrandId",
                table: "Brands",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_BrandId1",
                table: "Warehouse",
                column: "BrandId1");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_WarehouseId",
                table: "InventoryItem",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_Warehouse_WarehouseId",
                table: "InventoryItem",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Brands_BrandId1",
                table: "Warehouse",
                column: "BrandId1",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Warehouse_WarehouseId",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Brands_BrandId1",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_BrandId1",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_WarehouseId",
                table: "InventoryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "BrandId1",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Brands");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "StockMovement",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "InventoryItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "WarehouseId1",
                table: "InventoryItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_BrandId",
                table: "Warehouse",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_WarehouseId1",
                table: "InventoryItem",
                column: "WarehouseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_Warehouse_WarehouseId1",
                table: "InventoryItem",
                column: "WarehouseId1",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Brands_BrandId",
                table: "Warehouse",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
