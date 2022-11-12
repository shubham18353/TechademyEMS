﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechademyEMS.DatabaseContext;

#nullable disable

namespace TechademyEMS.Migrations
{
    [DbContext(typeof(EMSDbContext))]
    [Migration("20221108065627_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TechademyEMS.Models.Authorization.Register", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("UserName", "Password");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("TechademyEMS.Models.DesignationModel.Designation", b =>
                {
                    b.Property<int>("DesigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DesigId"), 1L, 1);

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesignationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DesigId");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("TechademyEMS.Models.EmployeeModel.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DesigId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("bit");

                    b.Property<int>("LeaveId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Payscale")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TechademyEMS.Models.LeaveRequestModel.LeaveRequest", b =>
                {
                    b.Property<int>("LeaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaveId"), 1L, 1);

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("LeaveType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LeaveId");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("TechademyEMS.Models.PaymentRulesModel.PaymentRules", b =>
                {
                    b.Property<int>("Payscale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Payscale"), 1L, 1);

                    b.Property<decimal>("CostToCompany")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FixedPay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VariablePay")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Payscale");

                    b.ToTable("PaymentRules");
                });

            modelBuilder.Entity("TechademyEMS.Models.WorkingHoursModel.WorkingHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeWorkingHours")
                        .HasColumnType("int");

                    b.Property<int>("MonthlyWorkingHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WorkHours");
                });
#pragma warning restore 612, 618
        }
    }
}
