﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolBus_Access.Context;

#nullable disable

namespace SchoolBus_Access.Migrations
{
    [DbContext(typeof(SchoolBus_Context))]
    [Migration("20240212105454_mig5")]
    partial class mig5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Fullname");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("BusNumber");

                    b.Property<int>("SeatCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(15);

                    b.HasKey("Id");

                    b.ToTable("Buses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bus1",
                            Number = "90-BS-234",
                            SeatCount = 25
                        });
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("ClassName");

                    b.HasKey("Id");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "681.21"
                        });
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("Licence")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("FirstName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("BusId")
                        .IsUnique();

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusId = 1,
                            LastName = "Aliyev",
                            Licence = true,
                            Name = "Elmar",
                            Password = "1111",
                            Phone = "050-456-65-64",
                            Username = "aliyev"
                        });
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("FirstName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastName = "Quliyev",
                            Name = "Faiq",
                            Password = "1111",
                            Phone = "050-456-55-56",
                            Username = "quliyev"
                        });
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("FullName");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusId = 1,
                            Name = "28May"
                        });
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("HomeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("FirstName");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("ClassId");

                    b.HasIndex("ParentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusId = 1,
                            ClassId = 1,
                            HomeAddress = "28May",
                            LastName = "Quliyeva",
                            Name = "Nezrin",
                            ParentId = 1
                        });
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Driver", b =>
                {
                    b.HasOne("SchoolBus_Model.Entities.Concretes.Bus", "Bus")
                        .WithOne("Driver")
                        .HasForeignKey("SchoolBus_Model.Entities.Concretes.Driver", "BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Route", b =>
                {
                    b.HasOne("SchoolBus_Model.Entities.Concretes.Bus", "Bus")
                        .WithMany("Routes")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Student", b =>
                {
                    b.HasOne("SchoolBus_Model.Entities.Concretes.Bus", "Bus")
                        .WithMany("Students")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolBus_Model.Entities.Concretes.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolBus_Model.Entities.Concretes.Parent", "Parent")
                        .WithMany("Students")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Class");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Bus", b =>
                {
                    b.Navigation("Driver")
                        .IsRequired();

                    b.Navigation("Routes");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolBus_Model.Entities.Concretes.Parent", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
