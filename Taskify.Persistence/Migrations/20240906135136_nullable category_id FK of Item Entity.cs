using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class nullablecategory_idFKofItemEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCateogries_CategoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "isArchived",
                table: "ItemCateogries",
                newName: "IsArchived");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCateogries_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "ItemCateogries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCateogries_CategoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "IsArchived",
                table: "ItemCateogries",
                newName: "isArchived");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCateogries_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "ItemCateogries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
