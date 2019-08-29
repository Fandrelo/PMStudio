using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Migrations
{
    public partial class RelationshipIdentityEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "PASOS_USUARIOS_DETALLE",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_USUARIOS_DETALLE_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "PASOS_USUARIOS_DETALLE",
                column: "ASPNETUSER");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "ASPNETUSER");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS",
                column: "ASPNETUSER");

            migrationBuilder.AddForeignKey(
                name: "FK_INSTANCIAS_PLANTILLAS_AspNetUsers_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS",
                column: "ASPNETUSER",
                principalSchema: "C##PMSTUDIO",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_AspNetUsers_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "ASPNETUSER",
                principalSchema: "C##PMSTUDIO",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PASOS_USUARIOS_DETALLE_AspNetUsers_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "PASOS_USUARIOS_DETALLE",
                column: "ASPNETUSER",
                principalSchema: "C##PMSTUDIO",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INSTANCIAS_PLANTILLAS_AspNetUsers_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS");

            migrationBuilder.DropForeignKey(
                name: "FK_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_AspNetUsers_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE");

            migrationBuilder.DropForeignKey(
                name: "FK_PASOS_USUARIOS_DETALLE_AspNetUsers_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "PASOS_USUARIOS_DETALLE");

            migrationBuilder.DropIndex(
                name: "IX_PASOS_USUARIOS_DETALLE_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "PASOS_USUARIOS_DETALLE");

            migrationBuilder.DropIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE");

            migrationBuilder.DropIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS");

            migrationBuilder.DropColumn(
                name: "ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "PASOS_USUARIOS_DETALLE");

            migrationBuilder.DropColumn(
                name: "ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE");

            migrationBuilder.DropColumn(
                name: "ASPNETUSER",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS");
        }
    }
}
