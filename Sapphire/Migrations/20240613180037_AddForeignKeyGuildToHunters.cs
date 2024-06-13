using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyGuildToHunters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("ac4ca2ca-e714-42cc-9023-177ed17a715e"));

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

            migrationBuilder.AddColumn<Guid>(
                name: "GuildId",
                table: "T_hunters",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GuildName",
                table: "T_guild",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

            migrationBuilder.CreateIndex(
                name: "IX_T_hunters_GuildId",
                table: "T_hunters",
                column: "GuildId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_hunters_T_guild_GuildId",
                table: "T_hunters",
                column: "GuildId",
                principalTable: "T_guild",
                principalColumn: "GuildId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_hunters_T_guild_GuildId",
                table: "T_hunters");

            migrationBuilder.DropIndex(
                name: "IX_T_hunters_GuildId",
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

            migrationBuilder.DropColumn(
                name: "GuildId",
                table: "T_hunters");

            migrationBuilder.AlterColumn<string>(
                name: "GuildName",
                table: "T_guild",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
