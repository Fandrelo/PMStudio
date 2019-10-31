using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Migrations
{
    public partial class AddedSeedDataToActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ACCIONES",
                columns: new[] { "ID_ACCION", "NOMBRE" },
                values: new object[] { 4, "Rechazado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ACCIONES",
                keyColumn: "ID_ACCION",
                keyValue: 4);
        }
    }
}
