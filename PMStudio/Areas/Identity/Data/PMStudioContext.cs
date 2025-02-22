﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMStudio.Areas.Identity.Data;
using PMStudio.Models.Entities;

namespace PMStudio.Models
{
    public class PMStudioContext : IdentityDbContext<PMStudioUser>
    {
        public PMStudioContext(DbContextOptions<PMStudioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acciones> Acciones { get; set; }
        public virtual DbSet<DatoTipo> DatoTipo { get; set; }
        public virtual DbSet<InstanciasPlantillas> InstanciasPlantillas { get; set; }
        public virtual DbSet<InstanciasPlantillasDatosDetalle> InstanciasPlantillasDatosDetalle { get; set; }
        public virtual DbSet<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
        public virtual DbSet<Pasos> Pasos { get; set; }
        public virtual DbSet<PasosInstancias> PasosInstancias { get; set; }
        public virtual DbSet<PasosInstanciasDatosDetalle> PasosInstanciasDatosDetalle { get; set; }
        public virtual DbSet<PasosPlantillasCamposDetalle> PasosPlantillasCamposDetalle { get; set; }
        public virtual DbSet<PasosUsuariosDetalle> PasosUsuariosDetalle { get; set; }
        public virtual DbSet<Plantillas> Plantillas { get; set; }
        public virtual DbSet<PlantillasCamposDetalle> PlantillasCamposDetalle { get; set; }
        public virtual DbSet<PlantillasPasosDetalle> PlantillasPasosDetalle { get; set; }
        public virtual DbSet<PlantillasPasosUsuariosDetalle> PlantillasPasosUsuariosDetalle { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //builder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
            //    .HasAnnotation("Relational:DefaultSchema", "C##PMSTUDIO");

            builder.Entity<Acciones>(entity =>
            {
                entity.HasKey(e => e.IdAccion);

                entity.ToTable("ACCIONES");

                entity.Property(e => e.IdAccion)
                    .HasColumnName("ID_ACCION")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasColumnType("VARCHAR2(30)");

                entity.HasData(
                    new Acciones { IdAccion = 1, Nombre = "En Espera" },
                    new Acciones { IdAccion = 2, Nombre = "Iniciado" },
                    new Acciones { IdAccion = 3, Nombre = "Finalizado" },
                    new Acciones { IdAccion = 4, Nombre = "Rechazado" }
                );
            });

            builder.Entity<DatoTipo>(entity =>
            {
                entity.HasKey(e => e.IdDatoTipo);

                entity.ToTable("DATO_TIPO");

                entity.Property(e => e.IdDatoTipo)
                    .HasColumnName("ID_DATO_TIPO")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasColumnType("VARCHAR2(50)");

                entity.HasData(
                    new DatoTipo { IdDatoTipo = 1, Nombre = "Texto" },
                    new DatoTipo { IdDatoTipo = 2, Nombre = "Fecha" },
                    new DatoTipo { IdDatoTipo = 3, Nombre = "Entero" },
                    new DatoTipo { IdDatoTipo = 4, Nombre = "Decimal" }
                );
            });

            builder.Entity<InstanciasPlantillas>(entity =>
            {
                entity.HasKey(e => e.IdInstanciaPlantilla);

                entity.ToTable("INSTANCIAS_PLANTILLAS");

                entity.Property(e => e.IdInstanciaPlantilla)
                    .HasColumnName("ID_INSTANCIA_PLANTILLA")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasColumnType("VARCHAR2(100)");

                entity.Property(e => e.Estado)
                    .IsRequired(false)
                    .HasColumnName("ESTADO")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.Iniciada)
                    .IsRequired()
                    .HasColumnName("INICIADA")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.AspNetUser)
                    .IsRequired()
                    .HasColumnName("ASPNETUSER");

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA");

                entity.HasOne(d => d.AspNetUserNavigation)
                    .WithMany(p => p.InstanciasPlantillas)
                    .HasForeignKey(d => d.AspNetUser)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            builder.Entity<InstanciasPlantillasDatosDetalle>(entity =>
            {
                entity.HasKey(e => e.IdInstanciaPlantillaDato);

                entity.ToTable("INSTANCIAS_PLANTILLAS_DATOS_DETALLE");

                entity.Property(e => e.IdInstanciaPlantillaDato)
                    .HasColumnName("ID_INSTANCIA_PLANTILLA_DATO")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdDatoTipo)
                    .HasColumnName("ID_DATO_TIPO");

                entity.Property(e => e.DatoTexto)
                    .IsRequired(false)
                    .HasColumnName("DATO_TEXTO")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.DatoNumerico)
                    .HasColumnName("DATO_NUMERICO");

                entity.Property(e => e.DatoDecimal)
                    .HasColumnName("DATO_DECIMAL");

                entity.Property(e => e.DatoFecha)
                    .HasColumnName("DATO_FECHA");

                entity.Property(e => e.Instanciaplantilla)
                    .HasColumnName("INSTANCIAPLANTILLA");

                entity.Property(e => e.NombreCampo)
                    .IsRequired()
                    .HasColumnName("NOMBRE_CAMPO")
                    .HasColumnType("VARCHAR2(50)");

                entity.HasOne(d => d.InstanciaplantillaNavigation)
                    .WithMany(p => p.InstanciasPlantillasDatosDetalle)
                    .HasForeignKey(d => d.Instanciaplantilla);

                entity.HasOne(d => d.IdDatoTipoNavigation)
                    .WithMany(p => p.InstanciasPlantillasDatosDetalle)
                    .HasForeignKey(d => d.IdDatoTipo);
            });

            builder.Entity<InstanciasPlantillasPasosDetalle>(entity =>
            {
                entity.HasKey(e => e.IdPlantillaPasoDetalle);

                entity.ToTable("INSTANCIAS_PLANTILLAS_PASOS_DETALLE");

                entity.Property(e => e.IdPlantillaPasoDetalle)
                    .HasColumnName("ID_PLANTILLA_PASO_DETALLE")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Estado)
                    .HasColumnName("ESTADO");

                entity.Property(e => e.InstanciaPlantilla)
                    .HasColumnName("INSTANCIA_PLANTILLA");

                entity.Property(e => e.Paso)
                    .HasColumnName("PASO");

                entity.Property(e => e.AspNetUser)
                    .IsRequired(false)
                    .HasColumnName("ASPNETUSER");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.InstanciasPlantillasPasosDetalle)
                    .HasForeignKey(d => d.Estado);

                entity.HasOne(d => d.InstanciaPlantillaNavigation)
                    .WithMany(p => p.InstanciasPlantillasPasosDetalle)
                    .HasForeignKey(d => d.InstanciaPlantilla);

                entity.HasOne(d => d.PasoNavigation)
                    .WithMany(p => p.InstanciasPlantillasPasosDetalle)
                    .HasForeignKey(d => d.Paso)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.AspNetUserNavigation)
                    .WithMany(p => p.InstanciasPlantillasPasosDetalle)
                    .HasForeignKey(d => d.AspNetUser);
            });

            builder.Entity<Pasos>(entity =>
            {
                entity.HasKey(e => e.IdPaso);

                entity.ToTable("PASOS");

                entity.Property(e => e.IdPaso)
                    .HasColumnName("ID_PASO")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasColumnType("VARCHAR2(100)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.FechaInicio)
                    .IsRequired(false)
                    .HasColumnName("FECHA_INICIO");

                entity.Property(e => e.FechaFin)
                    .IsRequired(false)
                    .HasColumnName("FECHA_FIN");

                entity.Property(e => e.Numero)
                    .IsRequired(false)
                    .HasColumnName("NUMERO");
            });

            builder.Entity<PasosInstancias>(entity =>
            {
                entity.HasKey(e => e.IdPasoinstancia);

                entity.ToTable("PASOS_INSTANCIAS");

                entity.Property(e => e.IdPasoinstancia)
                    .HasColumnName("ID_PASOINSTANCIA")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasColumnType("VARCHAR2(100)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.FechaInicio)
                    .IsRequired(false)
                    .HasColumnName("FECHA_INICIO");

                entity.Property(e => e.FechaFin)
                    .IsRequired(false)
                    .HasColumnName("FECHA_FIN");

                entity.Property(e => e.Numero)
                    .HasColumnName("NUMERO");
            });

            builder.Entity<PasosInstanciasDatosDetalle>(entity =>
            {
                entity.HasKey(e => e.IdPasosInstanciasDatos);

                entity.ToTable("PASOS_INSTANCIAS_DATOS_DETALLE");

                entity.Property(e => e.IdPasosInstanciasDatos)
                    .HasColumnName("ID_PASOS_INSTANCIAS_DATOS")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InstanciaPlantillaDato)
                    .HasColumnName("INSTANCIA_PLANTILLA_DATO");

                entity.Property(e => e.Paso)
                    .HasColumnName("PASO");

                entity.Property(e => e.SoloLectura)
                    //.IsRequired(false)
                    .HasColumnName("SOLO_LECTURA");

                entity.HasOne(d => d.InstanciaPlantillaDatoNavigation)
                    .WithMany(p => p.PasosInstanciasDatosDetalle)
                    .HasForeignKey(d => d.InstanciaPlantillaDato);

                entity.HasOne(d => d.PasoNavigation)
                    .WithMany(p => p.PasosInstanciasDatosDetalle)
                    .HasForeignKey(d => d.Paso)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            builder.Entity<PasosPlantillasCamposDetalle>(entity =>
            {
                entity.HasKey(e => e.IdPasosPlantillasDatos);

                entity.ToTable("PASOS_PLANTILLAS_DATOS_DETALLE");

                entity.Property(e => e.IdPasosPlantillasDatos)
                    .HasColumnName("ID_PASOS_INSTANCIAS_DATOS")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PlantillaCampo)
                    .HasColumnName("PLANTILLA_CAMPO");

                entity.Property(e => e.Paso)
                    .HasColumnName("PASO");

                entity.Property(e => e.SoloLectura)
                    //.IsRequired(false)
                    .HasColumnName("SOLO_LECTURA");

                entity.HasOne(d => d.PlantillaCampoNavigation)
                    .WithMany(p => p.PasosPlantillasCamposDetalle)
                    .HasForeignKey(d => d.PlantillaCampo);

                entity.HasOne(d => d.PasoNavigation)
                    .WithMany(p => p.PasosPlantillasCamposDetalle)
                    .HasForeignKey(d => d.Paso)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            builder.Entity<PasosUsuariosDetalle>(entity =>
            {
                entity.HasKey(e => e.IdPasosUsuarios);

                entity.ToTable("PASOS_USUARIOS_DETALLE");

                entity.Property(e => e.IdPasosUsuarios)
                    .HasColumnName("ID_PASOS_USUARIOS")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PlantillaPasoDetalle)
                    .HasColumnName("PLANTILLA_PASO_DETALLE");

                entity.Property(e => e.AspNetUser)
                    .IsRequired()
                    .HasColumnName("ASPNETUSER");

                entity.HasOne(d => d.PlantillaPasoDetalleNavigation)
                    .WithMany(p => p.PasosUsuariosDetalle)
                    .HasForeignKey(d => d.PlantillaPasoDetalle);

                entity.HasOne(d => d.AspNetUserNavigation)
                    .WithMany(p => p.PasosUsuariosDetalle)
                    .HasForeignKey(d => d.AspNetUser)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            builder.Entity<Plantillas>(entity =>
            {
                entity.HasKey(e => e.IdPlantilla);

                entity.ToTable("PLANTILLAS");

                entity.Property(e => e.IdPlantilla)
                    .HasColumnName("ID_PLANTILLA")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasColumnType("VARCHAR2(100)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasColumnType("VARCHAR2(50)");
            });

            builder.Entity<PlantillasCamposDetalle>(entity =>
            {
                entity.HasKey(e => e.IdPlantillaCampo);

                entity.ToTable("PLANTILLAS_CAMPOS_DETALLE");

                entity.Property(e => e.IdPlantillaCampo)
                    .HasColumnName("ID_PLANTILLA_CAMPO")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdDatoTipo)
                    .HasColumnName("ID_DATO_TIPO");

                entity.Property(e => e.Plantilla)
                    .HasColumnName("PLANTILLA");

                entity.Property(e => e.NombreCampo)
                    .IsRequired()
                    .HasColumnName("NOMBRE_CAMPO")
                    .HasColumnType("VARCHAR2(50)");

                entity.HasOne(d => d.PlantillaNavigation)
                    .WithMany(p => p.PlantillasCamposDetalle)
                    .HasForeignKey(d => d.Plantilla);

                entity.HasOne(d => d.IdDatoTipoNavigation)
                    .WithMany(p => p.PlantillasCamposDetalle)
                    .HasForeignKey(d => d.IdDatoTipo);
            });

            builder.Entity<PlantillasPasosDetalle>(entity =>
            {
                entity.HasKey(e => e.IdPlantillaPaso);

                entity.ToTable("PLANTILLAS_PASOS_DETALLE");

                entity.Property(e => e.IdPlantillaPaso)
                    .HasColumnName("ID_PLANTILLA_PASO")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Plantilla)
                    .HasColumnName("PLANTILLA");

                entity.Property(e => e.Paso)
                    .HasColumnName("PASO");

                entity.HasOne(d => d.PasoNavigation)
                    .WithMany(p => p.PlantillasPasosDetalle)
                    .HasForeignKey(d => d.Paso)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PlantillaNavigation)
                    .WithMany(p => p.PlantillasPasosDetalle)
                    .HasForeignKey(d => d.Plantilla);
            });

            builder.Entity<PlantillasPasosUsuariosDetalle>(entity =>
            {
                entity.HasKey(e => e.IdPlantillaPasosUsuarios);

                entity.ToTable("PLANTILLAS_PASOS_USUARIOS_DETALLE");

                entity.Property(e => e.IdPlantillaPasosUsuarios)
                    .HasColumnName("ID_PLANTILLAS_PASOS_USUARIOS")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PlantillaPasoDetalle)
                    .HasColumnName("PLANTILLA_PASO_DETALLE");

                entity.Property(e => e.AspNetUser)
                    .IsRequired()
                    .HasColumnName("ASPNETUSER");

                entity.HasOne(d => d.PlantillaPasoDetalleNavigation)
                    .WithMany(p => p.PlantillasPasosUsuariosDetalle)
                    .HasForeignKey(d => d.PlantillaPasoDetalle);

                entity.HasOne(d => d.AspNetUserNavigation)
                    .WithMany(p => p.PlantillasPasosUsuariosDetalle)
                    .HasForeignKey(d => d.AspNetUser)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            builder.HasSequence("ISEQ$$_73724");

            builder.HasSequence("ISEQ$$_73727");

            builder.HasSequence("ISEQ$$_73730");

            builder.HasSequence("ISEQ$$_73733");

            builder.HasSequence("ISEQ$$_73736");

            builder.HasSequence("ISEQ$$_73739");

            builder.HasSequence("ISEQ$$_73746");

            builder.HasSequence("ISEQ$$_73749");

            builder.HasSequence("ISEQ$$_73752");

            builder.HasSequence("ISEQ$$_73755");

            builder.HasSequence("ISEQ$$_73758");
        }
    }
}
