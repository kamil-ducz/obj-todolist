﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    [DbContext(typeof(ToDoListDbContext))]
    [Migration("20230617122606_Seed data")]
    partial class Seeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssigneeBucketTask", b =>
                {
                    b.Property<int>("AssigneesId")
                        .HasColumnType("int");

                    b.Property<int>("BucketTasksId")
                        .HasColumnType("int");

                    b.HasKey("AssigneesId", "BucketTasksId");

                    b.HasIndex("BucketTasksId");

                    b.ToTable("AssigneeBucketTask");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Assignee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Assignees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "John Doe"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Bucket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BucketColor")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MaxAmountOfTasks")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buckets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BucketColor = 0,
                            Category = 0,
                            IsActive = true,
                            MaxAmountOfTasks = 0,
                            Name = "Work"
                        },
                        new
                        {
                            Id = 2,
                            BucketColor = 0,
                            Category = 0,
                            IsActive = true,
                            MaxAmountOfTasks = 0,
                            Name = "Home"
                        },
                        new
                        {
                            Id = 3,
                            BucketColor = 0,
                            Category = 0,
                            IsActive = true,
                            MaxAmountOfTasks = 0,
                            Name = "Hobby"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Models.BucketTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BucketId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskPriority")
                        .HasColumnType("int");

                    b.Property<int>("TaskState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BucketId");

                    b.ToTable("BucketTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BucketId = 1,
                            Name = "Speak to manager",
                            TaskPriority = 0,
                            TaskState = 0
                        },
                        new
                        {
                            Id = 2,
                            BucketId = 1,
                            Name = "Organize desk",
                            TaskPriority = 0,
                            TaskState = 1
                        },
                        new
                        {
                            Id = 3,
                            BucketId = 2,
                            Name = "Water plants",
                            TaskPriority = 0,
                            TaskState = 3
                        },
                        new
                        {
                            Id = 4,
                            BucketId = 2,
                            Name = "Clean bedroom",
                            TaskPriority = 0,
                            TaskState = 2
                        },
                        new
                        {
                            Id = 5,
                            BucketId = 3,
                            Name = "Organize diet",
                            TaskPriority = 0,
                            TaskState = 2
                        },
                        new
                        {
                            Id = 6,
                            BucketId = 3,
                            Name = "Update training plan",
                            TaskPriority = 0,
                            TaskState = 1
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Stats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AssigneeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cancelled")
                        .HasPrecision(3)
                        .HasColumnType("decimal(3,0)");

                    b.Property<decimal>("Completed")
                        .HasPrecision(3)
                        .HasColumnType("decimal(3,0)");

                    b.Property<decimal>("InProgress")
                        .HasPrecision(3)
                        .HasColumnType("decimal(3,0)");

                    b.Property<decimal>("ToDo")
                        .HasPrecision(3)
                        .HasColumnType("decimal(3,0)");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.ToTable("Stats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cancelled = 0m,
                            Completed = 0m,
                            InProgress = 0m,
                            ToDo = 0m
                        });
                });

            modelBuilder.Entity("AssigneeBucketTask", b =>
                {
                    b.HasOne("ToDoList.Domain.Models.Assignee", null)
                        .WithMany()
                        .HasForeignKey("AssigneesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoList.Domain.Models.BucketTask", null)
                        .WithMany()
                        .HasForeignKey("BucketTasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoList.Domain.Models.BucketTask", b =>
                {
                    b.HasOne("ToDoList.Domain.Models.Bucket", null)
                        .WithMany("BucketTasks")
                        .HasForeignKey("BucketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Stats", b =>
                {
                    b.HasOne("ToDoList.Domain.Models.Assignee", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.Navigation("Assignee");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Bucket", b =>
                {
                    b.Navigation("BucketTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
