using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace villaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addUsersToSB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2023, 1, 2, 13, 4, 55, 548, DateTimeKind.Local).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2023, 1, 2, 13, 4, 55, 548, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2023, 1, 2, 13, 4, 55, 548, DateTimeKind.Local).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 13, 4, 55, 548, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 13, 4, 55, 548, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 13, 4, 55, 548, DateTimeKind.Local).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 13, 4, 55, 548, DateTimeKind.Local).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 13, 4, 55, 548, DateTimeKind.Local).AddTicks(7047));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2022, 12, 25, 19, 2, 43, 230, DateTimeKind.Local).AddTicks(148));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2022, 12, 25, 19, 2, 43, 230, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2022, 12, 25, 19, 2, 43, 230, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 19, 2, 43, 229, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 19, 2, 43, 229, DateTimeKind.Local).AddTicks(9880));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 19, 2, 43, 229, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 19, 2, 43, 229, DateTimeKind.Local).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 19, 2, 43, 229, DateTimeKind.Local).AddTicks(9891));
        }
    }
}
