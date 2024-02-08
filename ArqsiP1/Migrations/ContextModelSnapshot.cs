﻿// <auto-generated />
using System;
using ArqsiP1.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArqsiP1.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArqsiP1.DataModels.ConnectionSchema", b =>
                {
                    b.Property<int>("connectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("strength")
                        .HasColumnType("int");

                    b.Property<int>("userA")
                        .HasColumnType("int");

                    b.Property<int>("userB")
                        .HasColumnType("int");

                    b.HasKey("connectionId");

                    b.ToTable("Connection");
                });

            modelBuilder.Entity("ArqsiP1.DataModels.IntroductionSchema", b =>
                {
                    b.Property<int>("introductionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("itermediatePlayerId")
                        .HasColumnType("int");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("playerId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("targetPlayerId")
                        .HasColumnType("int");

                    b.HasKey("introductionId");

                    b.ToTable("Introduction");
                });

            modelBuilder.Entity("ArqsiP1.DataModels.PlayerSchema", b =>
                {
                    b.Property<int>("playerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("birthdate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emotionalState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("linkedIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("playerId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("ArqsiP1.DataModels.TagSchema", b =>
                {
                    b.Property<int>("tagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("connectionId")
                        .HasColumnType("int");

                    b.Property<int?>("playerId")
                        .HasColumnType("int");

                    b.Property<int?>("postId")
                        .HasColumnType("int");

                    b.Property<string>("tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tagId");

                    b.ToTable("Tag");
                });
#pragma warning restore 612, 618
        }
    }
}
