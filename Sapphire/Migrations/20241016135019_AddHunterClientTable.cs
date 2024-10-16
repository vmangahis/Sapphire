using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class AddHunterClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2f7fbdb-b939-4ef1-98e0-51cb283cba6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6133849-cb96-4d8f-8785-6a494e28dc89");

            migrationBuilder.DeleteData(
                table: "T_characterRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("01761684-4888-48f5-9717-582f066ce60d"));

            migrationBuilder.DeleteData(
                table: "T_characterRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("15513fc4-430e-4bf2-95c9-994effabd61d"));

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("aa7a4518-1d3b-4df2-b453-f8bce3074abe"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("a2d90682-879b-4ab7-83cd-2842c004e127"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("20d3d696-6657-4ed3-b513-ad0fa16ae06f"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("7230468f-43d7-4278-9158-e2b552c100f2"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("9b15d43d-c9c3-44b1-82b4-fee5e9c4c138"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "T_quest",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "T_hunterClients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: false),
                    ClientRank = table.Column<int>(type: "integer", nullable: false),
                    ZennyBalance = table.Column<double>(type: "double precision", nullable: false),
                    SapphireUserId = table.Column<string>(type: "text", nullable: true),
                    GuildId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_hunterClients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_T_hunterClients_AspNetUsers_SapphireUserId",
                        column: x => x.SapphireUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_T_hunterClients_T_guild_GuildId",
                        column: x => x.GuildId,
                        principalTable: "T_guild",
                        principalColumn: "GuildId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a226dfe-2a63-4cb1-a8de-57ca14097446", null, "Administrator", "ADMINISTRATOR" },
                    { "ac044f43-8a6d-471b-9a55-783acc641225", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "T_characterRoles",
                columns: new[] { "RoleId", "CreatedDateTime", "RoleName", "UpdatedBy", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("d5f85f32-8bbe-4088-8b32-e322dd1b101b"), new DateTime(2024, 10, 16, 21, 50, 18, 656, DateTimeKind.Local).AddTicks(8007), "Client", null, new DateTime(2024, 10, 16, 21, 50, 18, 656, DateTimeKind.Local).AddTicks(8008) },
                    { new Guid("d5fd82f9-c05d-4e82-b759-c261896ecd6b"), new DateTime(2024, 10, 16, 21, 50, 18, 656, DateTimeKind.Local).AddTicks(7990), "Hunter", null, new DateTime(2024, 10, 16, 21, 50, 18, 656, DateTimeKind.Local).AddTicks(7999) }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("ee5b2152-38ee-46d0-9e85-9f580b9e3b77"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("22153d55-726d-46bf-be24-65272e4de735"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("2484f65a-4028-48f5-a91c-4cd0c1aa8ba9"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("c9893fc2-c906-4bdc-ae92-3638dce8b11f"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("f487d1c1-5e33-4882-8e31-2ddad55e16cc"), 1.0, 1.0, 5000.0, "Yian Garuga" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_quest_ClientId",
                table: "T_quest",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_T_hunterClients_GuildId",
                table: "T_hunterClients",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_T_hunterClients_SapphireUserId",
                table: "T_hunterClients",
                column: "SapphireUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_quest_T_hunterClients_ClientId",
                table: "T_quest",
                column: "ClientId",
                principalTable: "T_hunterClients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_quest_T_hunterClients_ClientId",
                table: "T_quest");

            migrationBuilder.DropTable(
                name: "T_hunterClients");

            migrationBuilder.DropIndex(
                name: "IX_T_quest_ClientId",
                table: "T_quest");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a226dfe-2a63-4cb1-a8de-57ca14097446");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac044f43-8a6d-471b-9a55-783acc641225");

            migrationBuilder.DeleteData(
                table: "T_characterRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("d5f85f32-8bbe-4088-8b32-e322dd1b101b"));

            migrationBuilder.DeleteData(
                table: "T_characterRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("d5fd82f9-c05d-4e82-b759-c261896ecd6b"));

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("ee5b2152-38ee-46d0-9e85-9f580b9e3b77"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("22153d55-726d-46bf-be24-65272e4de735"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("2484f65a-4028-48f5-a91c-4cd0c1aa8ba9"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("c9893fc2-c906-4bdc-ae92-3638dce8b11f"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("f487d1c1-5e33-4882-8e31-2ddad55e16cc"));

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "T_quest");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f2f7fbdb-b939-4ef1-98e0-51cb283cba6e", null, "User", "USER" },
                    { "f6133849-cb96-4d8f-8785-6a494e28dc89", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "T_characterRoles",
                columns: new[] { "RoleId", "CreatedDateTime", "RoleName", "UpdatedBy", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("01761684-4888-48f5-9717-582f066ce60d"), new DateTime(2024, 9, 22, 23, 56, 52, 588, DateTimeKind.Local).AddTicks(1247), "Client", null, new DateTime(2024, 9, 22, 23, 56, 52, 588, DateTimeKind.Local).AddTicks(1247) },
                    { new Guid("15513fc4-430e-4bf2-95c9-994effabd61d"), new DateTime(2024, 9, 22, 23, 56, 52, 588, DateTimeKind.Local).AddTicks(1233), "Hunter", null, new DateTime(2024, 9, 22, 23, 56, 52, 588, DateTimeKind.Local).AddTicks(1243) }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("aa7a4518-1d3b-4df2-b453-f8bce3074abe"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("a2d90682-879b-4ab7-83cd-2842c004e127"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("20d3d696-6657-4ed3-b513-ad0fa16ae06f"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("7230468f-43d7-4278-9158-e2b552c100f2"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("9b15d43d-c9c3-44b1-82b4-fee5e9c4c138"), 1.0, 1.0, 10000.0, "Rathian" }
                });
        }
    }
}
