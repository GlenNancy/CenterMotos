﻿// <auto-generated />
using System;
using CenterMotosApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CenterMotosApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231203024100_CriacaoDeServices")]
    partial class CriacaoDeServices
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CenterMotosApi.Models.Carrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Carrinho");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClienteId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClienteId = 2
                        });
                });

            modelBuilder.Entity("CenterMotosApi.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("CPF");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.ToTable("Cliente");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "12345678910",
                            Nome = "Mauricio",
                            Senha = "123456"
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "12345678911",
                            Nome = "Antonio",
                            Senha = "123456"
                        });
                });

            modelBuilder.Entity("CenterMotosApi.Models.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoComentario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nome_Produto")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Comentario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClienteId = 1,
                            DescricaoComentario = "Retrovisor excelente, bonito e barato",
                            Nome = "aleatorio",
                            Nome_Produto = "nada",
                            ProdutoId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClienteId = 2,
                            DescricaoComentario = "Retrovisor ficou pequeno na minha cb1000, mas fora isso é muito bom",
                            Nome = "aleatorio",
                            Nome_Produto = "nada",
                            ProdutoId = 1
                        });
                });

            modelBuilder.Entity("CenterMotosApi.Models.ItemCarrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItemCarrinho");
                });

            modelBuilder.Entity("CenterMotosApi.Models.Mecanico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("CPF");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Mecanico");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "12345678912",
                            Nome = "Thiago",
                            Senha = "123456"
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "12345678913",
                            Nome = "Birobiro",
                            Senha = "123456"
                        });
                });

            modelBuilder.Entity("CenterMotosApi.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Descricao_Produto");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Foto_Produto");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Nome_Produto");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Retrovisor Titan 150 / 160 2014- Esquerdo MOD Original (GVS) Cada - 4001",
                            Nome = "Retrovisor",
                            Preco = 19.00m
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Capacete PRO TORK V-PRO JET 3 Articulado",
                            Nome = "Capacete",
                            Preco = 208.99m
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Bateria Pioneiro YTX7LBS (MBR7-BS) Selada Falcon / Twister / Tornado / Fazer 250 / Lander / TITAN150",
                            Nome = "Bateria",
                            Preco = 162.75m
                        });
                });

            modelBuilder.Entity("CenterMotosApi.Models.Carrinho", b =>
                {
                    b.HasOne("CenterMotosApi.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CenterMotosApi.Models.Cliente", b =>
                {
                    b.HasOne("CenterMotosApi.Models.Carrinho", "Carrinho")
                        .WithMany()
                        .HasForeignKey("CarrinhoId");

                    b.Navigation("Carrinho");
                });

            modelBuilder.Entity("CenterMotosApi.Models.Comentario", b =>
                {
                    b.HasOne("CenterMotosApi.Models.Cliente", null)
                        .WithMany("Comentarios")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CenterMotosApi.Models.Produto", null)
                        .WithMany("Comentarios")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CenterMotosApi.Models.ItemCarrinho", b =>
                {
                    b.HasOne("CenterMotosApi.Models.Carrinho", null)
                        .WithMany("ItensCarrinho")
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CenterMotosApi.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CenterMotosApi.Models.Carrinho", b =>
                {
                    b.Navigation("ItensCarrinho");
                });

            modelBuilder.Entity("CenterMotosApi.Models.Cliente", b =>
                {
                    b.Navigation("Comentarios");
                });

            modelBuilder.Entity("CenterMotosApi.Models.Produto", b =>
                {
                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}
