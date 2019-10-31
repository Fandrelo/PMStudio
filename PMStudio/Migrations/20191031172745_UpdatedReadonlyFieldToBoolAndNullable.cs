using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Migrations
{
    public partial class UpdatedReadonlyFieldToBoolAndNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "SOLO_LECTURA",
                table: "PASOS_PLANTILLAS_DATOS_DETALLE",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "SOLO_LECTURA",
                table: "PASOS_INSTANCIAS_DATOS_DETALLE",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SOLO_LECTURA",
                table: "PASOS_PLANTILLAS_DATOS_DETALLE",
                type: "CHAR(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SOLO_LECTURA",
                table: "PASOS_INSTANCIAS_DATOS_DETALLE",
                type: "CHAR(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
