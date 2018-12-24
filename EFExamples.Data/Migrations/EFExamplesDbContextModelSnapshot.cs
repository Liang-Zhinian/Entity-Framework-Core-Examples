﻿// <auto-generated />
using System;
using EFExamples.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFExamples.Data.Migrations
{
    [DbContext(typeof(EFExamplesDbContext))]
    partial class EFExamplesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFExamples.Models.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("sysdatetime()");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2(2)");

                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(300)
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("EFExamples.Models.Entities.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("sysdatetime()");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2(2)");

                    b.Property<int>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("Contractor");
                });

            modelBuilder.Entity("EFExamples.Models.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("sysdatetime()");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2(2)");

                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(300)
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("EFExamples.Models.Entities.DepartmentContractor", b =>
                {
                    b.Property<int>("ContractorId");

                    b.Property<int>("DepartmentId");

                    b.HasKey("ContractorId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DepartmentContractor");
                });

            modelBuilder.Entity("EFExamples.Models.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("sysdatetime()");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2(2)");

                    b.Property<int>("DepartmentId");

                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EFExamples.Models.Entities.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("sysdatetime()");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2(2)");

                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(300)
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("EFExamples.Models.Entities.Contractor", b =>
                {
                    b.HasOne("EFExamples.Models.Entities.Vendor", "Vendor")
                        .WithMany("Contractors")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("EFExamples.Models.ValueTypes.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ContractorId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("City")
                                .HasMaxLength(150)
                                .HasDefaultValue("");

                            b1.Property<string>("State")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("State")
                                .HasMaxLength(60)
                                .HasDefaultValue("");

                            b1.Property<string>("StreetAddress")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("StreetAddress")
                                .HasMaxLength(600)
                                .HasDefaultValue("");

                            b1.Property<string>("ZipCode")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("ZipCode")
                                .HasMaxLength(12)
                                .HasDefaultValue("");

                            b1.HasKey("ContractorId");

                            b1.ToTable("Contractor");

                            b1.HasOne("EFExamples.Models.Entities.Contractor")
                                .WithOne("Address")
                                .HasForeignKey("EFExamples.Models.ValueTypes.Address", "ContractorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("EFExamples.Models.ValueTypes.PersonName", "Name", b1 =>
                        {
                            b1.Property<int>("ContractorId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FirstName")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("FirstName")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.Property<string>("LastName")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("LastName")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("ContractorId");

                            b1.ToTable("Contractor");

                            b1.HasOne("EFExamples.Models.Entities.Contractor")
                                .WithOne("Name")
                                .HasForeignKey("EFExamples.Models.ValueTypes.PersonName", "ContractorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("EFExamples.Models.Entities.Department", b =>
                {
                    b.HasOne("EFExamples.Models.Entities.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFExamples.Models.Entities.DepartmentContractor", b =>
                {
                    b.HasOne("EFExamples.Models.Entities.Contractor", "Contractor")
                        .WithMany("DepartmentContractors")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFExamples.Models.Entities.Department", "Department")
                        .WithMany("DepartmentContractors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFExamples.Models.Entities.Employee", b =>
                {
                    b.HasOne("EFExamples.Models.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EFExamples.Models.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("EFExamples.Models.ValueTypes.Address", "Address", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("City")
                                .HasMaxLength(150)
                                .HasDefaultValue("");

                            b1.Property<string>("State")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("State")
                                .HasMaxLength(60)
                                .HasDefaultValue("");

                            b1.Property<string>("StreetAddress")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("StreetAddress")
                                .HasMaxLength(600)
                                .HasDefaultValue("");

                            b1.Property<string>("ZipCode")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("ZipCode")
                                .HasMaxLength(12)
                                .HasDefaultValue("");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employee");

                            b1.HasOne("EFExamples.Models.Entities.Employee")
                                .WithOne("Address")
                                .HasForeignKey("EFExamples.Models.ValueTypes.Address", "EmployeeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("EFExamples.Models.ValueTypes.PersonName", "Name", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FirstName")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("FirstName")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.Property<string>("LastName")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("LastName")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employee");

                            b1.HasOne("EFExamples.Models.Entities.Employee")
                                .WithOne("Name")
                                .HasForeignKey("EFExamples.Models.ValueTypes.PersonName", "EmployeeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
