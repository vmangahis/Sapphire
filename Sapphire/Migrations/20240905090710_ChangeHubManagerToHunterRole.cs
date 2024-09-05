using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class ChangeHubManagerToHunterRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2076aea4-d8cc-4472-837c-668e0dd67e0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78761b80-4c9e-4f60-8005-33a2b93c9fd8");

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("7f6ad3fb-6f4d-48f7-84df-d41b45058e9f"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("4069b0e9-7bf4-4d04-bb87-acf16e6539ac"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("5f218367-8c7a-476a-bee8-33df1d8306a9"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("e5d4e86e-88a4-470c-8786-b664855a7eb7"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("d8a71bd7-b5ff-4799-b811-23d7921987da"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("1993bba8-ebc9-4ee7-9fd4-cebdbac5608c"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("25e0254a-64ea-4b7b-b64e-d494eed580be"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("fab8c641-fa9b-4471-bfe0-9c97ec886ca5"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76b05fc7-55de-4204-809c-77420811904e", null, "Administrator", "ADMINISTRATOR" },
                    { "a0c7af6b-39e6-46f6-a821-e676b73f21df", null, "Hunter", "HUNTER" }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("c3555d2c-04bb-4720-803d-596c310e74dc"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("44eb4e2d-ebb9-402b-b082-9cb4db9c0156"), null, "Astera", 50, 9000.0 },
                    { new Guid("64562d7b-6e3c-43de-9e57-c9b059e73617"), null, "Shard", 1, 5000.0 },
                    { new Guid("98a23a8e-2bf3-47e6-88f7-6b19bcd3f84c"), null, "DarkShard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("206a2feb-a979-4ffe-84a1-ca698552e9b5"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("22a08985-db92-4608-ab37-ba505b45d863"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("bb6f0b81-06f7-434b-b728-e7b30bf413f0"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("c636262c-54a2-4e91-881f-4db9c78f700f"), 1.0, 1.0, 10000.0, "Rathalos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76b05fc7-55de-4204-809c-77420811904e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0c7af6b-39e6-46f6-a821-e676b73f21df");

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("c3555d2c-04bb-4720-803d-596c310e74dc"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("44eb4e2d-ebb9-402b-b082-9cb4db9c0156"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("64562d7b-6e3c-43de-9e57-c9b059e73617"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("98a23a8e-2bf3-47e6-88f7-6b19bcd3f84c"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("206a2feb-a979-4ffe-84a1-ca698552e9b5"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("22a08985-db92-4608-ab37-ba505b45d863"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("bb6f0b81-06f7-434b-b728-e7b30bf413f0"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("c636262c-54a2-4e91-881f-4db9c78f700f"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2076aea4-d8cc-4472-837c-668e0dd67e0c", null, "Hub Manager", "HUB MANAGER" },
                    { "78761b80-4c9e-4f60-8005-33a2b93c9fd8", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("7f6ad3fb-6f4d-48f7-84df-d41b45058e9f"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("4069b0e9-7bf4-4d04-bb87-acf16e6539ac"), null, "Astera", 50, 9000.0 },
                    { new Guid("5f218367-8c7a-476a-bee8-33df1d8306a9"), null, "DarkShard", 1, 5000.0 },
                    { new Guid("e5d4e86e-88a4-470c-8786-b664855a7eb7"), null, "Shard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("d8a71bd7-b5ff-4799-b811-23d7921987da"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("1993bba8-ebc9-4ee7-9fd4-cebdbac5608c"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("25e0254a-64ea-4b7b-b64e-d494eed580be"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("fab8c641-fa9b-4471-bfe0-9c97ec886ca5"), 1.0, 1.0, 10000.0, "Rathalos" }
                });
        }
    }
}
