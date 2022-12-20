using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace villaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationtestingVillaNoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2022, 12, 20, 21, 42, 54, 853, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2022, 12, 20, 21, 42, 54, 853, DateTimeKind.Local).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2022, 12, 21, 21, 42, 54, 853, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 42, 54, 853, DateTimeKind.Local).AddTicks(8271));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 42, 54, 853, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 42, 54, 853, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 42, 54, 853, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 42, 54, 853, DateTimeKind.Local).AddTicks(8290));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2022, 12, 20, 21, 40, 45, 553, DateTimeKind.Local).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2022, 12, 20, 21, 40, 45, 553, DateTimeKind.Local).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2022, 12, 20, 21, 40, 45, 553, DateTimeKind.Local).AddTicks(5325));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 40, 45, 553, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 40, 45, 553, DateTimeKind.Local).AddTicks(5116));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 40, 45, 553, DateTimeKind.Local).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 40, 45, 553, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 20, 21, 40, 45, 553, DateTimeKind.Local).AddTicks(5123));
        }
    }
}
