﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolos2.Conext;

#nullable disable

namespace kolos2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240611141713_migracja3")]
    partial class migracja3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("kolos2.Models.BackpackSlot", b =>
                {
                    b.Property<int>("BackpackSlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BackpackSlotId"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("int")
                        .HasColumnName("FK_character");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("FK_item");

                    b.HasKey("BackpackSlotId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("ItemId");

                    b.ToTable("Backpack_Slots");

                    b.HasData(
                        new
                        {
                            BackpackSlotId = 1,
                            CharacterId = 1,
                            ItemId = 1
                        });
                });

            modelBuilder.Entity("kolos2.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"));

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int")
                        .HasColumnName("current_weig");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int")
                        .HasColumnName("max_weight");

                    b.Property<int>("Money")
                        .HasColumnType("int")
                        .HasColumnName("money");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            CurrentWeight = 1,
                            FirstName = "Test",
                            LastName = "Test",
                            MaxWeight = 3,
                            Money = 1
                        });
                });

            modelBuilder.Entity("kolos2.Models.CharacterTitle", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int")
                        .HasColumnName("FK_charact");

                    b.Property<int>("TitleId")
                        .HasColumnType("int")
                        .HasColumnName("FK_title");

                    b.Property<DateTime>("AquireAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("aquire_at");

                    b.HasKey("CharacterId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("Character_Titles");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            TitleId = 1,
                            AquireAt = new DateTime(2024, 6, 11, 16, 17, 13, 200, DateTimeKind.Local).AddTicks(3482)
                        });
                });

            modelBuilder.Entity("kolos2.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<int>("Weight")
                        .HasColumnType("int")
                        .HasColumnName("Weig");

                    b.HasKey("ItemId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Name = "Test",
                            Weight = 1
                        });
                });

            modelBuilder.Entity("kolos2.Models.Title", b =>
                {
                    b.Property<int>("TitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TitleId"));

                    b.Property<string>("Nam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nam");

                    b.HasKey("TitleId");

                    b.ToTable("Titles");

                    b.HasData(
                        new
                        {
                            TitleId = 1,
                            Nam = "Test"
                        });
                });

            modelBuilder.Entity("kolos2.Models.BackpackSlot", b =>
                {
                    b.HasOne("kolos2.Models.Character", "Character")
                        .WithMany("BackpackSlots")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kolos2.Models.Item", "Item")
                        .WithMany("BackpackSlots")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("kolos2.Models.CharacterTitle", b =>
                {
                    b.HasOne("kolos2.Models.Character", "Character")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kolos2.Models.Title", "Title")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("kolos2.Models.Character", b =>
                {
                    b.Navigation("BackpackSlots");

                    b.Navigation("CharacterTitles");
                });

            modelBuilder.Entity("kolos2.Models.Item", b =>
                {
                    b.Navigation("BackpackSlots");
                });

            modelBuilder.Entity("kolos2.Models.Title", b =>
                {
                    b.Navigation("CharacterTitles");
                });
#pragma warning restore 612, 618
        }
    }
}
