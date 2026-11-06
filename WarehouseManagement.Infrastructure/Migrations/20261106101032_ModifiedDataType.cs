using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Warehouse_WarehouseId",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Warehouse_WarehouseId",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_WarehouseId",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Location");

            migrationBuilder.AddColumn<string>(
                name: "WarehouseId",
                table: "Warehouse",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "StockMovement",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "ProductVariant",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseId",
                table: "Location",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "Location",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "InventoryItem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "WarehouseId1",
                table: "InventoryItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Category",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "WarehouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "LocationId");

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
                name: "FK_Location_Warehouse_WarehouseId",
                table: "Location",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Warehouse_WarehouseId1",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Warehouse_WarehouseId",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_WarehouseId1",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "WarehouseId1",
                table: "InventoryItem");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Warehouse",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "PublicId",
                table: "Warehouse",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PublicId",
                table: "StockMovement",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublicId",
                table: "ProductVariant",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublicId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "Location",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "PublicId",
                table: "Location",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PublicId",
                table: "InventoryItem",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublicId",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublicId",
                table: "Brands",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_WarehouseId",
                table: "InventoryItem",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_Warehouse_WarehouseId",
                table: "InventoryItem",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Warehouse_WarehouseId",
                table: "Location",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
