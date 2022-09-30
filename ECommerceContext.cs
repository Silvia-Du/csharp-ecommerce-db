﻿// See https://aka.ms/new-console-template for more information
using csharp_ecommerce_db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class ECommerceContext : DbContext
{
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Payment>? Payments { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_ecommerce;Integrated Security=True");
    }

}

