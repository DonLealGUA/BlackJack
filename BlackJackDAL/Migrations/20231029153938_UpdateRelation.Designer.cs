﻿// <auto-generated />
using BlackJackDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlackJackDAL.Migrations
{
    [DbContext(typeof(GameDBContext))]
    [Migration("20231029153938_UpdateRelation")]
    partial class UpdateRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlackJackEL.CardEntity", b =>
                {
                    b.Property<int>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardID"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Suit")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("CardID");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("BlackJackEL.GameCardEntity", b =>
                {
                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.Property<int>("CardID")
                        .HasColumnType("int");

                    b.HasKey("GameID", "PlayerID", "CardID");

                    b.HasIndex("CardID");

                    b.HasIndex("PlayerID");

                    b.ToTable("GameCards");
                });

            modelBuilder.Entity("BlackJackEL.PlayerEntity", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerID"));

                    b.Property<bool>("IsDealer")
                        .HasColumnType("bit");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Winner")
                        .HasColumnType("bit");

                    b.HasKey("PlayerID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BlackJackEL.GameCardEntity", b =>
                {
                    b.HasOne("BlackJackEL.CardEntity", "Card")
                        .WithMany("GameCards")
                        .HasForeignKey("CardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlackJackEL.PlayerEntity", "Player")
                        .WithMany("GameCards")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BlackJackEL.CardEntity", b =>
                {
                    b.Navigation("GameCards");
                });

            modelBuilder.Entity("BlackJackEL.PlayerEntity", b =>
                {
                    b.Navigation("GameCards");
                });
#pragma warning restore 612, 618
        }
    }
}
