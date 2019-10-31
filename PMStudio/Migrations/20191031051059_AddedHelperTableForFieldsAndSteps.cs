using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace PMStudio.Migrations
{
    public partial class AddedHelperTableForFieldsAndSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PASOS_PLANTILLAS_DATOS_DETALLE",
                columns: table => new
                {
                    ID_PASOS_INSTANCIAS_DATOS = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    PLANTILLA_CAMPO = table.Column<int>(nullable: false),
                    PASO = table.Column<int>(nullable: false),
                    SOLO_LECTURA = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PASOS_PLANTILLAS_DATOS_DETALLE", x => x.ID_PASOS_INSTANCIAS_DATOS);
                    table.ForeignKey(
                        name: "FK_PASOS_PLANTILLAS_DATOS_DETALLE_PASOS_PASO",
                        column: x => x.PASO,
                        principalTable: "PASOS",
                        principalColumn: "ID_PASO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PASOS_PLANTILLAS_DATOS_DETALLE_PLANTILLAS_CAMPOS_DETALLE_PLANTILLA_CAMPO",
                        column: x => x.PLANTILLA_CAMPO,
                        principalTable: "PLANTILLAS_CAMPOS_DETALLE",
                        principalColumn: "ID_PLANTILLA_CAMPO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_PLANTILLAS_DATOS_DETALLE_PASO",
                table: "PASOS_PLANTILLAS_DATOS_DETALLE",
                column: "PASO");

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_PLANTILLAS_DATOS_DETALLE_PLANTILLA_CAMPO",
                table: "PASOS_PLANTILLAS_DATOS_DETALLE",
                column: "PLANTILLA_CAMPO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PASOS_PLANTILLAS_DATOS_DETALLE");
        }
    }
}
