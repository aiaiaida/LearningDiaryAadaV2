﻿// <auto-generated />
using System;
using LearningDiaryAadaV2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LearningDiaryAadaV2.Migrations
{
    [DbContext(typeof(LearningDiaryAadaV2Context))]
    partial class LearningDiaryAadaV2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LearningDiaryAadaV2.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Note1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("TopicId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("LearningDiaryAadaV2.Models.TaskInTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Done")
                        .HasColumnType("bit");

                    b.Property<string>("Priority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("TaskInTopic");
                });

            modelBuilder.Entity("LearningDiaryAadaV2.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstimatedTimeToMaster")
                        .HasColumnType("int");

                    b.Property<bool?>("InProgress")
                        .HasColumnType("bit");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartLearningDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TimeSpent")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("LearningDiaryAadaV2.Models.Note", b =>
                {
                    b.HasOne("LearningDiaryAadaV2.Models.TaskInTopic", "Task")
                        .WithMany("Notes")
                        .HasForeignKey("TaskId");

                    b.HasOne("LearningDiaryAadaV2.Models.Topic", "Topic")
                        .WithMany("Notes")
                        .HasForeignKey("TopicId");
                });

            modelBuilder.Entity("LearningDiaryAadaV2.Models.TaskInTopic", b =>
                {
                    b.HasOne("LearningDiaryAadaV2.Models.Topic", "Topic")
                        .WithMany("TaskInTopics")
                        .HasForeignKey("TopicId");
                });
#pragma warning restore 612, 618
        }
    }
}
