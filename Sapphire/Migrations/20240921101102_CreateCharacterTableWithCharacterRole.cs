using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class CreateCharacterTableWithCharacterRole : Migration
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
                    { "01e660b7-183a-4b91-aa95-7b92295ac3e9", null, "Administrator", "ADMINISTRATOR" },
                    { "86d24464-e885-43b8-96b8-41d9835912bf", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "T_characterRoles",
                columns: new[] { "RoleId", "CreatedDateTime", "RoleName", "UpdatedBy", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("07944fcb-4604-46fe-8bab-020ff934d0e8"), new DateTime(2024, 9, 21, 18, 11, 1, 778, DateTimeKind.Local).AddTicks(4730), "Hunter", null, new DateTime(2024, 9, 21, 18, 11, 1, 778, DateTimeKind.Local).AddTicks(4741) },
                    { new Guid("1dd6fe3d-e4a6-4911-9f68-e620cc4838e9"), new DateTime(2024, 9, 21, 18, 11, 1, 778, DateTimeKind.Local).AddTicks(4746), "Client", null, new DateTime(2024, 9, 21, 18, 11, 1, 778, DateTimeKind.Local).AddTicks(4746) }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("03688c97-bb83-468a-ab59-6c46219b8e0b"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("344b3b2f-dd53-4492-9547-c1c38ddc27e9"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("4beaf92d-3415-4ae4-826f-19d393cbbe65"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("82399caa-b253-4806-a976-de63bc248108"), 1.0, 1.0, 5000.0, "Yian Garuga" },
                    { new Guid("e11c9db4-a3e3-4172-a398-11c077a562b7"), 1.0, 1.0, 10000.0, "Rathalos" }
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
                keyValue: "01e660b7-183a-4b91-aa95-7b92295ac3e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86d24464-e885-43b8-96b8-41d9835912bf");

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("03688c97-bb83-468a-ab59-6c46219b8e0b"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("344b3b2f-dd53-4492-9547-c1c38ddc27e9"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("4beaf92d-3415-4ae4-826f-19d393cbbe65"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("82399caa-b253-4806-a976-de63bc248108"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("e11c9db4-a3e3-4172-a398-11c077a562b7"));

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
