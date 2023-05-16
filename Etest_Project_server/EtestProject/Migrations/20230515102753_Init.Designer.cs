﻿// <auto-generated />
using System;
using EtestProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EtestProject.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("20230515102753_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EtestProject.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerTable");
                });

            modelBuilder.Entity("EtestProject.Models.Errors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ErrorAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrueAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.ToTable("ErrorsTable");
                });

            modelBuilder.Entity("EtestProject.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IdStudent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdTest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameStudent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_studentId")
                        .HasColumnType("int");

                    b.Property<int>("gradeStudent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_studentId");

                    b.ToTable("GradeTable");
                });

            modelBuilder.Entity("EtestProject.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<int>("correctAnswer")
                        .HasColumnType("int");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.Property<int>("isOpen")
                        .HasColumnType("int");

                    b.Property<string>("questionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("questionURLImageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studentChoose")
                        .HasColumnType("int");

                    b.Property<int>("valueOfQuestion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("QuestionTable");
                });

            modelBuilder.Entity("EtestProject.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfTeacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Random")
                        .HasColumnType("bit");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("User_teacherId")
                        .HasColumnType("int");

                    b.Property<string>("_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("User_teacherId");

                    b.ToTable("TestTable");
                });

            modelBuilder.Entity("EtestProject.Models.User_student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserStudentTable");
                });

            modelBuilder.Entity("EtestProject.Models.User_teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTeacherTable");
                });

            modelBuilder.Entity("EtestProject.Models.Answer", b =>
                {
                    b.HasOne("EtestProject.Models.Question", null)
                        .WithMany("listAnswer")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EtestProject.Models.Errors", b =>
                {
                    b.HasOne("EtestProject.Models.Grade", null)
                        .WithMany("listOfErrors")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EtestProject.Models.Grade", b =>
                {
                    b.HasOne("EtestProject.Models.User_student", null)
                        .WithMany("grades")
                        .HasForeignKey("User_studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EtestProject.Models.Question", b =>
                {
                    b.HasOne("EtestProject.Models.Test", null)
                        .WithMany("AllQuestionInTest")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EtestProject.Models.Test", b =>
                {
                    b.HasOne("EtestProject.Models.User_teacher", null)
                        .WithMany("tests")
                        .HasForeignKey("User_teacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EtestProject.Models.Grade", b =>
                {
                    b.Navigation("listOfErrors");
                });

            modelBuilder.Entity("EtestProject.Models.Question", b =>
                {
                    b.Navigation("listAnswer");
                });

            modelBuilder.Entity("EtestProject.Models.Test", b =>
                {
                    b.Navigation("AllQuestionInTest");
                });

            modelBuilder.Entity("EtestProject.Models.User_student", b =>
                {
                    b.Navigation("grades");
                });

            modelBuilder.Entity("EtestProject.Models.User_teacher", b =>
                {
                    b.Navigation("tests");
                });
#pragma warning restore 612, 618
        }
    }
}