using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean14000716.Persistence.Migrations
{
    public partial class assss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Schools",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Schools");
        }
    }
}
