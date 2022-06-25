﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CosasEntityFramework.Modelos
{
    public class GestionEmpresaXDB : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaCursada> MateriasCursadas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder opBuilder)
        {
            if (!opBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appconfig.json");
                var config = builder.Build();
                opBuilder.UseLazyLoadingProxies().UseSqlServer(config["ConnectionStrings:miConexion"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefono>( entidad =>
            {
                entidad.HasOne(t => t.estudiante).WithMany(est => est.telefonos)
                .HasForeignKey(t => t.codigoEst).HasConstraintName("FK_Telefono_Estudiante");
            });
            modelBuilder.Entity<MateriaCursada>(entidad =>
            {
                entidad.HasOne(mc => mc.estudiante).WithMany(est => est.materiasCursadas)
                .HasForeignKey(mc => mc.idEst).HasConstraintName("fk_materiacursada_estudiante");
            });
            modelBuilder.Entity<MateriaCursada>(entidad =>
            {
                entidad.HasOne(mc => mc.materia).WithMany(mat => mat.materiasCursadas)
                .HasForeignKey(mc => mc.idMat).HasConstraintName("fk_materiacursada_materia");
            });
        }
    }
}
