using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDGen.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARQDemo_Inetum",
                columns: table => new
                {
                    ARQ_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARQDemo_Inetum", x => x.ARQ_Id);
                });

            migrationBuilder.CreateTable(
                name: "ARQDemo_Inetum_Idioma",
                columns: table => new
                {
                    ARQDemo_Inetum_Idioma_Id = table.Column<int>(type: "int", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idioma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARQDemo_InetumARQ_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARQDemo_Inetum_Idioma", x => x.ARQDemo_Inetum_Idioma_Id);
                    table.ForeignKey(
                        name: "FK_ARQDemo_Inetum_Idioma_ARQDemo_Inetum_ARQDemo_InetumARQ_Id",
                        column: x => x.ARQDemo_InetumARQ_Id,
                        principalTable: "ARQDemo_Inetum",
                        principalColumn: "ARQ_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ARQDemo_Inetum_Idioma_ARQDemo_InetumARQ_Id",
                table: "ARQDemo_Inetum_Idioma",
                column: "ARQDemo_InetumARQ_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARQDemo_Inetum_Idioma");

            migrationBuilder.DropTable(
                name: "ARQDemo_Inetum");
        }
    }
}
