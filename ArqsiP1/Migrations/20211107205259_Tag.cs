using Microsoft.EntityFrameworkCore.Migrations;

namespace ArqsiP1.Migrations
{
    public partial class Tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Introduction",
                columns: table => new
                {
                    introductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playerId = table.Column<int>(type: "int", nullable: false),
                    itermediatePlayerId = table.Column<int>(type: "int", nullable: false),
                    targetPlayerId = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Introduction", x => x.introductionId);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    tagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playerId = table.Column<int>(type: "int", nullable: true),
                    connectionId = table.Column<int>(type: "int", nullable: true),
                    postId = table.Column<int>(type: "int", nullable: true),
                    tag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.tagId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Introduction");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
