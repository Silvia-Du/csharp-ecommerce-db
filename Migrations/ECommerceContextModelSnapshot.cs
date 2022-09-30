﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace csharp_ecommerce_db.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    partial class ECommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("csharp_ecommerce_db.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("surname");

                    b.HasKey("CustomerId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[email] IS NOT NULL");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("level");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("surname");

                    b.HasKey("EmployeeId");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<float>("Ammount")
                        .HasColumnType("real")
                        .HasColumnName("ammount");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<float>("Ammount")
                        .HasColumnType("real")
                        .HasColumnName("ammount");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("oreder_id");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId");

                    b.ToTable("payment");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<float?>("Price")
                        .HasColumnType("real")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrderListOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductListProductId")
                        .HasColumnType("int");

                    b.HasKey("OrderListOrderId", "ProductListProductId");

                    b.HasIndex("ProductListProductId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Order", b =>
                {
                    b.HasOne("csharp_ecommerce_db.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("csharp_ecommerce_db.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Payment", b =>
                {
                    b.HasOne("csharp_ecommerce_db.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("csharp_ecommerce_db.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderListOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("csharp_ecommerce_db.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductListProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("csharp_ecommerce_db.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Order", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}