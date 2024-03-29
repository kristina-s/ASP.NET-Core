﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaApp.Models.ViewModels;

namespace PizzaApp.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    partial class PizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaApp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("LastName");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("PizzaApp.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("OrderAddress");

                    b.Property<string>("OrderCity");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderName");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PizzaApp.Models.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Discount");

                    b.Property<int>("OrderId");

                    b.Property<int>("PizzaId");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("PizzaApp.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("PizzaTypeId");

                    b.Property<decimal>("Price");

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.HasIndex("PizzaTypeId");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("PizzaApp.Models.PizzaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.ToTable("PizzaType");

                    b.HasData(
                        new { Id = 1, Description = "dough, ham, mashrums", Name = "Capri" },
                        new { Id = 2, Description = "dough, cheese, mashrums", Name = "Quatro" },
                        new { Id = 3, Description = "dough, vegetables, mashrums", Name = "Vege" }
                    );
                });

            modelBuilder.Entity("PizzaApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PizzaApp.Models.Order", b =>
                {
                    b.HasOne("PizzaApp.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("PizzaApp.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PizzaApp.Models.OrderDetails", b =>
                {
                    b.HasOne("PizzaApp.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PizzaApp.Models.Pizza", "Pizza")
                        .WithMany("OrderDetails")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PizzaApp.Models.Pizza", b =>
                {
                    b.HasOne("PizzaApp.Models.PizzaType", "PizzaType")
                        .WithMany("Pizzas")
                        .HasForeignKey("PizzaTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
