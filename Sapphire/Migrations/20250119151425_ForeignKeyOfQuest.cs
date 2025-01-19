using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyOfQuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_quest_AspNetUsers_SapphireClientId",
                table: "T_quest");

            migrationBuilder.DropForeignKey(
                name: "FK_T_quest_T_hunterClients_ClientId",
                table: "T_quest");

            migrationBuilder.DropIndex(
                name: "IX_T_quest_ClientId",
                table: "T_quest");

            migrationBuilder.DropIndex(
                name: "IX_T_quest_SapphireClientId",
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
                name: "SapphireClientId",
                table: "T_quest");

            migrationBuilder.AddColumn<Guid>(
                name: "SapphireId",
                table: "T_quest",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "T_hunterClients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "363ab17e-e472-4e51-ad3d-e3524a33737f", null, "Administrator", "ADMINISTRATOR" },
                    { "d9603a4b-6851-4636-995f-9522ed954cf3", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "T_characterRoles",
                columns: new[] { "RoleId", "CreatedDateTime", "RoleName", "UpdatedBy", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("209cf985-0c55-447a-bbd0-d7cd97b18e7f"), new DateTime(2025, 1, 19, 23, 14, 24, 803, DateTimeKind.Local).AddTicks(981), "Hunter", null, new DateTime(2025, 1, 19, 23, 14, 24, 803, DateTimeKind.Local).AddTicks(991) },
                    { new Guid("ffe9d8fd-1dd0-473a-a3b4-661d33cc136c"), new DateTime(2025, 1, 19, 23, 14, 24, 803, DateTimeKind.Local).AddTicks(994), "Client", null, new DateTime(2025, 1, 19, 23, 14, 24, 803, DateTimeKind.Local).AddTicks(995) }
                });

            migrationBuilder.InsertData(
                table: "T_guild",
                columns: new[] { "GuildId", "GuildName", "IsInviteOnly" },
                values: new object[] { new Guid("8e52d4ff-1fa7-4155-a849-4e8efedfb3f3"), "The Sapphire", false });

            migrationBuilder.InsertData(
                table: "T_locale",
                columns: new[] { "Id", "LocaleName" },
                values: new object[] { new Guid("fa66abc9-22c6-4b29-8d07-d3ac8a2c5407"), "Dummy Locale" });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("2f5f9ecc-d549-4353-9036-2d35373fb83a"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("3d0002d5-10b7-4164-b7be-de54d391da50"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("ed403ad1-a01a-40e0-85e2-9267c152e422"), 1.0, 1.0, 5000.0, "Yian Garuga" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "363ab17e-e472-4e51-ad3d-e3524a33737f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9603a4b-6851-4636-995f-9522ed954cf3");

            migrationBuilder.DeleteData(
                table: "T_characterRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("209cf985-0c55-447a-bbd0-d7cd97b18e7f"));

            migrationBuilder.DeleteData(
                table: "T_characterRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("ffe9d8fd-1dd0-473a-a3b4-661d33cc136c"));

            migrationBuilder.DeleteData(
                table: "T_guild",
                keyColumn: "GuildId",
                keyValue: new Guid("8e52d4ff-1fa7-4155-a849-4e8efedfb3f3"));

            migrationBuilder.DeleteData(
                table: "T_locale",
                keyColumn: "Id",
                keyValue: new Guid("fa66abc9-22c6-4b29-8d07-d3ac8a2c5407"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("2f5f9ecc-d549-4353-9036-2d35373fb83a"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("3d0002d5-10b7-4164-b7be-de54d391da50"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("ed403ad1-a01a-40e0-85e2-9267c152e422"));

            migrationBuilder.DropColumn(
                name: "SapphireId",
                table: "T_quest");

            migrationBuilder.AddColumn<string>(
                name: "SapphireClientId",
                table: "T_quest",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "T_hunterClients",
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
                name: "IX_T_quest_SapphireClientId",
                table: "T_quest",
                column: "SapphireClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_quest_AspNetUsers_SapphireClientId",
                table: "T_quest",
                column: "SapphireClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_T_quest_T_hunterClients_ClientId",
                table: "T_quest",
                column: "ClientId",
                principalTable: "T_hunterClients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
