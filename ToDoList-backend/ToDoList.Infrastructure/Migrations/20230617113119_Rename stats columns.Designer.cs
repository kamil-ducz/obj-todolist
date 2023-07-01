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
    [Migration("20230617113119_Rename stats columns")]
    partial class Renamestatscolumns
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
                });

            modelBuilder.Entity("ToDoList.Domain.Models.BucketTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BucketId")
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
                        .HasForeignKey("BucketId");
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
