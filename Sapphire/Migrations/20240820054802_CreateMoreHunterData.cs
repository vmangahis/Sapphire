using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class CreateMoreHunterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("f823c8b0-e97a-4542-8274-d62163bcdd40"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("02c7a17b-867f-46ed-90b2-dc5e9109edde"), null, "Shard", 1, 5000.0 },
                    { new Guid("11394c8b-1437-4619-b46e-e109862b67f4"), null, "DarkShard", 1, 5000.0 },
                    { new Guid("dbc71757-e6aa-4d63-aeab-e0da209d69e8"), null, "Astera", 50, 9000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("69ca253a-c194-45aa-9982-600cfd40c20f"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("94dae4b5-0dfd-48cc-b5ae-8096837e3e26"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("bae8b04b-c28f-46d8-bb32-578c7a0d98f8"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("dafcecf7-0a89-4d54-a932-49c76448e8e6"), 1.0, 1.0, 5000.0, "Yian Garuga" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("f823c8b0-e97a-4542-8274-d62163bcdd40"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("02c7a17b-867f-46ed-90b2-dc5e9109edde"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("11394c8b-1437-4619-b46e-e109862b67f4"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("dbc71757-e6aa-4d63-aeab-e0da209d69e8"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("69ca253a-c194-45aa-9982-600cfd40c20f"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("94dae4b5-0dfd-48cc-b5ae-8096837e3e26"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("bae8b04b-c28f-46d8-bb32-578c7a0d98f8"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("dafcecf7-0a89-4d54-a932-49c76448e8e6"));

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
    }
}
