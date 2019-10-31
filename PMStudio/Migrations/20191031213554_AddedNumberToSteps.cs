using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Migrations
{
    public partial class AddedNumberToSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NUMERO",
                table: "PASOS_INSTANCIAS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NUMERO",
                table: "PASOS",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NUMERO",
                table: "PASOS_INSTANCIAS");

            migrationBuilder.DropColumn(
                name: "NUMERO",
                table: "PASOS");
        }
    }
}
