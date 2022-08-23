﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.Api;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    [DbContext(typeof(ToDoListDbContext))]
    [Migration("20220823152421_Init3")]
    partial class Init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ToDoList.Domain.Models.Assignee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatsId")
                        .IsUnique()
                        .HasFilter("[StatsId] IS NOT NULL");

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

                    b.Property<int?>("AssigneeId")
                        .HasColumnType("int");

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

                    b.HasIndex("AssigneeId");

                    b.HasIndex("BucketId");

                    b.ToTable("BucketTasks");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Stats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AsigneeId")
                        .HasColumnType("int");

                    b.Property<decimal>("PercentOfTasksCancelled")
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.Property<decimal>("PercentOfTasksCompleted")
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.Property<decimal>("PercentOfTasksInProgress")
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.Property<decimal>("PercentOfTasksToDo")
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Assignee", b =>
                {
                    b.HasOne("ToDoList.Domain.Models.Stats", "Stats")
                        .WithOne("Assignee")
                        .HasForeignKey("ToDoList.Domain.Models.Assignee", "StatsId");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.BucketTask", b =>
                {
                    b.HasOne("ToDoList.Domain.Models.Assignee", null)
                        .WithMany("BucketTasks")
                        .HasForeignKey("AssigneeId");

                    b.HasOne("ToDoList.Domain.Models.Bucket", "Bucket")
                        .WithMany("BucketTasks")
                        .HasForeignKey("BucketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bucket");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Assignee", b =>
                {
                    b.Navigation("BucketTasks");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Bucket", b =>
                {
                    b.Navigation("BucketTasks");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Stats", b =>
                {
                    b.Navigation("Assignee")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
