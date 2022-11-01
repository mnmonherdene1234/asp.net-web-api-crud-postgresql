using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPITest.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Students_StudentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentId",
                table: "Students",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Students_StudentId",
                table: "Students",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
