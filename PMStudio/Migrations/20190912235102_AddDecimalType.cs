using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Migrations
{
    public partial class AddDecimalType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DATO_DECIMAL",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DATO_TIPO",
                columns: new[] { "ID_DATO_TIPO", "NOMBRE" },
                values: new object[,]
                {
                    { 1, "Texto" },
                    { 2, "Fecha" },
                    { 3, "Entero" },
                    { 4, "Decimal" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DATO_TIPO",
                keyColumn: "ID_DATO_TIPO",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DATO_TIPO",
                keyColumn: "ID_DATO_TIPO",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DATO_TIPO",
                keyColumn: "ID_DATO_TIPO",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DATO_TIPO",
                keyColumn: "ID_DATO_TIPO",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "DATO_DECIMAL",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE");
        }
    }
}
