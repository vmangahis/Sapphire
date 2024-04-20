using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sapphire.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataInsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "T_hunters",
                columns: new[] { "HunterId", "HunterName", "Rank", "ZennyAmount" },
                values: new object[,]
                {
                    { new Guid("8f392f52-6c2e-4149-9904-07dbe85cc8ed"), "Shard", 1, 5000.0 },
                    { new Guid("a01e20d7-b096-4467-a5ae-0b4210c7f114"), "DarkShard", 1, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "T_monsters",
                columns: new[] { "MonsterId", "BaseAttack", "BaseDefense", "HealthPool", "MonsterName" },
                values: new object[,]
                {
                    { new Guid("5deb29b7-08f2-4d93-90a9-6be2d636767a"), 1.0, 1.0, 10000.0, "Rathian" },
                    { new Guid("a6006a26-bc0b-4261-a68e-aed4a7d79cea"), 1.0, 1.0, 10000.0, "Rathalos" },
                    { new Guid("aa64a6d9-e4cd-4e23-b6d7-27349181c779"), 1.0, 1.0, 5000.0, "Yian Garuga" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("8f392f52-6c2e-4149-9904-07dbe85cc8ed"));

            migrationBuilder.DeleteData(
                table: "T_hunters",
                keyColumn: "HunterId",
                keyValue: new Guid("a01e20d7-b096-4467-a5ae-0b4210c7f114"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("5deb29b7-08f2-4d93-90a9-6be2d636767a"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("a6006a26-bc0b-4261-a68e-aed4a7d79cea"));

            migrationBuilder.DeleteData(
                table: "T_monsters",
                keyColumn: "MonsterId",
                keyValue: new Guid("aa64a6d9-e4cd-4e23-b6d7-27349181c779"));
        }
    }
}
