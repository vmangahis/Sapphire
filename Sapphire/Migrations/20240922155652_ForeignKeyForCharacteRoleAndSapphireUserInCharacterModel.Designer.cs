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
    [Migration("20240922155652_ForeignKeyForCharacteRoleAndSapphireUserInCharacterModel")]
    partial class ForeignKeyForCharacteRoleAndSapphireUserInCharacterModel
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
                            Id = "f6133849-cb96-4d8f-8785-6a494e28dc89",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "f2f7fbdb-b939-4ef1-98e0-51cb283cba6e",
                            Name = "User",
                            NormalizedName = "USER"
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

            modelBuilder.Entity("Sapphire.Entities.Models.Character", b =>
                {
                    b.Property<Guid>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CharacterName")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("CharacterId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("T_characters");
                });

            modelBuilder.Entity("Sapphire.Entities.Models.CharacterRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("RoleId");

                    b.ToTable("T_characterRoles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("15513fc4-430e-4bf2-95c9-994effabd61d"),
                            CreatedDateTime = new DateTime(2024, 9, 22, 23, 56, 52, 588, DateTimeKind.Local).AddTicks(1233),
                            RoleName = "Hunter",
                            UpdatedDateTime = new DateTime(2024, 9, 22, 23, 56, 52, 588, DateTimeKind.Local).AddTicks(1243)
                        },
                        new
                        {
                            RoleId = new Guid("01761684-4888-48f5-9717-582f066ce60d"),
                            CreatedDateTime = new DateTime(2024, 9, 22, 23, 56, 52, 588, DateTimeKind.Local).AddTicks(1247),
                            RoleName = "Client",
                            UpdatedDateTime = new DateTime(2024, 9, 22, 23, 56, 52, 588, DateTimeKind.Local).AddTicks(1247)
                        });
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
                            GuildId = new Guid("aa7a4518-1d3b-4df2-b453-f8bce3074abe"),
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

                    b.Property<string>("SapphireUserId")
                        .HasColumnType("text");

                    b.Property<double>("ZennyAmount")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("SapphireUserId");

                    b.ToTable("T_hunters");
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
                            Id = new Guid("a2d90682-879b-4ab7-83cd-2842c004e127"),
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
                            Id = new Guid("9b15d43d-c9c3-44b1-82b4-fee5e9c4c138"),
                            BaseAttack = 1.0,
                            BaseDefense = 1.0,
                            HealthPool = 10000.0,
                            MonsterName = "Rathian"
                        },
                        new
                        {
                            Id = new Guid("20d3d696-6657-4ed3-b513-ad0fa16ae06f"),
                            BaseAttack = 1.0,
                            BaseDefense = 1.0,
                            HealthPool = 10000.0,
                            MonsterName = "Rathalos"
                        },
                        new
                        {
                            Id = new Guid("7230468f-43d7-4278-9158-e2b552c100f2"),
                            BaseAttack = 1.0,
                            BaseDefense = 1.0,
                            HealthPool = 5000.0,
                            MonsterName = "Yian Garuga"
                        });
                });

            modelBuilder.Entity("Sapphire.Entities.Models.Quest", b =>
                {
                    b.Property<Guid>("QuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("QuestDescription")
                        .HasColumnType("text");

                    b.Property<string>("QuestTitle")
                        .HasColumnType("text");

                    b.Property<string>("SapphireClientId")
                        .HasColumnType("text");

                    b.Property<double>("ZennyReward")
                        .HasColumnType("double precision");

                    b.HasKey("QuestId");

                    b.HasIndex("SapphireClientId");

                    b.ToTable("T_quest");
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
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

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

            modelBuilder.Entity("Sapphire.Entities.Models.Character", b =>
                {
                    b.HasOne("Sapphire.Entities.Models.CharacterRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sapphire.Entities.Models.SapphireUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sapphire.Entities.Models.Hunters", b =>
                {
                    b.HasOne("Sapphire.Entities.Models.Guild", "Guild")
                        .WithMany("HunterMembers")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Sapphire.Entities.Models.SapphireUser", "SapphireUser")
                        .WithMany()
                        .HasForeignKey("SapphireUserId");

                    b.Navigation("Guild");

                    b.Navigation("SapphireUser");
                });

            modelBuilder.Entity("Sapphire.Entities.Models.Quest", b =>
                {
                    b.HasOne("Sapphire.Entities.Models.SapphireUser", "SapphireClient")
                        .WithMany()
                        .HasForeignKey("SapphireClientId");

                    b.Navigation("SapphireClient");
                });

            modelBuilder.Entity("Sapphire.Entities.Models.Guild", b =>
                {
                    b.Navigation("HunterMembers");
                });
#pragma warning restore 612, 618
        }
    }
}