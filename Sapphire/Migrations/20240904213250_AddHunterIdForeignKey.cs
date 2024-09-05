using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class AddHunterIdForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "HunterId",
                table: "AspNetUsers");

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
    }
}
