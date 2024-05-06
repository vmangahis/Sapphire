using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class AddGuildTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("8f392f52-6c2e-4149-9904-07dbe85cc8ed"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("a01e20d7-b096-4467-a5ae-0b4210c7f114"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("5deb29b7-08f2-4d93-90a9-6be2d636767a"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("a6006a26-bc0b-4261-a68e-aed4a7d79cea"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("aa64a6d9-e4cd-4e23-b6d7-27349181c779"));

            migrationBuilder.CreateTable(
                name: "T_guild",
                columns: table => new
                {
                    GuildId = table.Column<Guid>(type: "uuid", nullable: false),
                    GuildName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_guild", x => x.GuildId);
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName" },
                values: new object[] { new Guid("ac4ca2ca-e714-42cc-9023-177ed17a715e"), "The Sapphire" });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("50bc4caa-9bf4-469c-93b7-5a570eeb3367"), "Shard", 1, 5000.0 },
                    { new Guid("8df393e5-97be-444d-bdd0-57700fe4b5c7"), "DarkShard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("88e16c75-3fae-412f-b46a-a6a2022f19c3"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("e81cdf21-9047-4a23-a4a2-b80b1931c9a7"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("fdf06b52-39bd-4fc2-ba51-4e8bd3eedc90"), 1.0, 1.0, 10000.0, "Rathian" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_guild");

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("50bc4caa-9bf4-469c-93b7-5a570eeb3367"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("8df393e5-97be-444d-bdd0-57700fe4b5c7"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("88e16c75-3fae-412f-b46a-a6a2022f19c3"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("e81cdf21-9047-4a23-a4a2-b80b1931c9a7"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("fdf06b52-39bd-4fc2-ba51-4e8bd3eedc90"));

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("8f392f52-6c2e-4149-9904-07dbe85cc8ed"), "Shard", 1, 5000.0 },
                    { new Guid("a01e20d7-b096-4467-a5ae-0b4210c7f114"), "DarkShard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("5deb29b7-08f2-4d93-90a9-6be2d636767a"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("a6006a26-bc0b-4261-a68e-aed4a7d79cea"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("aa64a6d9-e4cd-4e23-b6d7-27349181c779"), 1.0, 1.0, 5000.0, "Yian Garuga" }
                });
        }
    }
}
