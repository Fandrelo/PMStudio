using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace PMStudio.Migrations
{
    public partial class AddedNewTypeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DATO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE");

            migrationBuilder.AddColumn<int>(
                name: "ID_DATO_TIPO",
                table: "PLANTILLAS_CAMPOS_DETALLE",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATO_FECHA",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DATO_NUMERICO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DATO_TEXTO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                type: "VARCHAR2(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_DATO_TIPO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DATO_TIPO",
                columns: table => new
                {
                    ID_DATO_TIPO = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DATO_TIPO", x => x.ID_DATO_TIPO);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLANTILLAS_CAMPOS_DETALLE_ID_DATO_TIPO",
                table: "PLANTILLAS_CAMPOS_DETALLE",
                column: "ID_DATO_TIPO");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_DATOS_DETALLE_ID_DATO_TIPO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                column: "ID_DATO_TIPO");

            migrationBuilder.AddForeignKey(
                name: "FK_INSTANCIAS_PLANTILLAS_DATOS_DETALLE_DATO_TIPO_ID_DATO_TIPO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                column: "ID_DATO_TIPO",
                principalTable: "DATO_TIPO",
                principalColumn: "ID_DATO_TIPO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PLANTILLAS_CAMPOS_DETALLE_DATO_TIPO_ID_DATO_TIPO",
                table: "PLANTILLAS_CAMPOS_DETALLE",
                column: "ID_DATO_TIPO",
                principalTable: "DATO_TIPO",
                principalColumn: "ID_DATO_TIPO",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INSTANCIAS_PLANTILLAS_DATOS_DETALLE_DATO_TIPO_ID_DATO_TIPO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE");

            migrationBuilder.DropForeignKey(
                name: "FK_PLANTILLAS_CAMPOS_DETALLE_DATO_TIPO_ID_DATO_TIPO",
                table: "PLANTILLAS_CAMPOS_DETALLE");

            migrationBuilder.DropTable(
                name: "DATO_TIPO");

            migrationBuilder.DropIndex(
                name: "IX_PLANTILLAS_CAMPOS_DETALLE_ID_DATO_TIPO",
                table: "PLANTILLAS_CAMPOS_DETALLE");

            migrationBuilder.DropIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_DATOS_DETALLE_ID_DATO_TIPO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE");

            migrationBuilder.DropColumn(
                name: "ID_DATO_TIPO",
                table: "PLANTILLAS_CAMPOS_DETALLE");

            migrationBuilder.DropColumn(
                name: "DATO_FECHA",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE");

            migrationBuilder.DropColumn(
                name: "DATO_NUMERICO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE");

            migrationBuilder.DropColumn(
                name: "DATO_TEXTO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE");

            migrationBuilder.DropColumn(
                name: "ID_DATO_TIPO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE");

            migrationBuilder.AddColumn<string>(
                name: "DATO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                type: "VARCHAR2(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
