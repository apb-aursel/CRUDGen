using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDGen.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARQ_EXPEDIENT",
                columns: table => new
                {
                    ARQ_EXPEDIENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ARQ_USUARI_NI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARQ_EXPEDIENTESTAT_NI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARQ_APP_NI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALFRESCOPATH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOMINTERN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AUDIT_USER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AUDIT_APP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AUDIT_DATAOPERACIOBBDD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AUDIT_OPERACIOBBDD_NI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ESBORRAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARQ_EVENT_FK = table.Column<int>(type: "int", nullable: false),
                    ARQ_APPFASES_NI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOMVISIBLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ARQ_EXPEDIENTTIPUS_NI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONCURRENCYGUID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARQ_EXPEDIENT", x => x.ARQ_EXPEDIENT_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARQ_EXPEDIENT");
        }
    }
}
