﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleData;

#nullable disable

namespace SampleData.Migrations
{
    [DbContext(typeof(StudendDbcontext))]
    [Migration("20230818062904_books classs updated with booktypeid")]
    partial class booksclasssupdatedwithbooktypeid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SampleData.Data.Book", b =>
                {
                    b.Property<int>("bookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("bookTypeId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("bookId");

                    b.HasIndex("bookTypeId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("SampleData.Data.bookType", b =>
                {
                    b.Property<int>("bookTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookTypeId"), 1L, 1);

                    b.Property<string>("bookTypeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("booksType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bookTypeId");

                    b.ToTable("bookTypes");
                });

            modelBuilder.Entity("SampleData.Data.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"), 1L, 1);

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("SampleData.Data.GroupSubject", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"), 1L, 1);

                    b.Property<int>("GroupId1")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("GroupId1");

                    b.HasIndex("SubjectId");

                    b.ToTable("groupsSubject");
                });

            modelBuilder.Entity("SampleData.Data.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("Mobile")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("student");
                });

            modelBuilder.Entity("SampleData.Data.StudentPayments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AmountReceivedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PaidAmount")
                        .HasColumnType("float");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("studentPayments");
                });

            modelBuilder.Entity("SampleData.Data.StudentsBooks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("bookId")
                        .HasColumnType("int");

                    b.Property<bool>("hasBook")
                        .HasColumnType("bit");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("bookId");

                    b.ToTable("studentsBooks");
                });

            modelBuilder.Entity("SampleData.Data.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"), 1L, 1);

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("SampleData.Data.Book", b =>
                {
                    b.HasOne("SampleData.Data.bookType", null)
                        .WithMany("books")
                        .HasForeignKey("bookTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SampleData.Data.GroupSubject", b =>
                {
                    b.HasOne("SampleData.Data.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleData.Data.Subject", "Subject")
                        .WithMany("GroupSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SampleData.Data.Student", b =>
                {
                    b.HasOne("SampleData.Data.Group", "Group")
                        .WithMany("students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("SampleData.Data.StudentsBooks", b =>
                {
                    b.HasOne("SampleData.Data.Book", "book")
                        .WithMany()
                        .HasForeignKey("bookId");

                    b.Navigation("book");
                });

            modelBuilder.Entity("SampleData.Data.bookType", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("SampleData.Data.Group", b =>
                {
                    b.Navigation("students");
                });

            modelBuilder.Entity("SampleData.Data.Subject", b =>
                {
                    b.Navigation("GroupSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
