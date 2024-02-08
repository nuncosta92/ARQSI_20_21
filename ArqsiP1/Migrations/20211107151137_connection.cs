using Microsoft.EntityFrameworkCore.Migrations;

namespace ArqsiP1.Migrations
{
    public partial class connection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    connectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strength = table.Column<int>(type: "int", nullable: false),
                    userA = table.Column<int>(type: "int", nullable: false),
                    userB = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.connectionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connection");
        }
    }
}
