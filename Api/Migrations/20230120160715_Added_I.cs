using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDGen.Migrations
{
    public partial class Added_I : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARQ_EXPEDIENT_I",
                columns: table => new
                {
                    ARQ_EXPEDIENT_I_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMINTERN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARQ_EXPEDIENT_ID = table.Column<int>(type: "int", nullable: false),
                    AUDIT_USER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AUDIT_APP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AUDIT_DATAOPERACIOBBDD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AUDIT_OPERACIOBBDD_NI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ESBORRAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOMVISIBLE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARQ_EXPEDIENT_I", x => x.ARQ_EXPEDIENT_I_ID);
                    table.ForeignKey(
                        name: "FK_ARQ_EXPEDIENT_I_ARQ_EXPEDIENT_ARQ_EXPEDIENT_ID",
                        column: x => x.ARQ_EXPEDIENT_ID,
                        principalTable: "ARQ_EXPEDIENT",
                        principalColumn: "ARQ_EXPEDIENT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ARQ_EXPEDIENT_I_ARQ_EXPEDIENT_ID",
                table: "ARQ_EXPEDIENT_I",
                column: "ARQ_EXPEDIENT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARQ_EXPEDIENT_I");
        }
    }
}
