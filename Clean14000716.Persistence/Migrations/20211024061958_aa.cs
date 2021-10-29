using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean14000716.Persistence.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BlogPostId",
                table: "TeacherStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TagId",
                table: "TeacherStudents",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlogPostId",
                table: "TeacherStudents");

            migrationBuilder.DropIndex(
                name: "IX_TagId",
                table: "TeacherStudents");
        }
    }
}
