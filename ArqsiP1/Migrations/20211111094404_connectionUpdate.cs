using Microsoft.EntityFrameworkCore.Migrations;

namespace ArqsiP1.Migrations
{
    public partial class connectionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Connection",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Connection");
        }
    }
}
