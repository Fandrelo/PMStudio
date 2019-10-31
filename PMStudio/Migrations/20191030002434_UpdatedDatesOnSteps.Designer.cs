﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using PMStudio.Models;

namespace PMStudio.Migrations
{
    [DbContext(typeof(PMStudioContext))]
    [Migration("20191030002434_UpdatedDatesOnSteps")]
    partial class UpdatedDatesOnSteps
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.ISEQ$$_73724", "'ISEQ$$_73724', '', '1', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ISEQ$$_73727", "'ISEQ$$_73727', '', '1', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ISEQ$$_73730", "'ISEQ$$_73730', '', '1', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ISEQ$$_73733", "'ISEQ$$_73733', '', '1', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ISEQ$$_73736", "'ISEQ$$_73736', '', '1', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ISEQ$$_73739", "'ISEQ$$_73739', '', '1', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ISEQ$$_73746", "'ISEQ$$_73746', '', '1', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ISEQ$$_73749", "'ISEQ$$_73749', '', '1', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ISEQ$$_73752", "'ISEQ$$_73752', '', '1', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ISEQ$$_73755", "'ISEQ$$_73755', '', '1', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ISEQ$$_73758", "'ISEQ$$_73758', '', '1', '1', '', '', 'Int64', 'False'");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PMStudio.Areas.Identity.Data.PMStudioUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.Acciones", b =>
                {
                    b.Property<int>("IdAccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_ACCION");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("NOMBRE")
                        .HasColumnType("VARCHAR2(30)");

                    b.HasKey("IdAccion");

                    b.ToTable("ACCIONES");

                    b.HasData(
                        new
                        {
                            IdAccion = 1,
                            Nombre = "En Espera"
                        },
                        new
                        {
                            IdAccion = 2,
                            Nombre = "Iniciado"
                        },
                        new
                        {
                            IdAccion = 3,
                            Nombre = "Finalizado"
                        });
                });

            modelBuilder.Entity("PMStudio.Models.Entities.DatoTipo", b =>
                {
                    b.Property<int>("IdDatoTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_DATO_TIPO");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("NOMBRE")
                        .HasColumnType("VARCHAR2(50)");

                    b.HasKey("IdDatoTipo");

                    b.ToTable("DATO_TIPO");

                    b.HasData(
                        new
                        {
                            IdDatoTipo = 1,
                            Nombre = "Texto"
                        },
                        new
                        {
                            IdDatoTipo = 2,
                            Nombre = "Fecha"
                        },
                        new
                        {
                            IdDatoTipo = 3,
                            Nombre = "Entero"
                        },
                        new
                        {
                            IdDatoTipo = 4,
                            Nombre = "Decimal"
                        });
                });

            modelBuilder.Entity("PMStudio.Models.Entities.InstanciasPlantillas", b =>
                {
                    b.Property<int>("IdInstanciaPlantilla")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_INSTANCIA_PLANTILLA");

                    b.Property<string>("AspNetUser")
                        .IsRequired()
                        .HasColumnName("ASPNETUSER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnName("DESCRIPCION")
                        .HasColumnType("VARCHAR2(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnName("ESTADO")
                        .HasColumnType("CHAR(1)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnName("FECHA");

                    b.Property<string>("Iniciada")
                        .IsRequired()
                        .HasColumnName("INICIADA")
                        .HasColumnType("CHAR(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("NOMBRE")
                        .HasColumnType("VARCHAR2(50)");

                    b.HasKey("IdInstanciaPlantilla");

                    b.HasIndex("AspNetUser");

                    b.ToTable("INSTANCIAS_PLANTILLAS");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.InstanciasPlantillasDatosDetalle", b =>
                {
                    b.Property<int>("IdInstanciaPlantillaDato")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_INSTANCIA_PLANTILLA_DATO");

                    b.Property<decimal?>("DatoDecimal")
                        .HasColumnName("DATO_DECIMAL");

                    b.Property<DateTime?>("DatoFecha")
                        .HasColumnName("DATO_FECHA");

                    b.Property<long?>("DatoNumerico")
                        .HasColumnName("DATO_NUMERICO");

                    b.Property<string>("DatoTexto")
                        .HasColumnName("DATO_TEXTO")
                        .HasColumnType("VARCHAR2(50)");

                    b.Property<int>("IdDatoTipo")
                        .HasColumnName("ID_DATO_TIPO");

                    b.Property<int>("Instanciaplantilla")
                        .HasColumnName("INSTANCIAPLANTILLA");

                    b.Property<string>("NombreCampo")
                        .IsRequired()
                        .HasColumnName("NOMBRE_CAMPO")
                        .HasColumnType("VARCHAR2(50)");

                    b.HasKey("IdInstanciaPlantillaDato");

                    b.HasIndex("IdDatoTipo");

                    b.HasIndex("Instanciaplantilla");

                    b.ToTable("INSTANCIAS_PLANTILLAS_DATOS_DETALLE");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.InstanciasPlantillasPasosDetalle", b =>
                {
                    b.Property<int>("IdPlantillaPasoDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PLANTILLA_PASO_DETALLE");

                    b.Property<string>("AspNetUser")
                        .HasColumnName("ASPNETUSER");

                    b.Property<int?>("Estado")
                        .HasColumnName("ESTADO");

                    b.Property<int>("InstanciaPlantilla")
                        .HasColumnName("INSTANCIA_PLANTILLA");

                    b.Property<int>("Paso")
                        .HasColumnName("PASO");

                    b.HasKey("IdPlantillaPasoDetalle");

                    b.HasIndex("AspNetUser");

                    b.HasIndex("Estado");

                    b.HasIndex("InstanciaPlantilla");

                    b.HasIndex("Paso");

                    b.ToTable("INSTANCIAS_PLANTILLAS_PASOS_DETALLE");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.Pasos", b =>
                {
                    b.Property<int>("IdPaso")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PASO");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnName("DESCRIPCION")
                        .HasColumnType("VARCHAR2(100)");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnName("FECHA_FIN");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnName("FECHA_INICIO");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("NOMBRE")
                        .HasColumnType("VARCHAR2(50)");

                    b.HasKey("IdPaso");

                    b.ToTable("PASOS");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.PasosInstancias", b =>
                {
                    b.Property<int>("IdPasoinstancia")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PASOINSTANCIA");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnName("DESCRIPCION")
                        .HasColumnType("VARCHAR2(100)");

                    b.Property<DateTime?>("FechaFin");

                    b.Property<DateTime?>("FechaInicio");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("NOMBRE")
                        .HasColumnType("VARCHAR2(50)");

                    b.HasKey("IdPasoinstancia");

                    b.ToTable("PASOS_INSTANCIAS");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.PasosInstanciasDatosDetalle", b =>
                {
                    b.Property<int>("IdPasosInstanciasDatos")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PASOS_INSTANCIAS_DATOS");

                    b.Property<int>("InstanciaPlantillaDato")
                        .HasColumnName("INSTANCIA_PLANTILLA_DATO");

                    b.Property<int>("Paso")
                        .HasColumnName("PASO");

                    b.Property<string>("SoloLectura")
                        .IsRequired()
                        .HasColumnName("SOLO_LECTURA")
                        .HasColumnType("CHAR(1)");

                    b.HasKey("IdPasosInstanciasDatos");

                    b.HasIndex("InstanciaPlantillaDato");

                    b.HasIndex("Paso");

                    b.ToTable("PASOS_INSTANCIAS_DATOS_DETALLE");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.PasosUsuariosDetalle", b =>
                {
                    b.Property<int>("IdPasosUsuarios")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PASOS_USUARIOS");

                    b.Property<string>("AspNetUser")
                        .IsRequired()
                        .HasColumnName("ASPNETUSER");

                    b.Property<int>("PlantillaPasoDetalle")
                        .HasColumnName("PLANTILLA_PASO_DETALLE");

                    b.HasKey("IdPasosUsuarios");

                    b.HasIndex("AspNetUser");

                    b.HasIndex("PlantillaPasoDetalle");

                    b.ToTable("PASOS_USUARIOS_DETALLE");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.Plantillas", b =>
                {
                    b.Property<int>("IdPlantilla")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PLANTILLA");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnName("DESCRIPCION")
                        .HasColumnType("VARCHAR2(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("NOMBRE")
                        .HasColumnType("VARCHAR2(50)");

                    b.HasKey("IdPlantilla");

                    b.ToTable("PLANTILLAS");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.PlantillasCamposDetalle", b =>
                {
                    b.Property<int>("IdPlantillaCampo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PLANTILLA_CAMPO");

                    b.Property<int>("IdDatoTipo")
                        .HasColumnName("ID_DATO_TIPO");

                    b.Property<string>("NombreCampo")
                        .IsRequired()
                        .HasColumnName("NOMBRE_CAMPO")
                        .HasColumnType("VARCHAR2(50)");

                    b.Property<int>("Plantilla")
                        .HasColumnName("PLANTILLA");

                    b.HasKey("IdPlantillaCampo");

                    b.HasIndex("IdDatoTipo");

                    b.HasIndex("Plantilla");

                    b.ToTable("PLANTILLAS_CAMPOS_DETALLE");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.PlantillasPasosDetalle", b =>
                {
                    b.Property<int>("IdPlantillaPaso")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PLANTILLA_PASO");

                    b.Property<int>("Paso")
                        .HasColumnName("PASO");

                    b.Property<int>("Plantilla")
                        .HasColumnName("PLANTILLA");

                    b.HasKey("IdPlantillaPaso");

                    b.HasIndex("Paso");

                    b.HasIndex("Plantilla");

                    b.ToTable("PLANTILLAS_PASOS_DETALLE");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.PlantillasPasosUsuariosDetalle", b =>
                {
                    b.Property<int>("IdPlantillaPasosUsuarios")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PLANTILLAS_PASOS_USUARIOS");

                    b.Property<string>("AspNetUser")
                        .IsRequired()
                        .HasColumnName("ASPNETUSER");

                    b.Property<int>("PlantillaPasoDetalle")
                        .HasColumnName("PLANTILLA_PASO_DETALLE");

                    b.HasKey("IdPlantillaPasosUsuarios");

                    b.HasIndex("AspNetUser");

                    b.HasIndex("PlantillaPasoDetalle");

                    b.ToTable("PLANTILLAS_PASOS_USUARIOS_DETALLE");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PMStudio.Areas.Identity.Data.PMStudioUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PMStudio.Areas.Identity.Data.PMStudioUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMStudio.Areas.Identity.Data.PMStudioUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PMStudio.Areas.Identity.Data.PMStudioUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMStudio.Models.Entities.InstanciasPlantillas", b =>
                {
                    b.HasOne("PMStudio.Areas.Identity.Data.PMStudioUser", "AspNetUserNavigation")
                        .WithMany("InstanciasPlantillas")
                        .HasForeignKey("AspNetUser");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.InstanciasPlantillasDatosDetalle", b =>
                {
                    b.HasOne("PMStudio.Models.Entities.DatoTipo", "IdDatoTipoNavigation")
                        .WithMany("InstanciasPlantillasDatosDetalle")
                        .HasForeignKey("IdDatoTipo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMStudio.Models.Entities.InstanciasPlantillas", "InstanciaplantillaNavigation")
                        .WithMany("InstanciasPlantillasDatosDetalle")
                        .HasForeignKey("Instanciaplantilla")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMStudio.Models.Entities.InstanciasPlantillasPasosDetalle", b =>
                {
                    b.HasOne("PMStudio.Areas.Identity.Data.PMStudioUser", "AspNetUserNavigation")
                        .WithMany("InstanciasPlantillasPasosDetalle")
                        .HasForeignKey("AspNetUser");

                    b.HasOne("PMStudio.Models.Entities.Acciones", "EstadoNavigation")
                        .WithMany("InstanciasPlantillasPasosDetalle")
                        .HasForeignKey("Estado");

                    b.HasOne("PMStudio.Models.Entities.InstanciasPlantillas", "InstanciaPlantillaNavigation")
                        .WithMany("InstanciasPlantillasPasosDetalle")
                        .HasForeignKey("InstanciaPlantilla")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMStudio.Models.Entities.PasosInstancias", "PasoNavigation")
                        .WithMany("InstanciasPlantillasPasosDetalle")
                        .HasForeignKey("Paso");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.PasosInstanciasDatosDetalle", b =>
                {
                    b.HasOne("PMStudio.Models.Entities.InstanciasPlantillasDatosDetalle", "InstanciaPlantillaDatoNavigation")
                        .WithMany("PasosInstanciasDatosDetalle")
                        .HasForeignKey("InstanciaPlantillaDato")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMStudio.Models.Entities.PasosInstancias", "PasoNavigation")
                        .WithMany("PasosInstanciasDatosDetalle")
                        .HasForeignKey("Paso");
                });

            modelBuilder.Entity("PMStudio.Models.Entities.PasosUsuariosDetalle", b =>
                {
                    b.HasOne("PMStudio.Areas.Identity.Data.PMStudioUser", "AspNetUserNavigation")
                        .WithMany("PasosUsuariosDetalle")
                        .HasForeignKey("AspNetUser");

                    b.HasOne("PMStudio.Models.Entities.InstanciasPlantillasPasosDetalle", "PlantillaPasoDetalleNavigation")
                        .WithMany("PasosUsuariosDetalle")
                        .HasForeignKey("PlantillaPasoDetalle")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMStudio.Models.Entities.PlantillasCamposDetalle", b =>
                {
                    b.HasOne("PMStudio.Models.Entities.DatoTipo", "IdDatoTipoNavigation")
                        .WithMany("PlantillasCamposDetalle")
                        .HasForeignKey("IdDatoTipo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMStudio.Models.Entities.Plantillas", "PlantillaNavigation")
                        .WithMany("PlantillasCamposDetalle")
                        .HasForeignKey("Plantilla")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMStudio.Models.Entities.PlantillasPasosDetalle", b =>
                {
                    b.HasOne("PMStudio.Models.Entities.Pasos", "PasoNavigation")
                        .WithMany("PlantillasPasosDetalle")
                        .HasForeignKey("Paso");

                    b.HasOne("PMStudio.Models.Entities.Plantillas", "PlantillaNavigation")
                        .WithMany("PlantillasPasosDetalle")
                        .HasForeignKey("Plantilla")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMStudio.Models.Entities.PlantillasPasosUsuariosDetalle", b =>
                {
                    b.HasOne("PMStudio.Areas.Identity.Data.PMStudioUser", "AspNetUserNavigation")
                        .WithMany("PlantillasPasosUsuariosDetalle")
                        .HasForeignKey("AspNetUser");

                    b.HasOne("PMStudio.Models.Entities.PlantillasPasosDetalle", "PlantillaPasoDetalleNavigation")
                        .WithMany("PlantillasPasosUsuariosDetalle")
                        .HasForeignKey("PlantillaPasoDetalle")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
