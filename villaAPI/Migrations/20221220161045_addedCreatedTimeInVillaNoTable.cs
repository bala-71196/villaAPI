using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace villaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedCreatedTimeInVillaNoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
