using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace villaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addLocalUsersDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2023, 1, 2, 13, 9, 36, 97, DateTimeKind.Local).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2023, 1, 2, 13, 9, 36, 97, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2023, 1, 2, 13, 9, 36, 97, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 13, 9, 36, 97, DateTimeKind.Local).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 13, 9, 36, 97, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 13, 9, 36, 97, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 13, 9, 36, 97, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 13, 9, 36, 97, DateTimeKind.Local).AddTicks(9780));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

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
    }
}
