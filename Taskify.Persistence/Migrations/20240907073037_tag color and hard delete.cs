using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tagcolorandharddelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "TagColor",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagColor",
                table: "Tags");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
