﻿// <auto-generated />
using System;
using DrSneuss.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Sneuss_Factoty.Migrations
{
    [DbContext(typeof(DrSneussContext))]
    partial class DrSneussContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DrSneuss.Models.Engineer", b =>
                {
                    b.Property<int>("EngineerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EngineerName");

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<int?>("MachineId");

                    b.HasKey("EngineerId");

                    b.HasIndex("MachineId");

                    b.ToTable("Engineers");
                });

            modelBuilder.Entity("DrSneuss.Models.EngineerMachine", b =>
                {
                    b.Property<int>("EngineerMachineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EngineerId");

                    b.Property<int>("MachineId");

                    b.HasKey("EngineerMachineId");

                    b.HasIndex("EngineerId");

                    b.HasIndex("MachineId");

                    b.ToTable("EngineerMachine");
                });

            modelBuilder.Entity("DrSneuss.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MachineName");

                    b.Property<string>("MachineNumber");

                    b.HasKey("MachineId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("DrSneuss.Models.Engineer", b =>
                {
                    b.HasOne("DrSneuss.Models.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId");
                });

            modelBuilder.Entity("DrSneuss.Models.EngineerMachine", b =>
                {
                    b.HasOne("DrSneuss.Models.Engineer", "Engineer")
                        .WithMany("Machines")
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DrSneuss.Models.Machine", "Machine")
                        .WithMany("Engineers")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
