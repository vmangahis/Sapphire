using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_hunters",
                columns: table => new
                {
                    HunterId = table.Column<Guid>(type: "uuid", nullable: false),
                    HunterName = table.Column<string>(type: "text", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    ZennyAmount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_hunters", x => x.HunterId);
                });

            migrationBuilder.CreateTable(
                name: "T_monsters",
                columns: table => new
                {
                    MonsterId = table.Column<Guid>(type: "uuid", nullable: false),
                    MonsterName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    HealthPool = table.Column<double>(type: "double precision", nullable: false),
                    BaseAttack = table.Column<double>(type: "double precision", nullable: false),
                    BaseDefense = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_monsters", x => x.MonsterId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_hunters");

            migrationBuilder.DropTable(
                name: "T_monsters");
        }
    }
}
