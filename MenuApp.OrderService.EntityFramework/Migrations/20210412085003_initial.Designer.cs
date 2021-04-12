﻿// <auto-generated />
using System;
using MenuApp.OrderService.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MenuApp.OrderService.EntityFramework.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210412085003_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("MenuApp.OrderService.Logic.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("MenuItemId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("MenuApp.OrderService.Logic.Entities.MenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("char(36)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("MenuApp.OrderService.Logic.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MenuApp.OrderService.Logic.Entities.WeatherForecast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Date")
                        .HasColumnType("longtext");

                    b.Property<string>("Summary")
                        .HasColumnType("longtext");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Forecasts");
                });

            modelBuilder.Entity("MenuApp.OrderService.Logic.Entities.Ingredient", b =>
                {
                    b.HasOne("MenuApp.OrderService.Logic.Entities.MenuItem", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("MenuItemId");
                });

            modelBuilder.Entity("MenuApp.OrderService.Logic.Entities.MenuItem", b =>
                {
                    b.HasOne("MenuApp.OrderService.Logic.Entities.Order", null)
                        .WithMany("OrderList")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("MenuApp.OrderService.Logic.Entities.MenuItem", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("MenuApp.OrderService.Logic.Entities.Order", b =>
                {
                    b.Navigation("OrderList");
                });
#pragma warning restore 612, 618
        }
    }
}