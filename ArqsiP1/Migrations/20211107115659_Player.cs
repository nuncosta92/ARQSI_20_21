using Microsoft.EntityFrameworkCore.Migrations;

namespace ArqsiP1.Migrations
{
    public partial class Player : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    playerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emotionalState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.playerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
