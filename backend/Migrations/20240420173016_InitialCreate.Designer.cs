﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(SearchingContext))]
    [Migration("20240420173016_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("MetroArea", b =>
                {
                    b.Property<int>("MetroAreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MetroAreaStateAbr")
                        .HasColumnType("TEXT");

                    b.Property<string>("MetroAreaStateName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MetroAreaTitle")
                        .HasColumnType("TEXT");

                    b.HasKey("MetroAreaId");

                    b.ToTable("MetroAreas");

                    b.HasData(
                        new
                        {
                            MetroAreaId = 1006,
                            MetroAreaStateAbr = "VA",
                            MetroAreaStateName = "Virginia",
                            MetroAreaTitle = "Richmond"
                        },
                        new
                        {
                            MetroAreaId = 1007,
                            MetroAreaStateAbr = "GA",
                            MetroAreaStateName = "Georgia",
                            MetroAreaTitle = "Atlanta"
                        },
                        new
                        {
                            MetroAreaId = 1008,
                            MetroAreaStateAbr = "SC",
                            MetroAreaStateName = "South Carolina",
                            MetroAreaTitle = "Charleston"
                        });
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectName")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId", "ProjectGroupId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = "Y58",
                            ProjectGroupId = 23,
                            ProductName = "The Prescot",
                            ProjectName = "Edgewater"
                        },
                        new
                        {
                            ProductId = "980",
                            ProjectGroupId = 23,
                            ProductName = "The Davis",
                            ProjectName = "Edgewater 50"
                        },
                        new
                        {
                            ProductId = "E15",
                            ProjectGroupId = 23,
                            ProductName = "The Amelia",
                            ProjectName = "Edgewater 50"
                        },
                        new
                        {
                            ProductId = "Y54",
                            ProjectGroupId = 23,
                            ProductName = "The Lockwood",
                            ProjectName = "Edgewater 50"
                        },
                        new
                        {
                            ProductId = "U68",
                            ProjectGroupId = 41,
                            ProductName = "The Stono",
                            ProjectName = "Estuary"
                        },
                        new
                        {
                            ProductId = "1601",
                            ProjectGroupId = 41,
                            ProductName = "The Moultrie",
                            ProjectName = "Estuary"
                        },
                        new
                        {
                            ProductId = "980",
                            ProjectGroupId = 25,
                            ProductName = "The Dupree",
                            ProjectName = "Inwood SFD"
                        },
                        new
                        {
                            ProductId = "E15",
                            ProjectGroupId = 25,
                            ProductName = "Inwood",
                            ProjectName = "Inwood SFD"
                        },
                        new
                        {
                            ProductId = "1674",
                            ProjectGroupId = 43,
                            ProductName = "The Stella",
                            ProjectName = "Mixson"
                        },
                        new
                        {
                            ProductId = "1665",
                            ProjectGroupId = 47,
                            ProductName = "The Tidalview",
                            ProjectName = "Oldfield"
                        });
                });

            modelBuilder.Entity("ProjectGroup", b =>
                {
                    b.Property<int>("ProjectGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<int>("MetroAreaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("ProjectGroupId");

                    b.ToTable("ProjectGroups");

                    b.HasData(
                        new
                        {
                            ProjectGroupId = 23,
                            FullName = "Edgewater",
                            MetroAreaId = 1007,
                            Status = "a"
                        },
                        new
                        {
                            ProjectGroupId = 25,
                            FullName = "Inwood",
                            MetroAreaId = 1007,
                            Status = "a"
                        },
                        new
                        {
                            ProjectGroupId = 41,
                            FullName = "Estuary at Bowen Village",
                            MetroAreaId = 1008,
                            Status = "a"
                        },
                        new
                        {
                            ProjectGroupId = 43,
                            FullName = "Mixson",
                            MetroAreaId = 1008,
                            Status = "i"
                        },
                        new
                        {
                            ProjectGroupId = 47,
                            FullName = "Oldfield",
                            MetroAreaId = 1008,
                            Status = "a"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
