﻿// <auto-generated />
using System;
using DefenseSimulator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DefenseSimulator.Migrations
{
    [DbContext(typeof(DefenseSimulatorContext))]
    partial class DefenseSimulatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DefenseSimulator.Models.Cities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = -80,
                            Name = "צפון"
                        },
                        new
                        {
                            Id = 2,
                            Location = 0,
                            Name = "מרכז"
                        },
                        new
                        {
                            Id = 3,
                            Location = 60,
                            Name = "דרום"
                        });
                });

            modelBuilder.Entity("DefenseSimulator.Models.CountTil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AntiAirSystem")
                        .HasColumnType("int");

                    b.Property<int>("ElectronicJamming")
                        .HasColumnType("int");

                    b.Property<int>("InterceptorMissile")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CountTil");
                });

            modelBuilder.Entity("DefenseSimulator.Models.States", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Distance = 70,
                            Name = "Hamas"
                        },
                        new
                        {
                            Id = 2,
                            Distance = -100,
                            Name = "Hezbollah"
                        },
                        new
                        {
                            Id = 3,
                            Distance = 2377,
                            Name = "Houthis"
                        },
                        new
                        {
                            Id = 4,
                            Distance = 1600,
                            Name = "Iran"
                        });
                });

            modelBuilder.Entity("Response", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResponseId"));

                    b.Property<DateTime?>("InterceptTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("ThreatId")
                        .HasColumnType("int");

                    b.HasKey("ResponseId");

                    b.HasIndex("ThreatId");

                    b.ToTable("Response");
                });

            modelBuilder.Entity("Threat", b =>
                {
                    b.Property<int>("ThreatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThreatId"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LaunchTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Target")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("ThreatId");

                    b.HasIndex("CityId");

                    b.HasIndex("StateId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Threat");
                });

            modelBuilder.Entity("Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeaponId"));

                    b.Property<string>("CounterMeasure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeaponId");

                    b.ToTable("Weapon");

                    b.HasData(
                        new
                        {
                            WeaponId = 1,
                            CounterMeasure = "ElectronicJamming",
                            Speed = 300,
                            Type = "BallisticMissile"
                        },
                        new
                        {
                            WeaponId = 2,
                            CounterMeasure = "AntiAirSystem",
                            Speed = 880,
                            Type = "Drone"
                        },
                        new
                        {
                            WeaponId = 3,
                            CounterMeasure = "InterceptorMissile",
                            Speed = 18000,
                            Type = "Rocket"
                        });
                });

            modelBuilder.Entity("Response", b =>
                {
                    b.HasOne("Threat", "Threat")
                        .WithMany()
                        .HasForeignKey("ThreatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Threat");
                });

            modelBuilder.Entity("Threat", b =>
                {
                    b.HasOne("DefenseSimulator.Models.Cities", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DefenseSimulator.Models.States", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("State");

                    b.Navigation("Weapon");
                });
#pragma warning restore 612, 618
        }
    }
}
