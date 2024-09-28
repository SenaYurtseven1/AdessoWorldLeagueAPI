﻿// <auto-generated />
using System;
using AdessoWorldLeagueAPI.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdessoWorldLeagueAPI.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240928164603_AddedNewColumn")]
    partial class AddedNewColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdessoWorldLeagueAPI.Domain.Models.AdessoGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdessoGroups");
                });

            modelBuilder.Entity("AdessoWorldLeagueAPI.Domain.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("AdessoWorldLeagueAPI.Domain.Models.Draw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DrawDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DrawnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrawnSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeamId");

                    b.ToTable("Draw");
                });

            modelBuilder.Entity("AdessoWorldLeagueAPI.Domain.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("GroupId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("AdessoWorldLeagueAPI.Domain.Models.Draw", b =>
                {
                    b.HasOne("AdessoWorldLeagueAPI.Domain.Models.AdessoGroup", "Group")
                        .WithMany("Draws")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdessoWorldLeagueAPI.Domain.Models.Team", "Team")
                        .WithMany("Draws")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("AdessoWorldLeagueAPI.Domain.Models.Team", b =>
                {
                    b.HasOne("AdessoWorldLeagueAPI.Domain.Models.Country", "Country")
                        .WithMany("Teams")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdessoWorldLeagueAPI.Domain.Models.AdessoGroup", "AdessoGroup")
                        .WithMany("Teams")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("AdessoGroup");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AdessoWorldLeagueAPI.Domain.Models.AdessoGroup", b =>
                {
                    b.Navigation("Draws");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("AdessoWorldLeagueAPI.Domain.Models.Country", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("AdessoWorldLeagueAPI.Domain.Models.Team", b =>
                {
                    b.Navigation("Draws");
                });
#pragma warning restore 612, 618
        }
    }
}
