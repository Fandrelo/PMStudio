using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace PMStudio.Migrations
{
    public partial class CreateEntitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "C##PMSTUDIO");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "C##PMSTUDIO");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "C##PMSTUDIO");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "C##PMSTUDIO");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "C##PMSTUDIO");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "C##PMSTUDIO");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "C##PMSTUDIO");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "C##PMSTUDIO");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73724",
                schema: "C##PMSTUDIO");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73727",
                schema: "C##PMSTUDIO");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73730",
                schema: "C##PMSTUDIO");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73733",
                schema: "C##PMSTUDIO");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73736",
                schema: "C##PMSTUDIO");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73739",
                schema: "C##PMSTUDIO");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73746",
                schema: "C##PMSTUDIO");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73749",
                schema: "C##PMSTUDIO");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73752",
                schema: "C##PMSTUDIO");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73755",
                schema: "C##PMSTUDIO");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73758",
                schema: "C##PMSTUDIO");

            migrationBuilder.CreateTable(
                name: "ACCIONES",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_ACCION = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ACCIONES_PK", x => x.ID_ACCION);
                });

            migrationBuilder.CreateTable(
                name: "PASOS",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_PASO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PASOS_PK", x => x.ID_PASO);
                });

            migrationBuilder.CreateTable(
                name: "PASOS_INSTANCIAS",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_PASOINSTANCIA = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PASOS_INSTANCIAS_PK", x => x.ID_PASOINSTANCIA);
                });

            migrationBuilder.CreateTable(
                name: "PLANTILLAS",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_PLANTILLA = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PLANTILLAS_PK", x => x.ID_PLANTILLA);
                });

            migrationBuilder.CreateTable(
                name: "RANGOS",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_RANGO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    NIVEL = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RANGOS_PK", x => x.ID_RANGO);
                });

            migrationBuilder.CreateTable(
                name: "PLANTILLAS_CAMPOS_DETALLE",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_PLANTILLA_CAMPO = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    PLANTILLA = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    NOMBRE_CAMPO = table.Column<string>(type: "VARCHAR2(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PLANTILLAS_CAMPOS_DETALLE_PK", x => new { x.ID_PLANTILLA_CAMPO, x.PLANTILLA });
                    table.ForeignKey(
                        name: "PLANTILLAS_CAMPOS_DETALLE_FK1",
                        column: x => x.PLANTILLA,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "PLANTILLAS",
                        principalColumn: "ID_PLANTILLA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLANTILLAS_PASOS_DETALLE",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_PLANTILLA_PASO = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    PLANTILLA = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    PASO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PLANTILLAS_PASOS_DETALLE_PK", x => new { x.ID_PLANTILLA_PASO, x.PLANTILLA });
                    table.ForeignKey(
                        name: "PLANTILLAS_PASOS_DETALLE_FK2",
                        column: x => x.PASO,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "PASOS",
                        principalColumn: "ID_PASO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PLANTILLAS_PASOS_DETALLE_FK1",
                        column: x => x.PLANTILLA,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "PLANTILLAS",
                        principalColumn: "ID_PLANTILLA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRES = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    APELLIDOS = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    USUARIO_EMAIL = table.Column<string>(type: "VARCHAR2(30)", nullable: false),
                    RANGO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("USUARIOS_PK", x => x.ID_USUARIO);
                    table.ForeignKey(
                        name: "USUARIOS_FK1",
                        column: x => x.RANGO,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "RANGOS",
                        principalColumn: "ID_RANGO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSTANCIAS_PLANTILLAS",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_INSTANCIA_PLANTILLA = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    USUARIO = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    ESTADO = table.Column<string>(type: "CHAR(1)", nullable: false),
                    INICIADA = table.Column<string>(type: "CHAR(1)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("INSTANCIAS_PLANTILLAS_PK", x => x.ID_INSTANCIA_PLANTILLA);
                    table.ForeignKey(
                        name: "INSTANCIAS_PLANTILLAS_FK1",
                        column: x => x.USUARIO,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_INSTANCIA_PLANTILLA_DATO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    INSTANCIAPLANTILLA = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    NOMBRE_CAMPO = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    DATO = table.Column<string>(type: "VARCHAR2(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("INSTANCIAS_PLANTILLAS_DATOS_DETALLE_PK", x => x.ID_INSTANCIA_PLANTILLA_DATO);
                    table.ForeignKey(
                        name: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE_FK1",
                        column: x => x.INSTANCIAPLANTILLA,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "INSTANCIAS_PLANTILLAS",
                        principalColumn: "ID_INSTANCIA_PLANTILLA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_PLANTILLA_PASO_DETALLE = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    INSTANCIA_PLANTILLA = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    PASO = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    ESTADO = table.Column<decimal>(type: "NUMBER(38)", nullable: true),
                    USUARIO_ACCION = table.Column<decimal>(type: "NUMBER(38)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("INSTANCIAS_PLANTILLAS_PASOS_DETALLE_PK", x => x.ID_PLANTILLA_PASO_DETALLE);
                    table.ForeignKey(
                        name: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE_FK2",
                        column: x => x.ESTADO,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "ACCIONES",
                        principalColumn: "ID_ACCION",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE_FK3",
                        column: x => x.INSTANCIA_PLANTILLA,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "INSTANCIAS_PLANTILLAS",
                        principalColumn: "ID_INSTANCIA_PLANTILLA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE_FK1",
                        column: x => x.PASO,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "PASOS_INSTANCIAS",
                        principalColumn: "ID_PASOINSTANCIA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE_FK4",
                        column: x => x.USUARIO_ACCION,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PASOS_INSTANCIAS_DATOS_DETALLE",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_PASOS_INSTANCIAS_DATOS = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    INSTANCIA_PLANTILLA_DATO = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    PASO = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    SOLO_LECTURA = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PASOS_INSTANCIAS_DATOS_DETALLE_PK", x => x.ID_PASOS_INSTANCIAS_DATOS);
                    table.ForeignKey(
                        name: "PASOS_INSTANCIAS_DATOS_DETALLE_FK1",
                        column: x => x.INSTANCIA_PLANTILLA_DATO,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                        principalColumn: "ID_INSTANCIA_PLANTILLA_DATO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "PASOS_INSTANCIAS_DATOS_DETALLE_FK2",
                        column: x => x.PASO,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "PASOS_INSTANCIAS",
                        principalColumn: "ID_PASOINSTANCIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PASOS_USUARIOS_DETALLE",
                schema: "C##PMSTUDIO",
                columns: table => new
                {
                    ID_PASOS_USUARIOS = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    PLANTILLA_PASO_DETALLE = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    USUARIO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PASOS_USUARIOS_DETALLE_PK", x => x.ID_PASOS_USUARIOS);
                    table.ForeignKey(
                        name: "PASOS_USUARIOS_DETALLE_FK1",
                        column: x => x.PLANTILLA_PASO_DETALLE,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                        principalColumn: "ID_PLANTILLA_PASO_DETALLE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "PASOS_USUARIOS_DETALLE_FK2",
                        column: x => x.USUARIO,
                        principalSchema: "C##PMSTUDIO",
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ACCIONES_PK",
                schema: "C##PMSTUDIO",
                table: "ACCIONES",
                column: "ID_ACCION",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "INSTANCIAS_PLANTILLAS_PK",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS",
                column: "ID_INSTANCIA_PLANTILLA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_USUARIO",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS",
                column: "USUARIO");

            migrationBuilder.CreateIndex(
                name: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE_PK",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                column: "ID_INSTANCIA_PLANTILLA_DATO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_DATOS_DETALLE_INSTANCIAPLANTILLA",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                column: "INSTANCIAPLANTILLA");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_ESTADO",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "ESTADO");

            migrationBuilder.CreateIndex(
                name: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE_PK",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "ID_PLANTILLA_PASO_DETALLE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_INSTANCIA_PLANTILLA",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "INSTANCIA_PLANTILLA");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_PASO",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "PASO");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_USUARIO_ACCION",
                schema: "C##PMSTUDIO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "USUARIO_ACCION");

            migrationBuilder.CreateIndex(
                name: "PASOS_PK",
                schema: "C##PMSTUDIO",
                table: "PASOS",
                column: "ID_PASO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PASOS_INSTANCIAS_PK",
                schema: "C##PMSTUDIO",
                table: "PASOS_INSTANCIAS",
                column: "ID_PASOINSTANCIA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PASOS_INSTANCIAS_DATOS_DETALLE_PK",
                schema: "C##PMSTUDIO",
                table: "PASOS_INSTANCIAS_DATOS_DETALLE",
                column: "ID_PASOS_INSTANCIAS_DATOS",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_INSTANCIAS_DATOS_DETALLE_INSTANCIA_PLANTILLA_DATO",
                schema: "C##PMSTUDIO",
                table: "PASOS_INSTANCIAS_DATOS_DETALLE",
                column: "INSTANCIA_PLANTILLA_DATO");

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_INSTANCIAS_DATOS_DETALLE_PASO",
                schema: "C##PMSTUDIO",
                table: "PASOS_INSTANCIAS_DATOS_DETALLE",
                column: "PASO");

            migrationBuilder.CreateIndex(
                name: "PASOS_USUARIOS_DETALLE_PK",
                schema: "C##PMSTUDIO",
                table: "PASOS_USUARIOS_DETALLE",
                column: "ID_PASOS_USUARIOS",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_USUARIOS_DETALLE_PLANTILLA_PASO_DETALLE",
                schema: "C##PMSTUDIO",
                table: "PASOS_USUARIOS_DETALLE",
                column: "PLANTILLA_PASO_DETALLE");

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_USUARIOS_DETALLE_USUARIO",
                schema: "C##PMSTUDIO",
                table: "PASOS_USUARIOS_DETALLE",
                column: "USUARIO");

            migrationBuilder.CreateIndex(
                name: "PLANTILLAS_PK",
                schema: "C##PMSTUDIO",
                table: "PLANTILLAS",
                column: "ID_PLANTILLA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PLANTILLAS_CAMPOS_DETALLE_PLANTILLA",
                schema: "C##PMSTUDIO",
                table: "PLANTILLAS_CAMPOS_DETALLE",
                column: "PLANTILLA");

            migrationBuilder.CreateIndex(
                name: "PLANTILLAS_CAMPOS_DETALLE_PK",
                schema: "C##PMSTUDIO",
                table: "PLANTILLAS_CAMPOS_DETALLE",
                columns: new[] { "ID_PLANTILLA_CAMPO", "PLANTILLA" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PLANTILLAS_PASOS_DETALLE_PASO",
                schema: "C##PMSTUDIO",
                table: "PLANTILLAS_PASOS_DETALLE",
                column: "PASO");

            migrationBuilder.CreateIndex(
                name: "IX_PLANTILLAS_PASOS_DETALLE_PLANTILLA",
                schema: "C##PMSTUDIO",
                table: "PLANTILLAS_PASOS_DETALLE",
                column: "PLANTILLA");

            migrationBuilder.CreateIndex(
                name: "PLANTILLAS_PASOS_DETALLE_PK",
                schema: "C##PMSTUDIO",
                table: "PLANTILLAS_PASOS_DETALLE",
                columns: new[] { "ID_PLANTILLA_PASO", "PLANTILLA" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RANGOS_PK",
                schema: "C##PMSTUDIO",
                table: "RANGOS",
                column: "ID_RANGO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "USUARIOS_PK",
                schema: "C##PMSTUDIO",
                table: "USUARIOS",
                column: "ID_USUARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_RANGO",
                schema: "C##PMSTUDIO",
                table: "USUARIOS",
                column: "RANGO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PASOS_INSTANCIAS_DATOS_DETALLE",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "PASOS_USUARIOS_DETALLE",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "PLANTILLAS_CAMPOS_DETALLE",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "PLANTILLAS_PASOS_DETALLE",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "PASOS",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "PLANTILLAS",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "ACCIONES",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "INSTANCIAS_PLANTILLAS",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "PASOS_INSTANCIAS",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "USUARIOS",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropTable(
                name: "RANGOS",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73724",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73727",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73730",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73733",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73736",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73739",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73746",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73749",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73752",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73755",
                schema: "C##PMSTUDIO");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73758",
                schema: "C##PMSTUDIO");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "C##PMSTUDIO",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "C##PMSTUDIO",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "C##PMSTUDIO",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "C##PMSTUDIO",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "C##PMSTUDIO",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "C##PMSTUDIO",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "C##PMSTUDIO",
                newName: "AspNetRoleClaims");
        }
    }
}
