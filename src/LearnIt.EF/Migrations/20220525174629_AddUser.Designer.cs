﻿// <auto-generated />
using System;
using LearnIt.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearnIt.EF.Migrations
{
    [DbContext(typeof(LIContext))]
    [Migration("20220525174629_AddUser")]
    partial class AddUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LearnIt.Domain.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LearnIt.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("LearnIt.Domain.UserCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCategory");
                });

            modelBuilder.Entity("LearnIt.Domain.UserWord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("WordId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WordId");

                    b.ToTable("UserWord");
                });

            modelBuilder.Entity("LearnIt.Domain.Word", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("OriginalText")
                        .HasColumnType("text");

                    b.Property<string>("TranslatedText")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("LearnIt.Domain.UserCategory", b =>
                {
                    b.HasOne("LearnIt.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("LearnIt.Domain.User", "User")
                        .WithMany("SelectedCategories")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearnIt.Domain.UserWord", b =>
                {
                    b.HasOne("LearnIt.Domain.User", "User")
                        .WithMany("LearnedWords")
                        .HasForeignKey("UserId");

                    b.HasOne("LearnIt.Domain.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordId");

                    b.Navigation("User");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("LearnIt.Domain.Word", b =>
                {
                    b.HasOne("LearnIt.Domain.Category", "Category")
                        .WithMany("Words")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LearnIt.Domain.Category", b =>
                {
                    b.Navigation("Words");
                });

            modelBuilder.Entity("LearnIt.Domain.User", b =>
                {
                    b.Navigation("LearnedWords");

                    b.Navigation("SelectedCategories");
                });
#pragma warning restore 612, 618
        }
    }
}