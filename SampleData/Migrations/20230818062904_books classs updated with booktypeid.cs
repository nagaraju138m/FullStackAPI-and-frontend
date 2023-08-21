using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleData.Migrations
{
    public partial class booksclasssupdatedwithbooktypeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_bookTypes_bookTypeId",
                table: "books");

            migrationBuilder.AlterColumn<int>(
                name: "bookTypeId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_books_bookTypes_bookTypeId",
                table: "books",
                column: "bookTypeId",
                principalTable: "bookTypes",
                principalColumn: "bookTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_bookTypes_bookTypeId",
                table: "books");

            migrationBuilder.AlterColumn<int>(
                name: "bookTypeId",
                table: "books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_books_bookTypes_bookTypeId",
                table: "books",
                column: "bookTypeId",
                principalTable: "bookTypes",
                principalColumn: "bookTypeId");
        }
    }
}
