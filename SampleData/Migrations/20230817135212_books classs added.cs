using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleData.Migrations
{
    public partial class booksclasssadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookTypes",
                columns: table => new
                {
                    bookTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booksType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bookTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookTypes", x => x.bookTypeId);
                });

            migrationBuilder.CreateTable(
                name: "studentPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    PaidAmount = table.Column<double>(type: "float", nullable: false),
                    AmountReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookTypeId = table.Column<int>(type: "int", nullable: true),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.bookId);
                    table.ForeignKey(
                        name: "FK_books_bookTypes_bookTypeId",
                        column: x => x.bookTypeId,
                        principalTable: "bookTypes",
                        principalColumn: "bookTypeId");
                });

            migrationBuilder.CreateTable(
                name: "studentsBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    bookId = table.Column<int>(type: "int", nullable: true),
                    hasBook = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentsBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentsBooks_books_bookId",
                        column: x => x.bookId,
                        principalTable: "books",
                        principalColumn: "bookId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_bookTypeId",
                table: "books",
                column: "bookTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsBooks_bookId",
                table: "studentsBooks",
                column: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentPayments");

            migrationBuilder.DropTable(
                name: "studentsBooks");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "bookTypes");
        }
    }
}
