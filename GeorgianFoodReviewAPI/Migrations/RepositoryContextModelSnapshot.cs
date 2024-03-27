﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace GeorgianFoodReviewAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("categoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97"),
                            Name = "Meat dishes"
                        },
                        new
                        {
                            CategoryId = new Guid("9b95349a-ebd6-4eea-a56e-c761975aac3c"),
                            Name = "Wine"
                        },
                        new
                        {
                            CategoryId = new Guid("ac0627cc-470c-4772-8d5d-9bc9f74d543a"),
                            Name = "Cheese"
                        });
                });

            modelBuilder.Entity("Entities.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6fd5d92b-420d-4d73-961f-e331428a0203"),
                            Name = "United States"
                        },
                        new
                        {
                            Id = new Guid("7a803201-2cde-40ab-92d9-64f0c3293658"),
                            Name = "Germany"
                        });
                });

            modelBuilder.Entity("Entities.Models.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FoodId");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8a852b0f-7b79-48ab-912d-e3d05602df56"),
                            Description = "Chakhokhbili is a traditional Georgian dish made with chicken simmered in a flavorful tomato-based sauce.",
                            Name = "Chakhokhbili"
                        },
                        new
                        {
                            Id = new Guid("65ccc9a6-ed7b-4527-b4bd-cb7151d9ff0f"),
                            Description = "Khinkali is a traditional Georgian dumpling known for its savory filling and unique pleated shape.",
                            Name = "Khinkali"
                        },
                        new
                        {
                            Id = new Guid("27f794a5-9aaa-46c9-bca4-10eee5f75e72"),
                            Description = "Khachapuri is a quintessential Georgian dish that has gained international acclaim for its irresistible combination of cheese-filled bread.",
                            Name = "Khachapuri"
                        });
                });

            modelBuilder.Entity("Entities.Models.FoodCategory", b =>
                {
                    b.Property<Guid>("FoodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FoodId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("FoodCategory");

                    b.HasData(
                        new
                        {
                            FoodId = new Guid("8a852b0f-7b79-48ab-912d-e3d05602df56"),
                            CategoryId = new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97")
                        },
                        new
                        {
                            FoodId = new Guid("65ccc9a6-ed7b-4527-b4bd-cb7151d9ff0f"),
                            CategoryId = new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97")
                        },
                        new
                        {
                            FoodId = new Guid("27f794a5-9aaa-46c9-bca4-10eee5f75e72"),
                            CategoryId = new Guid("ac0627cc-470c-4772-8d5d-9bc9f74d543a")
                        });
                });

            modelBuilder.Entity("Entities.Models.Review", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ReviewId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FoodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RevieweverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("rating")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("FoodId");

                    b.HasIndex("RevieweverId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            id = new Guid("8886de1e-b268-48fb-8473-ecb26efc0ac2"),
                            Description = "Absolutely stunning",
                            FoodId = new Guid("27f794a5-9aaa-46c9-bca4-10eee5f75e72"),
                            RevieweverId = new Guid("fd04a33c-72cd-4de3-ab12-da2688c575c2"),
                            Title = "Khachapuri description",
                            rating = 10.0
                        },
                        new
                        {
                            id = new Guid("9743e067-fede-46b9-9fbc-bf74cb647c61"),
                            Description = "Superb",
                            FoodId = new Guid("65ccc9a6-ed7b-4527-b4bd-cb7151d9ff0f"),
                            RevieweverId = new Guid("2d59d738-4c67-4221-87b0-afb48d04db10"),
                            Title = "Khinkali description",
                            rating = 10.0
                        });
                });

            modelBuilder.Entity("Entities.Models.Reviewever", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RevieweverId");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Reviewevers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fd04a33c-72cd-4de3-ab12-da2688c575c2"),
                            CountryId = new Guid("6fd5d92b-420d-4d73-961f-e331428a0203"),
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = new Guid("707c77e5-c93f-4156-ad70-3f59a0395c48"),
                            CountryId = new Guid("6fd5d92b-420d-4d73-961f-e331428a0203"),
                            FirstName = "Jane",
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = new Guid("2d59d738-4c67-4221-87b0-afb48d04db10"),
                            CountryId = new Guid("7a803201-2cde-40ab-92d9-64f0c3293658"),
                            FirstName = "Michael",
                            LastName = "Johnson"
                        });
                });

            modelBuilder.Entity("Entities.Models.FoodCategory", b =>
                {
                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany("FoodCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Food", "Food")
                        .WithMany("FoodCategories")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("Entities.Models.Review", b =>
                {
                    b.HasOne("Entities.Models.Food", "Food")
                        .WithMany("Reviews")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Reviewever", "Reviewever")
                        .WithMany("Reviews")
                        .HasForeignKey("RevieweverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Reviewever");
                });

            modelBuilder.Entity("Entities.Models.Reviewever", b =>
                {
                    b.HasOne("Entities.Models.Country", "Country")
                        .WithMany("Reviewevers")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("FoodCategories");
                });

            modelBuilder.Entity("Entities.Models.Country", b =>
                {
                    b.Navigation("Reviewevers");
                });

            modelBuilder.Entity("Entities.Models.Food", b =>
                {
                    b.Navigation("FoodCategories");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Entities.Models.Reviewever", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
