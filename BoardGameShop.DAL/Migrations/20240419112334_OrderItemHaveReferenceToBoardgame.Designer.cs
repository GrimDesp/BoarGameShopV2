﻿// <auto-generated />
using System;
using BoardGameShop.DAL.EFStructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardGameShop.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240419112334_OrderItemHaveReferenceToBoardgame")]
    partial class OrderItemHaveReferenceToBoardgame
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("TimeSpam")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("TimeSpam")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Boardgame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte?>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<byte?>("Discount")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("FullPrice")
                        .HasPrecision(20, 2)
                        .HasColumnType("decimal(20,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MaxPlayTime")
                        .HasColumnType("int");

                    b.Property<byte?>("MaxPlayer")
                        .HasColumnType("tinyint");

                    b.Property<int?>("MinPlayTime")
                        .HasColumnType("int");

                    b.Property<byte?>("MinPlayer")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeSpam")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.HasIndex("VendorId");

                    b.ToTable("BoardGames", (string)null);
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.BoardgameToArtist", b =>
                {
                    b.Property<int>("BoardgameId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.HasKey("BoardgameId", "ArtistId");

                    b.HasIndex("ArtistId");

                    b.ToTable("BoardgameToArtist");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.BoardgameToAuthor", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BoardgameId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "BoardgameId");

                    b.HasIndex("BoardgameId");

                    b.ToTable("BoardgameToAuthor");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.BoardgameToCategory", b =>
                {
                    b.Property<int>("BoardgameId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("BoardgameId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BoardgameToCategory");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.BoardgameToMechanic", b =>
                {
                    b.Property<int>("MechanicId")
                        .HasColumnType("int");

                    b.Property<int>("BoardgameId")
                        .HasColumnType("int");

                    b.HasKey("MechanicId", "BoardgameId");

                    b.HasIndex("BoardgameId");

                    b.ToTable("BoardgameToMechanic");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte[]>("TimeSpam")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte[]>("TimeSpam")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageFromUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Secondname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeSpam")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VendorId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("ItemCost")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("TimeSpam")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SecondName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("TimeSpam")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeSpam")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Boardgame", b =>
                {
                    b.HasOne("BoardGameShop.DAL.Entities.Publisher", "PublisherNavigation")
                        .WithMany("BoardGames")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameShop.DAL.Entities.Vendor", "VendorNavigation")
                        .WithMany("Boardgames")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PublisherNavigation");

                    b.Navigation("VendorNavigation");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.BoardgameToArtist", b =>
                {
                    b.HasOne("BoardGameShop.DAL.Entities.Artist", "ArtistNavigation")
                        .WithMany("BoardgameArtists")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameShop.DAL.Entities.Boardgame", "BoardgameNavigation")
                        .WithMany("BoardgameArtists")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArtistNavigation");

                    b.Navigation("BoardgameNavigation");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.BoardgameToAuthor", b =>
                {
                    b.HasOne("BoardGameShop.DAL.Entities.Author", "AuthorNavigation")
                        .WithMany("BoardgameToAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameShop.DAL.Entities.Boardgame", "BoardgameNavigation")
                        .WithMany("BoardgameAuthors")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorNavigation");

                    b.Navigation("BoardgameNavigation");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.BoardgameToCategory", b =>
                {
                    b.HasOne("BoardGameShop.DAL.Entities.Boardgame", "BoardgameNavigation")
                        .WithMany("BoardgameCategories")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameShop.DAL.Entities.Category", "CategoryNavigation")
                        .WithMany("BoardgameCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardgameNavigation");

                    b.Navigation("CategoryNavigation");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.BoardgameToMechanic", b =>
                {
                    b.HasOne("BoardGameShop.DAL.Entities.Boardgame", "BoardgameNavigation")
                        .WithMany("BoardgameMechanics")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameShop.DAL.Entities.Mechanic", "MechanicNavigation")
                        .WithMany("BoardgameMechanics")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardgameNavigation");

                    b.Navigation("MechanicNavigation");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Order", b =>
                {
                    b.HasOne("BoardGameShop.DAL.Entities.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameShop.DAL.Entities.Vendor", "VendorNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VendorNavigation");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.OrderItem", b =>
                {
                    b.HasOne("BoardGameShop.DAL.Entities.Boardgame", "BoardgameNavigation")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BoardGameShop.DAL.Entities.Order", "OrderNavigation")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardgameNavigation");

                    b.Navigation("OrderNavigation");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Artist", b =>
                {
                    b.Navigation("BoardgameArtists");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Author", b =>
                {
                    b.Navigation("BoardgameToAuthors");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Boardgame", b =>
                {
                    b.Navigation("BoardgameArtists");

                    b.Navigation("BoardgameAuthors");

                    b.Navigation("BoardgameCategories");

                    b.Navigation("BoardgameMechanics");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Category", b =>
                {
                    b.Navigation("BoardgameCategories");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Mechanic", b =>
                {
                    b.Navigation("BoardgameMechanics");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Publisher", b =>
                {
                    b.Navigation("BoardGames");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BoardGameShop.DAL.Entities.Vendor", b =>
                {
                    b.Navigation("Boardgames");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
