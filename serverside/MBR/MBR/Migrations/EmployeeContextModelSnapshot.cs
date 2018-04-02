﻿// <auto-generated />
using MBR.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace MBR.Migrations
{
    [DbContext(typeof(Context))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MBR.Models.BrokerCustomer", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("employer");

                    b.Property<bool>("employerApproved");

                    b.Property<bool>("insuranceApproved");

                    b.Property<string>("insuranceCompany");

                    b.Property<string>("name");

                    b.Property<string>("phone");

                    b.HasKey("ID");

                    b.ToTable("brokerCustomers");
                });

            modelBuilder.Entity("MBR.Models.Employee", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("employeeId");

                    b.Property<string>("name");

                    b.Property<string>("position");

                    b.Property<long>("salary");

                    b.Property<long>("years");

                    b.HasKey("id");

                    b.ToTable("employerEmployees");
                });

            modelBuilder.Entity("MBR.Models.EmployeeCallbackURL", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("applicationId");

                    b.Property<string>("callBackId");

                    b.HasKey("id");

                    b.ToTable("employeeUrls");
                });

            modelBuilder.Entity("MBR.Models.InsuranceCallbackURL", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("applicationId");

                    b.Property<string>("callBackUrl");

                    b.HasKey("id");

                    b.ToTable("insuranceUrls");
                });
#pragma warning restore 612, 618
        }
    }
}
