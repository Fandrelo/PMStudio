using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Migrations
{
    public partial class UpdatedStatusOnInstanceNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ESTADO",
                table: "INSTANCIAS_PLANTILLAS",
                type: "VARCHAR2(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ESTADO",
                table: "INSTANCIAS_PLANTILLAS",
                type: "CHAR(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(50)",
                oldNullable: true);
        }
    }
}
