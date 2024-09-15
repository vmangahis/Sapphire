using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "T_quest",
                columns: table => new
                {
                    QuestId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestTitle = table.Column<string>(type: "text", nullable: true),
                    QuestDescription = table.Column<string>(type: "text", nullable: true),
                    SapphireClientId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_quest", x => x.QuestId);
                    table.ForeignKey(
                        name: "FK_T_quest_AspNetUsers_SapphireClientId",
                        column: x => x.SapphireClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_T_quest_SapphireClientId",
                table: "T_quest",
                column: "SapphireClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_quest");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

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
    }
}
