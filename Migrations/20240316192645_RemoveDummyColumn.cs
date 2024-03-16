using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDummyColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DummyColumn",
                table: "T_hunters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DummyColumn",
                table: "T_hunters",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
