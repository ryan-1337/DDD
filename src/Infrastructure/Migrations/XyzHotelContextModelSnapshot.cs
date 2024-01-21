﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(XyzHotelContext))]
    partial class XyzHotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Infrastructure.DataAccess.XyzHotel.Booking", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CHECK_IN_DATE")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CLIENT_ID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("INITIAL_PAYMENT")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("IS_CANCELLED")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IS_CONFIRMED")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("NUMBER_OF_NIGHTS")
                        .HasColumnType("int");

                    b.Property<string>("ROOMID")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("TOTAL_AMOUNT")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("ID");

                    b.HasIndex("ROOMID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.XyzHotel.Client", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FULLNAME")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PHONENUMBER")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.XyzHotel.Payment", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("AMOUNT")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ClientID")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("TIMESTAMP")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.XyzHotel.Room", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OPTIONS")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PRICE_PER_NIGHT")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("ID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.XyzHotel.Booking", b =>
                {
                    b.HasOne("Infrastructure.DataAccess.XyzHotel.Room", "ROOM")
                        .WithMany()
                        .HasForeignKey("ROOMID");

                    b.Navigation("ROOM");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.XyzHotel.Payment", b =>
                {
                    b.HasOne("Infrastructure.DataAccess.XyzHotel.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
