﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using TopcoderNetApi.DataContext;

namespace TopcoderNetApi.Migrations
{
    [DbContext(typeof(OnlineCourseDataContext))]
    internal class OnlineCourseDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TopcoderNetApi.Model.Course", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnType("nvarchar(250)");

                b.HasKey("Id");

                b.ToTable("Courses");
            });

            modelBuilder.Entity("TopcoderNetApi.Model.Lesson", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("IsCompleted")
                    .HasColumnType("bit");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnType("nvarchar(250)");

                b.Property<int>("Order")
                    .HasColumnType("int");

                b.Property<Guid?>("SectionId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("VideoUrl")
                    .HasMaxLength(355)
                    .HasColumnType("nvarchar(355)");

                b.HasKey("Id");

                b.HasIndex("SectionId");

                b.ToTable("Lessons");
            });

            modelBuilder.Entity("TopcoderNetApi.Model.Section", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("CourseId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnType("nvarchar(250)");

                b.Property<int>("Order")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("CourseId");

                b.ToTable("Sections");
            });

            modelBuilder.Entity("TopcoderNetApi.Model.User", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("FullName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ImageUrl")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Users");
            });

            modelBuilder.Entity("TopcoderNetApi.Model.WatchLog", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("nvarchar(450)");

                b.Property<Guid?>("CourseId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("LessonId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("PercentageWatched")
                    .HasColumnType("int");

                b.Property<string>("UserId")
                    .HasColumnType("nvarchar(450)");

                b.HasKey("Id");

                b.HasIndex("CourseId");

                b.HasIndex("LessonId");

                b.HasIndex("UserId");

                b.ToTable("WatchLogs");
            });

            modelBuilder.Entity("TopcoderNetApi.Model.Lesson", b =>
            {
                b.HasOne("TopcoderNetApi.Model.Section", "Section")
                    .WithMany()
                    .HasForeignKey("SectionId");

                b.Navigation("Section");
            });

            modelBuilder.Entity("TopcoderNetApi.Model.Section", b =>
            {
                b.HasOne("TopcoderNetApi.Model.Course", "Course")
                    .WithMany()
                    .HasForeignKey("CourseId");

                b.Navigation("Course");
            });

            modelBuilder.Entity("TopcoderNetApi.Model.WatchLog", b =>
            {
                b.HasOne("TopcoderNetApi.Model.Course", "Course")
                    .WithMany()
                    .HasForeignKey("CourseId");

                b.HasOne("TopcoderNetApi.Model.Lesson", "Lesson")
                    .WithMany()
                    .HasForeignKey("LessonId");

                b.HasOne("TopcoderNetApi.Model.User", "User")
                    .WithMany()
                    .HasForeignKey("UserId");

                b.Navigation("Course");

                b.Navigation("Lesson");

                b.Navigation("User");
            });
#pragma warning restore 612, 618
        }
    }
}