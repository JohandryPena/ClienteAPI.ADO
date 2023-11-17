﻿// <auto-generated />
using System;
using Client.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Client.API.Migrations
{
    [DbContext(typeof(ClienteDbContext))]
    [Migration("20231116233703_ClienteMigracion")]
    partial class ClienteMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Client.Domain.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ImagenBase64")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Client.Domain.Cliente", b =>
                {
                    b.OwnsOne("Client.Domain.Persona", "Persona", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .HasColumnType("int");

                            b1.Property<string>("Direccion")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Edad")
                                .HasColumnType("int");

                            b1.Property<string>("Genero")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Identificacion")
                                .HasColumnType("int");

                            b1.Property<string>("Nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Telefono")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("TipoIdentificacion")
                                .HasColumnType("int");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("Persona");
                });
#pragma warning restore 612, 618
        }
    }
}
