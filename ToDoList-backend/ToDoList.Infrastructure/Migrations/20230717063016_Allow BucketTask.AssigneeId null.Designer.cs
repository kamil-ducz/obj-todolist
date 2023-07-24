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
    [Migration("20230717063016_Allow BucketTask.AssigneeId null")]
    partial class AllowBucketTaskAssigneeIdnull
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Assignees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Otobong Shay"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pilirani Tendai"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Jess Blue"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Beck Itumeleng"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Radha Mpho"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Chikelu Tshepo"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Amal Yu"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Sasha Tristin"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Lee Lihuén"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Bucket", b =>
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
                            BucketCategoryId = 2,
                            BucketColorId = 1,
                            IsActive = true,
                            MaxAmountOfTasks = 15,
                            Name = "Objectivity"
                        },
                        new
                        {
                            Id = 2,
                            BucketCategoryId = 2,
                            BucketColorId = 2,
                            IsActive = true,
                            MaxAmountOfTasks = 15,
                            Name = "Kitchen"
                        },
                        new
                        {
                            Id = 3,
                            BucketCategoryId = 2,
                            BucketColorId = 4,
                            IsActive = true,
                            MaxAmountOfTasks = 15,
                            Name = "Gym"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Models.BucketCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BucketCategories");

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

            modelBuilder.Entity("ToDoList.Domain.Models.BucketColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BucketColors");

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

                    b.Property<int>("BucketTaskPriorityId")
                        .HasColumnType("int");

                    b.Property<int>("BucketTaskStateId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("BucketId");

                    b.HasIndex("BucketTaskPriorityId");

                    b.HasIndex("BucketTaskStateId");

                    b.ToTable("BucketTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssigneeId = 1,
                            BucketId = 1,
                            BucketTaskPriorityId = 3,
                            BucketTaskStateId = 1,
                            Name = "1:1 leader"
                        },
                        new
                        {
                            Id = 2,
                            AssigneeId = 2,
                            BucketId = 1,
                            BucketTaskPriorityId = 2,
                            BucketTaskStateId = 3,
                            Name = "Organize desk"
                        },
                        new
                        {
                            Id = 3,
                            AssigneeId = 3,
                            BucketId = 2,
                            BucketTaskPriorityId = 1,
                            BucketTaskStateId = 4,
                            Name = "Water plants"
                        },
                        new
                        {
                            Id = 4,
                            AssigneeId = 4,
                            BucketId = 2,
                            BucketTaskPriorityId = 1,
                            BucketTaskStateId = 2,
                            Name = "Clean bedroom"
                        },
                        new
                        {
                            Id = 5,
                            AssigneeId = 5,
                            BucketId = 3,
                            BucketTaskPriorityId = 1,
                            BucketTaskStateId = 1,
                            Name = "Organize diet"
                        },
                        new
                        {
                            Id = 6,
                            AssigneeId = 6,
                            BucketId = 3,
                            BucketTaskPriorityId = 2,
                            BucketTaskStateId = 3,
                            Name = "Training plan"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Models.BucketTaskPriority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BucketTaskPriorities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "High"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Low"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Models.BucketTaskState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BucketTaskStates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "To do"
                        },
                        new
                        {
                            Id = 2,
                            Name = "In progress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Done"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Bucket", b =>
                {
                    b.HasOne("ToDoList.Domain.Models.BucketCategory", "BucketCategory")
                        .WithMany()
                        .HasForeignKey("BucketCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoList.Domain.Models.BucketColor", "BucketColor")
                        .WithMany()
                        .HasForeignKey("BucketColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BucketCategory");

                    b.Navigation("BucketColor");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.BucketTask", b =>
                {
                    b.HasOne("ToDoList.Domain.Models.Assignee", "Assignee")
                        .WithMany("BucketTask")
                        .HasForeignKey("AssigneeId");

                    b.HasOne("ToDoList.Domain.Models.Bucket", "Bucket")
                        .WithMany("BucketTask")
                        .HasForeignKey("BucketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoList.Domain.Models.BucketTaskPriority", "BucketTaskPriority")
                        .WithMany()
                        .HasForeignKey("BucketTaskPriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoList.Domain.Models.BucketTaskState", "BucketTaskState")
                        .WithMany()
                        .HasForeignKey("BucketTaskStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("Bucket");

                    b.Navigation("BucketTaskPriority");

                    b.Navigation("BucketTaskState");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Assignee", b =>
                {
                    b.Navigation("BucketTask");
                });

            modelBuilder.Entity("ToDoList.Domain.Models.Bucket", b =>
                {
                    b.Navigation("BucketTask");
                });
#pragma warning restore 612, 618
        }
    }
}
