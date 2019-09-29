using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Migrations
{
    public partial class SeededActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ACCIONES",
                columns: new[] { "ID_ACCION", "NOMBRE" },
                values: new object[] { 1, "En Espera" });

            migrationBuilder.InsertData(
                table: "ACCIONES",
                columns: new[] { "ID_ACCION", "NOMBRE" },
                values: new object[] { 2, "Iniciado" });

            migrationBuilder.InsertData(
                table: "ACCIONES",
                columns: new[] { "ID_ACCION", "NOMBRE" },
                values: new object[] { 3, "Finalizado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ACCIONES",
                keyColumn: "ID_ACCION",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ACCIONES",
                keyColumn: "ID_ACCION",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ACCIONES",
                keyColumn: "ID_ACCION",
                keyValue: 3);
        }
    }
}
