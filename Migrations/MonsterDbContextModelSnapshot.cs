﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sapphire.Data;

#nullable disable

namespace Sapphire.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class MonsterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sapphire.Models.Hunters", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("HunterName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<double>("ZennyAmount")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("T_hunters");
                });

            modelBuilder.Entity("Sapphire.Models.Monsters", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("BaseAttack")
                        .HasColumnType("double precision");

                    b.Property<double>("BaseDefense")
                        .HasColumnType("double precision");

                    b.Property<double>("HealthPool")
                        .HasColumnType("double precision");

                    b.Property<string>("MonsterName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("T_monsters");
                });
#pragma warning restore 612, 618
        }
    }
}
