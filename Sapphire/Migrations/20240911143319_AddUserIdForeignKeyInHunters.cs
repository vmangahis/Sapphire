using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdForeignKeyInHunters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_T_hunters_HunterId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HunterId",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "HunterId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "SapphireUserId",
                table: "T_hunters",
                type: "text",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_T_hunters_SapphireUserId",
                table: "T_hunters",
                column: "SapphireUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_hunters_AspNetUsers_SapphireUserId",
                table: "T_hunters",
                column: "SapphireUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_hunters_AspNetUsers_SapphireUserId",
                table: "T_hunters");

            migrationBuilder.DropIndex(
                name: "IX_T_hunters_SapphireUserId",
                table: "T_hunters");

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

            migrationBuilder.DropColumn(
                name: "SapphireUserId",
                table: "T_hunters");

            migrationBuilder.AddColumn<Guid>(
                name: "HunterId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HunterId",
                table: "AspNetUsers",
                column: "HunterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_T_hunters_HunterId",
                table: "AspNetUsers",
                column: "HunterId",
                principalTable: "T_hunters",
                principalColumn: "HunterId");
        }
    }
}
