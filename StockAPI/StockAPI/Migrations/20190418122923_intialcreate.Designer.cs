﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockAPI.API.Data;

namespace StockAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190418122923_intialcreate")]
    partial class intialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799");

            modelBuilder.Entity("StockAPI.API.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Commission");

                    b.Property<int?>("PersonID")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("stockID");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.HasIndex("stockID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("StockAPI.API.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BrokerID");

                    b.Property<string>("PersonName");

                    b.Property<string>("PersonType");

                    b.HasKey("PersonID");

                    b.HasIndex("BrokerID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("StockAPI.API.Models.Stock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("ID");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("StockAPI.API.Models.Order", b =>
                {
                    b.HasOne("StockAPI.API.Models.Person", "person")
                        .WithMany("Orders")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StockAPI.API.Models.Stock", "stock")
                        .WithMany("Orders")
                        .HasForeignKey("stockID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StockAPI.API.Models.Person", b =>
                {
                    b.HasOne("StockAPI.API.Models.Person", "Broker")
                        .WithMany()
                        .HasForeignKey("BrokerID");
                });
#pragma warning restore 612, 618
        }
    }
}
