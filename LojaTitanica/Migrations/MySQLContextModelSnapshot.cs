﻿// <auto-generated />
using System;
using LojaTitanica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LojaTitanica.Migrations
{
    [DbContext(typeof(MySQLContext))]
    partial class MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("LojaTitanica.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LojaTitanica.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Vendaid")
                        .HasColumnType("int");

                    b.Property<int?>("produtoid")
                        .HasColumnType("int");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Vendaid");

                    b.HasIndex("produtoid");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("LojaTitanica.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("marca")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("preco")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("LojaTitanica.Models.Venda", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("clienteid")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<decimal>("valorTotal")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("id");

                    b.HasIndex("clienteid");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("LojaTitanica.Models.Item", b =>
                {
                    b.HasOne("LojaTitanica.Models.Venda", null)
                        .WithMany("items")
                        .HasForeignKey("Vendaid");

                    b.HasOne("LojaTitanica.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("produtoid");

                    b.Navigation("produto");
                });

            modelBuilder.Entity("LojaTitanica.Models.Venda", b =>
                {
                    b.HasOne("LojaTitanica.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteid");

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("LojaTitanica.Models.Venda", b =>
                {
                    b.Navigation("items");
                });
#pragma warning restore 612, 618
        }
    }
}
