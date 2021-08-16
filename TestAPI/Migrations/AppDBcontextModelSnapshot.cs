﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAPI.Models;

namespace TestAPI.Migrations
{
    [DbContext(typeof(AppDBcontext))]
    partial class AppDBcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestAPI.Models.Buildings", b =>
                {
                    b.Property<int>("PKBuilding")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Avaliable")
                        .HasColumnType("bit");

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("PKBuilding");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("TestAPI.Models.Customers", b =>
                {
                    b.Property<int>("PKCustomers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Avaliable")
                        .HasColumnType("bit");

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("FKBuildingsPKBuilding")
                        .HasColumnType("int");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.HasKey("PKCustomers");

                    b.HasIndex("FKBuildingsPKBuilding");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TestAPI.Models.PartNumbers", b =>
                {
                    b.Property<int>("PKPartNumbers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Avaliable")
                        .HasColumnType("bit");

                    b.Property<int?>("FKCustomersPKCustomers")
                        .HasColumnType("int");

                    b.Property<string>("PartNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("PKPartNumbers");

                    b.HasIndex("FKCustomersPKCustomers");

                    b.ToTable("PartNumbers");
                });

            modelBuilder.Entity("TestAPI.Models.Customers", b =>
                {
                    b.HasOne("TestAPI.Models.Buildings", "FKBuildings")
                        .WithMany("Customers")
                        .HasForeignKey("FKBuildingsPKBuilding");

                    b.Navigation("FKBuildings");
                });

            modelBuilder.Entity("TestAPI.Models.PartNumbers", b =>
                {
                    b.HasOne("TestAPI.Models.Customers", "FKCustomers")
                        .WithMany("PartNumbers")
                        .HasForeignKey("FKCustomersPKCustomers");

                    b.Navigation("FKCustomers");
                });

            modelBuilder.Entity("TestAPI.Models.Buildings", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("TestAPI.Models.Customers", b =>
                {
                    b.Navigation("PartNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
