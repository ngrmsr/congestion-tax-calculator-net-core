using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace congestion.calculator.Migrations
{
    public partial class AddFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartHour = table.Column<int>(nullable: false),
                    StartMinute = table.Column<int>(nullable: false),
                    EndHour = table.Column<int>(nullable: false),
                    EndMinute = table.Column<int>(nullable: false),
                    Tax = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTime", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "Date" },
                values: new object[,]
                {
                    { 1, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2013, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2013, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2013, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2013, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2013, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2013, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2013, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2013, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2013, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2013, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2013, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2013, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2013, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2013, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TaxTime",
                columns: new[] { "Id", "EndHour", "EndMinute", "StartHour", "StartMinute", "Tax" },
                values: new object[,]
                {
                    { 7, 16, 59, 15, 30, 18 },
                    { 6, 15, 29, 15, 0, 13 },
                    { 5, 14, 59, 8, 30, 8 },
                    { 1, 6, 29, 6, 0, 8 },
                    { 3, 7, 59, 7, 0, 18 },
                    { 2, 6, 59, 6, 30, 13 },
                    { 8, 17, 59, 17, 0, 13 },
                    { 4, 8, 29, 8, 0, 13 },
                    { 9, 18, 29, 18, 0, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "TaxTime");
        }
    }
}
