using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyForCharacteRoleAndSapphireUserInCharacterModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "T_characterRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_characterRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "T_characters",
                columns: table => new
                {
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterName = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_T_characters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_T_characters_T_characterRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "T_characterRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_T_characters_RoleId",
                table: "T_characters",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_T_characters_UserId",
                table: "T_characters",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_characters");

            migrationBuilder.DropTable(
                name: "T_characterRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2f7fbdb-b939-4ef1-98e0-51cb283cba6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6133849-cb96-4d8f-8785-6a494e28dc89");

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
    }
}
