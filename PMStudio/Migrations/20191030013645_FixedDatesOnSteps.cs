using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Migrations
{
    public partial class FixedDatesOnSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "PASOS_INSTANCIAS",
                newName: "FECHA_INICIO");

            migrationBuilder.RenameColumn(
                name: "FechaFin",
                table: "PASOS_INSTANCIAS",
                newName: "FECHA_FIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FECHA_INICIO",
                table: "PASOS_INSTANCIAS",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "FECHA_FIN",
                table: "PASOS_INSTANCIAS",
                newName: "FechaFin");
        }
    }
}
