using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Migrations
{
    public partial class UpdatedDatesOnSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "PASOS_INSTANCIAS",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "PASOS_INSTANCIAS",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FECHA_INICIO",
                table: "PASOS",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FECHA_FIN",
                table: "PASOS",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "PASOS_INSTANCIAS");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "PASOS_INSTANCIAS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FECHA_INICIO",
                table: "PASOS",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FECHA_FIN",
                table: "PASOS",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
