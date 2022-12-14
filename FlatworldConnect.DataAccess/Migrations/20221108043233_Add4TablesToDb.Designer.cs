// <auto-generated />
using System;
using FlatworldConnect.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlatworldConnect.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221108043233_Add4TablesToDb")]
    partial class Add4TablesToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlatworldConnect.Models.Customer", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customerId"), 1L, 1);

                    b.Property<string>("customerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("customerPhone")
                        .HasColumnType("bigint");

                    b.HasKey("customerId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("FlatworldConnect.Models.Project", b =>
                {
                    b.Property<int>("projectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("projectId"), 1L, 1);

                    b.Property<int>("PMId")
                        .HasColumnType("int");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<string>("projectDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("projectEndDate")
                        .HasColumnType("date");

                    b.Property<string>("projectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("projectStartDate")
                        .HasColumnType("date");

                    b.HasKey("projectId");

                    b.HasIndex("PMId");

                    b.HasIndex("customerId");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("FlatworldConnect.Models.ProjectManager", b =>
                {
                    b.Property<int>("PMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PMId"), 1L, 1);

                    b.Property<string>("PMAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PMEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PMLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PMName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PMPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PMPhone")
                        .HasColumnType("bigint");

                    b.Property<string>("PMState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PMZipCode")
                        .HasColumnType("int");

                    b.HasKey("PMId");

                    b.ToTable("projectManagers");
                });

            modelBuilder.Entity("FlatworldConnect.Models.Resource", b =>
                {
                    b.Property<int>("resourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("resourceId"), 1L, 1);

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("date");

                    b.Property<int>("experience")
                        .HasColumnType("int");

                    b.Property<string>("jobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("noOfMonths")
                        .HasColumnType("int");

                    b.Property<int>("noOfResources")
                        .HasColumnType("int");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<string>("skillSet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("date");

                    b.HasKey("resourceId");

                    b.HasIndex("customerId");

                    b.ToTable("resources");
                });

            modelBuilder.Entity("FlatworldConnect.Models.Project", b =>
                {
                    b.HasOne("FlatworldConnect.Models.ProjectManager", "PM")
                        .WithMany()
                        .HasForeignKey("PMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlatworldConnect.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("PM");
                });

            modelBuilder.Entity("FlatworldConnect.Models.Resource", b =>
                {
                    b.HasOne("FlatworldConnect.Models.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });
#pragma warning restore 612, 618
        }
    }
}
