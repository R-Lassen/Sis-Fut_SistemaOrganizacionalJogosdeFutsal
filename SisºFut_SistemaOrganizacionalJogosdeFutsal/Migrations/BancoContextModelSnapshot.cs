﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SisºFut_SistemaOrganizacionalJogosdeFutsal.Data;

namespace SisºFut_SistemaOrganizacionalJogosdeFutsal.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("SisºFut_SistemaOrganizacionalJogosdeFutsal.Models.AgendamentosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DS_Descricao")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DT_Agendamento")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DT_Atualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HR_Agendamento")
                        .HasColumnType("longtext");

                    b.Property<string>("Quadra")
                        .HasColumnType("longtext");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioSelecionado")
                        .HasColumnType("int");

                    b.Property<int>("id_Quadra")
                        .HasColumnType("int");

                    b.Property<int>("id_Time1")
                        .HasColumnType("int");

                    b.Property<int?>("id_Time2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("SisºFut_SistemaOrganizacionalJogosdeFutsal.Models.ContatoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("SisºFut_SistemaOrganizacionalJogosdeFutsal.Models.QuadrasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DS_Endereco")
                        .HasColumnType("longtext");

                    b.Property<string>("NM_Quadra")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Quadras");
                });

            modelBuilder.Entity("SisºFut_SistemaOrganizacionalJogosdeFutsal.Models.TimeXQuadrasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("id_Quadra")
                        .HasColumnType("int");

                    b.Property<int>("id_Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TimexQuadras");
                });

            modelBuilder.Entity("SisºFut_SistemaOrganizacionalJogosdeFutsal.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualização")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Foto")
                        .HasColumnType("longtext");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SisºFut_SistemaOrganizacionalJogosdeFutsal.Models.AgendamentosModel", b =>
                {
                    b.HasOne("SisºFut_SistemaOrganizacionalJogosdeFutsal.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
