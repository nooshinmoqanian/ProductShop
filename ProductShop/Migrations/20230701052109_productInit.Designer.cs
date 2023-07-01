﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductShop.DBContext;

#nullable disable

namespace ProductShop.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20230701052109_productInit")]
    partial class productInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductShop.Models.Additive", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("ProductId");

                    b.ToTable("additives");
                });

            modelBuilder.Entity("ProductShop.Models.Feature", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("IdProduct")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("ProductId");

                    b.ToTable("features");
                });

            modelBuilder.Entity("ProductShop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("count")
                        .HasColumnType("integer");

                    b.Property<int?>("discountAmount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("discount_expire_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int>("typePrice")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("product");
                });

            modelBuilder.Entity("ProductShop.Models.Additive", b =>
                {
                    b.HasOne("ProductShop.Models.Product", null)
                        .WithMany("additive")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ProductShop.Models.Feature", b =>
                {
                    b.HasOne("ProductShop.Models.Product", null)
                        .WithMany("feature")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ProductShop.Models.Product", b =>
                {
                    b.Navigation("additive");

                    b.Navigation("feature");
                });
#pragma warning restore 612, 618
        }
    }
}
