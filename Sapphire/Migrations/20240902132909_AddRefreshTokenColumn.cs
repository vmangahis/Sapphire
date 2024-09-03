using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1194857-98c8-4098-94db-e0b09f988db0", null, "Hub Manager", "HUB MANAGER" },
                    { "cdda751f-b7c3-4752-955c-ae044490cee0", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("af530aec-4d3c-494c-aa5d-31666a43f6ce"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("1c8f6abf-11b9-4764-8810-179b5a607385"), null, "Astera", 50, 9000.0 },
                    { new Guid("da5c4dab-4e60-4ffe-98ae-becf48079d0e"), null, "DarkShard", 1, 5000.0 },
                    { new Guid("e34223d5-12c4-4eb9-89fc-621676be496c"), null, "Shard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("25925888-32e2-41b3-981a-1868d38fb118"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("03d15192-65b1-40be-a3ea-de0456a36833"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("1a835287-c542-4ea7-ac60-2759d47286da"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("35d6b7d1-ab46-4d37-bbbb-dd71966c5aa1"), 1.0, 1.0, 10000.0, "Rathalos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1194857-98c8-4098-94db-e0b09f988db0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdda751f-b7c3-4752-955c-ae044490cee0");

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("af530aec-4d3c-494c-aa5d-31666a43f6ce"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("1c8f6abf-11b9-4764-8810-179b5a607385"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("da5c4dab-4e60-4ffe-98ae-becf48079d0e"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("e34223d5-12c4-4eb9-89fc-621676be496c"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("25925888-32e2-41b3-981a-1868d38fb118"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("03d15192-65b1-40be-a3ea-de0456a36833"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("1a835287-c542-4ea7-ac60-2759d47286da"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("35d6b7d1-ab46-4d37-bbbb-dd71966c5aa1"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
