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
    [Migration("20240914084611_AddQuestTable")]
    partial class AddQuestTable
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
                            Id = "4a04cce1-42ab-470c-86d5-5de6f5265315",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "42496df6-ef43-4470-88ef-a0eca0d38386",
                            Name = "Hunter",
                            NormalizedName = "HUNTER"
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
                            GuildId = new Guid("a08f5e5e-3708-4ff6-9d3a-625b50538957"),
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("0802234b-a35c-4e3d-9ca1-1864e1eb1902"),
                            HunterName = "Shard",
                            Rank = 1,
                            ZennyAmount = 5000.0
                        },
                        new
                        {
                            Id = new Guid("81e0e2cb-1e1b-4a0b-a22a-7b189807cc65"),
                            HunterName = "DarkShard",
                            Rank = 1,
                            ZennyAmount = 5000.0
                        },
                        new
                        {
                            Id = new Guid("e32db408-4f3d-4737-b7b2-929445702bc9"),
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
                            Id = new Guid("09624731-26cf-4173-8208-b6c392018b63"),
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
                            Id = new Guid("743de06d-4332-442c-b338-8385acb7a2bf"),
                            BaseAttack = 1.0,
                            BaseDefense = 1.0,
                            HealthPool = 10000.0,
                            MonsterName = "Rathian"
                        },
                        new
                        {
                            Id = new Guid("48662d72-f763-473a-beca-ba9288c72378"),
                            BaseAttack = 1.0,
                            BaseDefense = 1.0,
                            HealthPool = 10000.0,
                            MonsterName = "Rathalos"
                        },
                        new
                        {
                            Id = new Guid("2bcc6bde-fba9-459b-b5e8-f74619049afe"),
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
