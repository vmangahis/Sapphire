using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDefaultValueOfRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "737a033e-9ef6-478d-a5a1-5cf95ec4c1c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86ca648f-39a8-4a80-8438-1519aeac1ffa");

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("e861a297-82fb-4196-a0f4-fa83316afc64"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("0d6cdf87-d477-4f25-af23-5fbe8fab0331"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("353ba4ed-23a1-407d-aaf4-339abf151dcf"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("6ba94c2e-9275-4a6a-b924-ba24b07cf047"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("59997b32-66ea-477a-a7f5-c89c198cacf3"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("036ff377-9686-4ff5-9f4d-171bcdc10f24"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("0b8d31d7-70a0-4138-8306-22003af4b7cb"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("d6918eca-5c6c-40cf-80ac-06f6a3207d07"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1986680f-c514-4e5c-b210-a0b393dec91f", null, "Administrator", "ADMINISTRATOR" },
                    { "2b7e8400-6a49-46b2-94a9-4000b1e7c7da", null, "Hunter", "HUNTER" }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("2c1c95a8-4aa6-45bd-91de-cd9f922976e9"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "SapphireUserId", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("1d6ab5de-1dc2-431c-b0d2-9efa642d9469"), null, "Astera", 50, null, 9000.0 },
                    { new Guid("650d8286-ef02-49e5-8146-80895d5d446d"), null, "Shard", 1, null, 5000.0 },
                    { new Guid("f7e1b751-7b57-4615-a746-0d3c8844d71c"), null, "DarkShard", 1, null, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("7780584c-7c2a-43f1-ae0f-fa82f77594f1"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("79f1c29a-782d-46c3-9f5c-14a1b99ce4ca"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("8ed5844a-785b-4439-81ad-aa168dd049ce"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("a98859d5-de8d-44ae-95c1-1d4468c86c12"), 1.0, 1.0, 5000.0, "Yian Garuga" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1986680f-c514-4e5c-b210-a0b393dec91f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b7e8400-6a49-46b2-94a9-4000b1e7c7da");

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("2c1c95a8-4aa6-45bd-91de-cd9f922976e9"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("1d6ab5de-1dc2-431c-b0d2-9efa642d9469"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("650d8286-ef02-49e5-8146-80895d5d446d"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("f7e1b751-7b57-4615-a746-0d3c8844d71c"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("7780584c-7c2a-43f1-ae0f-fa82f77594f1"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("79f1c29a-782d-46c3-9f5c-14a1b99ce4ca"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("8ed5844a-785b-4439-81ad-aa168dd049ce"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("a98859d5-de8d-44ae-95c1-1d4468c86c12"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "737a033e-9ef6-478d-a5a1-5cf95ec4c1c7", null, "Hunter", "HUNTER" },
                    { "86ca648f-39a8-4a80-8438-1519aeac1ffa", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("e861a297-82fb-4196-a0f4-fa83316afc64"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "SapphireUserId", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("0d6cdf87-d477-4f25-af23-5fbe8fab0331"), null, "DarkShard", 1, null, 5000.0 },
                    { new Guid("353ba4ed-23a1-407d-aaf4-339abf151dcf"), null, "Astera", 50, null, 9000.0 },
                    { new Guid("6ba94c2e-9275-4a6a-b924-ba24b07cf047"), null, "Shard", 1, null, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("59997b32-66ea-477a-a7f5-c89c198cacf3"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("036ff377-9686-4ff5-9f4d-171bcdc10f24"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("0b8d31d7-70a0-4138-8306-22003af4b7cb"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("d6918eca-5c6c-40cf-80ac-06f6a3207d07"), 1.0, 1.0, 10000.0, "Rathalos" }
                });
        }
    }
}
