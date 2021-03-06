﻿// <auto-generated />
using System;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRUDelicious.Migrations
{
    [DbContext(typeof(DishContext))]
    partial class DishContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CRUDelicious.Models.Dish", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Calories");

                    b.Property<string>("ChefName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Tastiness");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("ID");

                    b.ToTable("dish");
                });
#pragma warning restore 612, 618
        }
    }
}
