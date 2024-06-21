using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class CreateLocaleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_hunters_T_guild_GuildId",
                table: "T_hunters");

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("ed071df3-a5f0-4329-8df1-81caad7b14da"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("24566fa6-49aa-4830-ade3-f8443e7537d0"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("46c7a2e8-9391-4e75-b542-728bceaa5a13"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("1d2e2a7d-6bf8-4f6c-b95f-63a333a2c8d6"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("8d11c05d-e9bb-440a-8395-c4678b153c0d"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("be7999f2-7ab8-44f6-95a8-552e6206c131"));

            migrationBuilder.CreateTable(
                name: "T_locale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocaleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_locale", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName" },
                values: new object[] { new Guid("0b52360b-c190-4d8a-b415-18d409adff30"), "The Sapphire" });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("00a5fcb6-c94f-4bfb-b5c8-148953bcff28"), new Guid("00000000-0000-0000-0000-000000000000"), "Shard", 1, 5000.0 },
                    { new Guid("cd6e2fe1-b4ee-4b8c-9231-a5dcb4c4a718"), new Guid("00000000-0000-0000-0000-000000000000"), "DarkShard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("f7ccb500-9813-46b3-af64-18dc119160e7"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("61d0ca02-7470-4f58-833a-2aa721adb87d"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("b30d4afb-ed1a-483f-8a5a-6c07662f8918"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("f04912b8-48e5-4125-bea2-b5fb224b29c8"), 1.0, 1.0, 10000.0, "Rathian" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_T_hunters_T_guild_GuildId",
                table: "T_hunters",
                column: "GuildId",
                principalTable: "T_guild",
                principalColumn: "GuildId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_hunters_T_guild_GuildId",
                table: "T_hunters");

            migrationBuilder.DropTable(
                name: "T_locale");

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("0b52360b-c190-4d8a-b415-18d409adff30"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("00a5fcb6-c94f-4bfb-b5c8-148953bcff28"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("cd6e2fe1-b4ee-4b8c-9231-a5dcb4c4a718"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("61d0ca02-7470-4f58-833a-2aa721adb87d"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("b30d4afb-ed1a-483f-8a5a-6c07662f8918"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("f04912b8-48e5-4125-bea2-b5fb224b29c8"));

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName" },
                values: new object[] { new Guid("ed071df3-a5f0-4329-8df1-81caad7b14da"), "The Sapphire" });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("24566fa6-49aa-4830-ade3-f8443e7537d0"), null, "Shard", 1, 5000.0 },
                    { new Guid("46c7a2e8-9391-4e75-b542-728bceaa5a13"), null, "DarkShard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("1d2e2a7d-6bf8-4f6c-b95f-63a333a2c8d6"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("8d11c05d-e9bb-440a-8395-c4678b153c0d"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("be7999f2-7ab8-44f6-95a8-552e6206c131"), 1.0, 1.0, 10000.0, "Rathalos" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_T_hunters_T_guild_GuildId",
                table: "T_hunters",
                column: "GuildId",
                principalTable: "T_guild",
                principalColumn: "GuildId");
        }
    }
}
