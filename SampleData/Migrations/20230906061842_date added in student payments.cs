using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleData.Migrations
{
    public partial class dateaddedinstudentpayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentsBooks_books_bookId",
                table: "studentsBooks");

            migrationBuilder.DropIndex(
                name: "IX_studentsBooks_bookId",
                table: "studentsBooks");

            migrationBuilder.AlterColumn<int>(
                name: "bookId",
                table: "studentsBooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PadiDate",
                table: "studentPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PadiDate",
                table: "studentPayments");

            migrationBuilder.AlterColumn<int>(
                name: "bookId",
                table: "studentsBooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_studentsBooks_bookId",
                table: "studentsBooks",
                column: "bookId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentsBooks_books_bookId",
                table: "studentsBooks",
                column: "bookId",
                principalTable: "books",
                principalColumn: "bookId");
        }
    }
}
