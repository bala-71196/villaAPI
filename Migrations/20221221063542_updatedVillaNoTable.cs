using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace villaAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatedVillaNoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "VillaNumber",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 100,
                columns: new[] { "CreatedDateTime", "VillaID" },
                values: new object[] { new DateTime(2022, 12, 21, 12, 5, 42, 370, DateTimeKind.Local).AddTicks(5823), 0 });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 101,
                columns: new[] { "CreatedDateTime", "VillaID" },
                values: new object[] { new DateTime(2022, 12, 21, 12, 5, 42, 370, DateTimeKind.Local).AddTicks(5825), 0 });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 102,
                columns: new[] { "CreatedDateTime", "VillaID" },
                values: new object[] { new DateTime(2022, 12, 21, 12, 5, 42, 370, DateTimeKind.Local).AddTicks(5826), 0 });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 21, 12, 5, 42, 370, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 21, 12, 5, 42, 370, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 21, 12, 5, 42, 370, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 21, 12, 5, 42, 370, DateTimeKind.Local).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 21, 12, 5, 42, 370, DateTimeKind.Local).AddTicks(5671));

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumber_VillaID",
                table: "VillaNumber",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumber_villas_VillaID",
                table: "VillaNumber",
                column: "VillaID",
                principalTable: "villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumber_villas_VillaID",
                table: "VillaNumber");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumber_VillaID",
                table: "VillaNumber");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "VillaNumber");

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
    }
}
