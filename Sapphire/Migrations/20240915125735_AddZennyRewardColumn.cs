using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class AddZennyRewardColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42496df6-ef43-4470-88ef-a0eca0d38386");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a04cce1-42ab-470c-86d5-5de6f5265315");

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("a08f5e5e-3708-4ff6-9d3a-625b50538957"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("0802234b-a35c-4e3d-9ca1-1864e1eb1902"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("81e0e2cb-1e1b-4a0b-a22a-7b189807cc65"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("e32db408-4f3d-4737-b7b2-929445702bc9"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("09624731-26cf-4173-8208-b6c392018b63"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("2bcc6bde-fba9-459b-b5e8-f74619049afe"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("48662d72-f763-473a-beca-ba9288c72378"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("743de06d-4332-442c-b338-8385acb7a2bf"));

            migrationBuilder.AddColumn<double>(
                name: "ZennyReward",
                table: "T_quest",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b472c47f-cbb2-4e9b-99fc-7d5ad6014f9f", null, "Hunter", "HUNTER" },
                    { "d5571d85-cd8c-44fa-bd60-006bca102917", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("ae527beb-2010-40f5-90cf-81611b702526"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "SapphireUserId", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("34410b3e-ce73-4767-97cb-a12e44fb6025"), null, "Astera", 50, null, 9000.0 },
                    { new Guid("8a0959c2-5608-4c09-a12b-e5a4d20651c6"), null, "DarkShard", 1, null, 5000.0 },
                    { new Guid("9fd482bb-5c3e-4fc9-94de-8f5c8a589faa"), null, "Shard", 1, null, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("2f02a115-ee2d-4d2d-bad9-3a545485e294"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("1dfa56b1-b35c-4b32-a88a-391e793de29e"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("2f55ebda-b588-4737-a43f-1e1ee243deba"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("6b546241-a49e-4bf9-9e92-a97800ee0491"), 1.0, 1.0, 10000.0, "Rathian" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b472c47f-cbb2-4e9b-99fc-7d5ad6014f9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5571d85-cd8c-44fa-bd60-006bca102917");

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("ae527beb-2010-40f5-90cf-81611b702526"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("34410b3e-ce73-4767-97cb-a12e44fb6025"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("8a0959c2-5608-4c09-a12b-e5a4d20651c6"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("9fd482bb-5c3e-4fc9-94de-8f5c8a589faa"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("2f02a115-ee2d-4d2d-bad9-3a545485e294"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("1dfa56b1-b35c-4b32-a88a-391e793de29e"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("2f55ebda-b588-4737-a43f-1e1ee243deba"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("6b546241-a49e-4bf9-9e92-a97800ee0491"));

            migrationBuilder.DropColumn(
                name: "ZennyReward",
                table: "T_quest");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42496df6-ef43-4470-88ef-a0eca0d38386", null, "Hunter", "HUNTER" },
                    { "4a04cce1-42ab-470c-86d5-5de6f5265315", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("a08f5e5e-3708-4ff6-9d3a-625b50538957"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "GuildId", "HunterName", "Rank", "SapphireUserId", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("0802234b-a35c-4e3d-9ca1-1864e1eb1902"), null, "Shard", 1, null, 5000.0 },
                    { new Guid("81e0e2cb-1e1b-4a0b-a22a-7b189807cc65"), null, "DarkShard", 1, null, 5000.0 },
                    { new Guid("e32db408-4f3d-4737-b7b2-929445702bc9"), null, "Astera", 50, null, 9000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("09624731-26cf-4173-8208-b6c392018b63"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("2bcc6bde-fba9-459b-b5e8-f74619049afe"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("48662d72-f763-473a-beca-ba9288c72378"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("743de06d-4332-442c-b338-8385acb7a2bf"), 1.0, 1.0, 10000.0, "Rathian" }
                });
        }
    }
}
