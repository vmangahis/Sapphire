using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class AddInviteOnlyColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("77657f78-0c9f-4c1f-95d8-f3393d627760"));

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

            migrationBuilder.AddColumn<bool>(
                name: "IsInviteOnly",
                table: "T_guild",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("3996a006-1f49-45f7-b3fd-39c784f0da21"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("1bdab344-4dfa-4f76-a05e-e7a73041d160"), null, "DarkShard", 1, 5000.0 },
                    { new Guid("f9d6bab1-56a1-443a-976c-928dd5f7a6a7"), null, "Shard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("a21e42bb-26c7-490b-8b41-5d6e63ec3db8"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("766ce59f-c096-41b4-bffa-2a48d7b602a6"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("a700f655-2a5f-47e8-8da4-39b3879c2364"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("ec4cb994-5452-432a-a4a0-aedcc606f147"), 1.0, 1.0, 5000.0, "Yian Garuga" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("3996a006-1f49-45f7-b3fd-39c784f0da21"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("1bdab344-4dfa-4f76-a05e-e7a73041d160"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("f9d6bab1-56a1-443a-976c-928dd5f7a6a7"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("a21e42bb-26c7-490b-8b41-5d6e63ec3db8"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("766ce59f-c096-41b4-bffa-2a48d7b602a6"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("a700f655-2a5f-47e8-8da4-39b3879c2364"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("ec4cb994-5452-432a-a4a0-aedcc606f147"));

            migrationBuilder.DropColumn(
                name: "IsInviteOnly",
                table: "T_guild");

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
        }
    }
}
