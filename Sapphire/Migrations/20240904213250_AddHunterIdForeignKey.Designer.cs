﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sapphire.Repository;

#nullable disable

namespace Sapphire.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240904213250_AddHunterIdForeignKey")]
    partial class AddHunterIdForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "78761b80-4c9e-4f60-8005-33a2b93c9fd8",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "2076aea4-d8cc-4472-837c-668e0dd67e0c",
                            Name = "Hub Manager",
                            NormalizedName = "HUB MANAGER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Sapphire.Entities.Models.Guild", b =>
                {
                    b.Property<Guid>("GuildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("GuildId");

                    b.Property<string>("GuildName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsInviteOnly")
                        .HasColumnType("boolean");

                    b.HasKey("GuildId");

                    b.ToTable("T_guild");

                    b.HasData(
                        new
                        {
                            GuildId = new Guid("7f6ad3fb-6f4d-48f7-84df-d41b45058e9f"),
                            GuildName = "The Sapphire",
                            IsInviteOnly = false
                        });
                });

            modelBuilder.Entity("Sapphire.Entities.Models.Hunters", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("HunterId");

                    b.Property<Guid?>("GuildId")
                        .HasColumnType("uuid");

                    b.Property<string>("HunterName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<double>("ZennyAmount")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("T_hunters");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e5d4e86e-88a4-470c-8786-b664855a7eb7"),
                            HunterName = "Shard",
                            Rank = 1,
                            ZennyAmount = 5000.0
                        },
                        new
                        {
                            Id = new Guid("5f218367-8c7a-476a-bee8-33df1d8306a9"),
                            HunterName = "DarkShard",
                            Rank = 1,
                            ZennyAmount = 5000.0
                        },
                        new
                        {
                            Id = new Guid("4069b0e9-7bf4-4d04-bb87-acf16e6539ac"),
                            HunterName = "Astera",
                            Rank = 50,
                            ZennyAmount = 9000.0
                        });
                });

            modelBuilder.Entity("Sapphire.Entities.Models.Locale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("LocaleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("T_locale");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d8a71bd7-b5ff-4799-b811-23d7921987da"),
                            LocaleName = "Dummy Locale"
                        });
                });

            modelBuilder.Entity("Sapphire.Entities.Models.Monsters", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("MonsterId");

                    b.Property<double>("BaseAttack")
                        .HasColumnType("double precision");

                    b.Property<double>("BaseDefense")
                        .HasColumnType("double precision");

                    b.Property<double>("HealthPool")
                        .HasColumnType("double precision");

                    b.Property<string>("MonsterName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.ToTable("T_monsters");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1993bba8-ebc9-4ee7-9fd4-cebdbac5608c"),
                            BaseAttack = 1.0,
                            BaseDefense = 1.0,
                            HealthPool = 10000.0,
                            MonsterName = "Rathian"
                        },
                        new
                        {
                            Id = new Guid("fab8c641-fa9b-4471-bfe0-9c97ec886ca5"),
                            BaseAttack = 1.0,
                            BaseDefense = 1.0,
                            HealthPool = 10000.0,
                            MonsterName = "Rathalos"
                        },
                        new
                        {
                            Id = new Guid("25e0254a-64ea-4b7b-b64e-d494eed580be"),
                            BaseAttack = 1.0,
                            BaseDefense = 1.0,
                            HealthPool = 5000.0,
                            MonsterName = "Yian Garuga"
                        });
                });

            modelBuilder.Entity("Sapphire.Entities.Models.SapphireUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<Guid?>("HunterId")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("HunterId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Sapphire.Entities.Models.SapphireUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sapphire.Entities.Models.SapphireUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sapphire.Entities.Models.SapphireUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Sapphire.Entities.Models.SapphireUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sapphire.Entities.Models.Hunters", b =>
                {
                    b.HasOne("Sapphire.Entities.Models.Guild", "Guild")
                        .WithMany("HunterMembers")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Sapphire.Entities.Models.SapphireUser", b =>
                {
                    b.HasOne("Sapphire.Entities.Models.Hunters", "Hunters")
                        .WithMany()
                        .HasForeignKey("HunterId");

                    b.Navigation("Hunters");
                });

            modelBuilder.Entity("Sapphire.Entities.Models.Guild", b =>
                {
                    b.Navigation("HunterMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
