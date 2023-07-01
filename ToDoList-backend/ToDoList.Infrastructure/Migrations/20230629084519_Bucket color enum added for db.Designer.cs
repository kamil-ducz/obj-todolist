﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    [DbContext(typeof(ToDoListDbContext))]
    [Migration("20230629084519_Bucket color enum added for db")]
    partial class Bucketcolorenumaddedfordb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssigneesBucketTasks", b =>
                {
                    b.Property<int>("AssigneesId")
                        .HasColumnType("int");

                    b.Property<int>("BucketTasksId")
                        .HasColumnType("int");

                    b.HasKey("AssigneesId", "BucketTasksId");

                    b.HasIndex("BucketTasksId");

                    b.ToTable("AssigneesBucketTasks");
                });

            modelBuilder.Entity("ToDoList.Domain.Enums.BucketCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BucketCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Work"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Home"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hobby"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Enums.BucketColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BucketColor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brown"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Red"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Yellow"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Blue"
                        },
                        new
                        {
                            Id = 5,
                            Name = "White"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Green"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Assignees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
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

            modelBuilder.Entity("ToDoList.Domain.Models.Buckets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BucketCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("BucketColorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MaxAmountOfTasks")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BucketCategoryId");

                    b.HasIndex("BucketColorId");

                    b.ToTable("Buckets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BucketCategoryId = 1,
                            BucketColorId = 1,
                            IsActive = true,
                            MaxAmountOfTasks = 15,
                            Name = "Work"
                        },
                        new
                        {
                            Id = 2,
                            BucketCategoryId = 2,
                            BucketColorId = 2,
                            IsActive = true,
                            MaxAmountOfTasks = 15,
                            Name = "Home"
                        },
                        new
                        {
                            Id = 3,
                            BucketCategoryId = 3,
                            BucketColorId = 3,
                            IsActive = true,
                            MaxAmountOfTasks = 15,
                            Name = "Hobby"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Models.BucketTasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BucketsId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskPriority")
                        .HasColumnType("int");

                    b.Property<int>("TaskState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BucketsId");

                    b.ToTable("BucketTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BucketsId = 1,
                            Name = "Speak to manager",
                            TaskPriority = 0,
                            TaskState = 0
                        },
                        new
                        {
                            Id = 2,
                            BucketsId = 1,
                            Name = "Organize desk",
                            TaskPriority = 0,
                            TaskState = 1
                        },
                        new
                        {
                            Id = 3,
                            BucketsId = 2,
                            Name = "Water plants",
                            TaskPriority = 0,
                            TaskState = 3
                        },
                        new
                        {
                            Id = 4,
                            BucketsId = 2,
                            Name = "Clean bedroom",
                            TaskPriority = 0,
                            TaskState = 2
                        },
                        new
                        {
                            Id = 5,
                            BucketsId = 3,
                            Name = "Organize diet",
                            TaskPriority = 0,
                            TaskState = 2
                        },
                        new
                        {
                            Id = 6,
                            BucketsId = 3,
                            Name = "Update training plan",
                            TaskPriority = 0,
                            TaskState = 1
                        });
                });

            modelBuilder.Entity("AssigneesBucketTasks", b =>
                {
                    b.HasOne("ToDoList.Domain.Models.Assignees", null)
                        .WithMany()
                        .HasForeignKey("AssigneesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoList.Domain.Models.BucketTasks", null)
                        .WithMany()
                        .HasForeignKey("BucketTasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Buckets", b =>
                {
                    b.HasOne("ToDoList.Domain.Enums.BucketCategory", "BucketCategory")
                        .WithMany()
                        .HasForeignKey("BucketCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoList.Domain.Enums.BucketColor", "BucketColor")
                        .WithMany()
                        .HasForeignKey("BucketColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BucketCategory");

                    b.Navigation("BucketColor");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.BucketTasks", b =>
                {
                    b.HasOne("ToDoList.Domain.Models.Buckets", null)
                        .WithMany("BucketTasks")
                        .HasForeignKey("BucketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Buckets", b =>
                {
                    b.Navigation("BucketTasks");
                });
#pragma warning restore 612, 618
        }
    }
}