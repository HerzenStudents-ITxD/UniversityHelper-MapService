﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityHelper.MapService.Data.Provider.MsSql.Ef;

#nullable disable

namespace UniversityHelper.MapService.Data.Provider.MsSql.Ef.Migrations
{
    [DbContext(typeof(MapServiceDbContext))]
    [Migration("20250412214350_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbLabel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Labels", (string)null);
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("X")
                        .HasColumnType("real");

                    b.Property<float>("Y")
                        .HasColumnType("real");

                    b.Property<float>("Z")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Points", (string)null);
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointAssociation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Association")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PointId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.ToTable("PointAssociations", (string)null);
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointLabel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("LabelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PointId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.HasIndex("PointId");

                    b.ToTable("LabelPoints", (string)null);
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("OrdinalNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("PointId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.ToTable("Photos", (string)null);
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PointTypes", (string)null);
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointTypeAssociation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Association")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PointTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PointTypeId");

                    b.ToTable("PointTypeAssociations", (string)null);
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointTypePoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PointTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.HasIndex("PointTypeId");

                    b.ToTable("PointTypePoints", (string)null);
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointTypeRectangularParallelepiped", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PointTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("X1")
                        .HasColumnType("real");

                    b.Property<float>("X2")
                        .HasColumnType("real");

                    b.Property<float>("Y1")
                        .HasColumnType("real");

                    b.Property<float>("Y2")
                        .HasColumnType("real");

                    b.Property<float>("Z1")
                        .HasColumnType("real");

                    b.Property<float>("Z2")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PointTypeId");

                    b.ToTable("PointTypeRectangularParallelepipeds", (string)null);
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbRelation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DbPointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FirstPointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SecondPointId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DbPointId");

                    b.HasIndex("FirstPointId")
                        .IsUnique();

                    b.HasIndex("SecondPointId")
                        .IsUnique();

                    b.ToTable("Relations", (string)null);
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointAssociation", b =>
                {
                    b.HasOne("UniversityHelper.MapService.Models.Db.DbPoint", "Point")
                        .WithMany("Associations")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Point");
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointLabel", b =>
                {
                    b.HasOne("UniversityHelper.MapService.Models.Db.DbLabel", "Label")
                        .WithMany("Points")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityHelper.MapService.Models.Db.DbPoint", "Point")
                        .WithMany("Labels")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Label");

                    b.Navigation("Point");
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointPhoto", b =>
                {
                    b.HasOne("UniversityHelper.MapService.Models.Db.DbPoint", "Point")
                        .WithMany("Photos")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Point");
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointTypeAssociation", b =>
                {
                    b.HasOne("UniversityHelper.MapService.Models.Db.DbPointType", "PointType")
                        .WithMany("Associations")
                        .HasForeignKey("PointTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PointType");
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointTypePoint", b =>
                {
                    b.HasOne("UniversityHelper.MapService.Models.Db.DbPoint", "Point")
                        .WithMany("PointTypes")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityHelper.MapService.Models.Db.DbPointType", "PointType")
                        .WithMany("Points")
                        .HasForeignKey("PointTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Point");

                    b.Navigation("PointType");
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointTypeRectangularParallelepiped", b =>
                {
                    b.HasOne("UniversityHelper.MapService.Models.Db.DbPointType", "PointType")
                        .WithMany("Parallelepipeds")
                        .HasForeignKey("PointTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PointType");
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbRelation", b =>
                {
                    b.HasOne("UniversityHelper.MapService.Models.Db.DbPoint", null)
                        .WithMany("Relations")
                        .HasForeignKey("DbPointId");

                    b.HasOne("UniversityHelper.MapService.Models.Db.DbPoint", "FirstPoint")
                        .WithOne()
                        .HasForeignKey("UniversityHelper.MapService.Models.Db.DbRelation", "FirstPointId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityHelper.MapService.Models.Db.DbPoint", "SecondPoint")
                        .WithOne()
                        .HasForeignKey("UniversityHelper.MapService.Models.Db.DbRelation", "SecondPointId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FirstPoint");

                    b.Navigation("SecondPoint");
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbLabel", b =>
                {
                    b.Navigation("Points");
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPoint", b =>
                {
                    b.Navigation("Associations");

                    b.Navigation("Labels");

                    b.Navigation("Photos");

                    b.Navigation("PointTypes");

                    b.Navigation("Relations");
                });

            modelBuilder.Entity("UniversityHelper.MapService.Models.Db.DbPointType", b =>
                {
                    b.Navigation("Associations");

                    b.Navigation("Parallelepipeds");

                    b.Navigation("Points");
                });
#pragma warning restore 612, 618
        }
    }
}
