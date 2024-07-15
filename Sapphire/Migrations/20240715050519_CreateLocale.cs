using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class CreateLocale : Migration
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
                values: new object[] { new Guid("4f2c1d18-c4e0-44a5-bd7b-3edd63c06bf3"), "The Sapphire" });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("0d6779e4-00db-4835-bafa-362e0c348a56"), null, "Shard", 1, 5000.0 },
                    { new Guid("ddbf7a94-e2bf-4edd-b66f-6fe2dc514ede"), null, "DarkShard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("77657f78-0c9f-4c1f-95d8-f3393d627760"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("3cce0d3c-521e-493b-8ecf-9154e4a168b7"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("cedaeb3e-929c-4787-a90f-95dde056a850"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("e43b2524-b820-4a6a-9569-f5816b04163d"), 1.0, 1.0, 5000.0, "Yian Garuga" }
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
                keyValue: new Guid("4f2c1d18-c4e0-44a5-bd7b-3edd63c06bf3"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("0d6779e4-00db-4835-bafa-362e0c348a56"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("ddbf7a94-e2bf-4edd-b66f-6fe2dc514ede"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("3cce0d3c-521e-493b-8ecf-9154e4a168b7"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("cedaeb3e-929c-4787-a90f-95dde056a850"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("e43b2524-b820-4a6a-9569-f5816b04163d"));

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
