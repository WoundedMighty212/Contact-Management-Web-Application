﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Contact_Management_Web_Application.Migrations
{
    [DbContext(typeof(ContactContext))]
    [Migration("20240723152633_fristdb")]
    partial class fristdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Contact_Management_Web_Application.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contact", (string)null);

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            Email = "SampleContact1@gmail.com",
                            Name = "Sample Contact 1",
                            PhoneNumber = "074 324 4354"
                        },
                        new
                        {
                            ContactId = 2,
                            Email = "SampleContact2@gmail.com",
                            Name = "Sample Contact 2",
                            PhoneNumber = "075 675 2345"
                        },
                        new
                        {
                            ContactId = 3,
                            Email = "SampleContact3@gmail.com",
                            Name = "Sample Contact 3",
                            PhoneNumber = "084 323 6756"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
