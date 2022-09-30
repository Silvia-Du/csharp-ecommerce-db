// See https://aka.ms/new-console-template for more information
using csharp_ecommerce_db;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");

ECommerceContext db = new();
//Product product1 = new() { Name = "patatine", Description = "buonissime e croccanti", Price = 2.33F, Quantity = 0 };

Customer customer1 = new () { Name = "Dudi", Surname = "Dudidu", Email = "dudi@dudidu.it" };
Customer customer2 = new() { Name = "Ugo", Surname = "Deughi", Email = "ugo@gmail.icom" };

Employee employee1 = new() { Name = "margherita", Surname = "Marghe", Level= "Primo" };
Employee employee2 = new() { Name = "Dan", Surname = "Dindi", Level = "Secondo" };

db.Add(customer1);
db.Add(customer2);
db.Add(employee1);
db.Add(employee2);
db.SaveChanges();








