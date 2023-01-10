using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace villaAPI.Migrations
{
    /// <inheritdoc />
    public partial class createVillaNumberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumber",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumber", x => x.VillaNo);
                });

            migrationBuilder.InsertData(
                table: "VillaNumber",
                columns: new[] { "VillaNo", "CreatedDateTime", "SpecialDetails", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "For Physically Challenged", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "For Retired Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " For Super Senior Citizen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 36, 13, 435, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 36, 13, 435, DateTimeKind.Local).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 36, 13, 435, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 36, 13, 435, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 36, 13, 435, DateTimeKind.Local).AddTicks(8412));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumber");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 14, 17, 58, 14, 113, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 14, 17, 58, 14, 113, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 14, 17, 58, 14, 113, DateTimeKind.Local).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 14, 17, 58, 14, 113, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 14, 17, 58, 14, 113, DateTimeKind.Local).AddTicks(2637));
        }
    }
}
