﻿// <auto-generated />
using Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Deposit_Deduction")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsAllowedToWithdraw")
                        .HasColumnType("bit");

                    b.Property<decimal>("Min_Deposit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Min_Withdraw")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Withdraw_Deduction")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Countrys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deposit_Deduction = 10m,
                            IsAllowedToWithdraw = false,
                            Min_Deposit = 0m,
                            Min_Withdraw = 0m,
                            Name = "Germany",
                            Withdraw_Deduction = 0m
                        },
                        new
                        {
                            Id = 2,
                            Deposit_Deduction = 0m,
                            IsAllowedToWithdraw = true,
                            Min_Deposit = 0m,
                            Min_Withdraw = 10m,
                            Name = "United Kingdom",
                            Withdraw_Deduction = 0m
                        });
                });

            modelBuilder.Entity("Backend.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 0m,
                            CountryId = 1,
                            Name = "German User"
                        },
                        new
                        {
                            Id = 2,
                            Balance = 0m,
                            CountryId = 2,
                            Name = "UK User"
                        });
                });

            modelBuilder.Entity("Backend.Models.Transaction", b =>
                {
                    b.HasOne("Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.HasOne("Backend.Models.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Backend.Models.Country", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}