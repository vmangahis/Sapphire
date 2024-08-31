using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("1ade5397-26bd-4e9c-9a7e-40b8473ac198"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("12c6549c-2505-4e56-8927-86d8ed7ed9b2"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("52147f83-d537-4f61-ae84-8215845563bb"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("823c9f43-3095-49c1-8c57-0c1cd5cfd912"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("466d7952-31ba-4e82-830a-3dbe46f29876"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("0a3d4ff9-d3a8-45c9-8502-fb278067b9d8"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("6277fc60-0c81-435f-8907-a487d41302fd"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("bb6aa2a3-f7f1-4299-889b-2c25b5e9b9ab"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e5d0d46-fe9e-4ee7-b186-cd1b0de7f8a9", null, "Administrator", "ADMINISTRATOR" },
                    { "61f2e27e-6291-4f64-af52-a596fde67503", null, "Hub Manager", "HUB MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("2f03b219-1e4e-40a6-9c39-4f23b3a38e77"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("98fd9371-f113-4524-913b-b6202d4b5b5f"), null, "Shard", 1, 5000.0 },
                    { new Guid("b33bc0f2-f0cb-4aa8-a144-513dd36a56f5"), null, "Astera", 50, 9000.0 },
                    { new Guid("c4320ced-c59a-4b7f-a66c-c60b666e7fe8"), null, "DarkShard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("885b662d-7841-4367-bf0d-5491992405ad"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("934feac6-2850-4b2e-aa3f-ac91073912b9"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("d36529cf-2adb-433e-bba9-9dda9bc29c3e"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("e8f87317-3e37-4f0d-b792-7711bb801708"), 1.0, 1.0, 10000.0, "Rathalos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e5d0d46-fe9e-4ee7-b186-cd1b0de7f8a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61f2e27e-6291-4f64-af52-a596fde67503");

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("2f03b219-1e4e-40a6-9c39-4f23b3a38e77"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("98fd9371-f113-4524-913b-b6202d4b5b5f"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("b33bc0f2-f0cb-4aa8-a144-513dd36a56f5"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("c4320ced-c59a-4b7f-a66c-c60b666e7fe8"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("885b662d-7841-4367-bf0d-5491992405ad"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("934feac6-2850-4b2e-aa3f-ac91073912b9"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("d36529cf-2adb-433e-bba9-9dda9bc29c3e"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("e8f87317-3e37-4f0d-b792-7711bb801708"));

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("1ade5397-26bd-4e9c-9a7e-40b8473ac198"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("12c6549c-2505-4e56-8927-86d8ed7ed9b2"), null, "DarkShard", 1, 5000.0 },
                    { new Guid("52147f83-d537-4f61-ae84-8215845563bb"), null, "Astera", 50, 9000.0 },
                    { new Guid("823c9f43-3095-49c1-8c57-0c1cd5cfd912"), null, "Shard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("466d7952-31ba-4e82-830a-3dbe46f29876"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("0a3d4ff9-d3a8-45c9-8502-fb278067b9d8"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("6277fc60-0c81-435f-8907-a487d41302fd"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("bb6aa2a3-f7f1-4299-889b-2c25b5e9b9ab"), 1.0, 1.0, 10000.0, "Rathalos" }
                });
        }
    }
}
