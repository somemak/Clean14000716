using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean14000716.Persistence.Migrations
{
    public partial class softdel11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Schools",
                newName: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Schools",
                newName: "IsDelete");
        }
    }
}
