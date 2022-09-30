// See https://aka.ms/new-console-template for more information
using csharp_ecommerce_db;
//using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");

ECommerceContext db = new();


void addNewCustomer()
{
    Console.WriteLine("Inserisci il nome");
    string name = Console.ReadLine();
    Console.WriteLine("Inserisci il Cognome");
    string surname = Console.ReadLine();
    Console.WriteLine("Inserisci l'email");
    string email = Console.ReadLine();
    bool check = false;

    while (!check)
    {
        try
        {
            Customer newCustomer = new() { Name = name, Surname = surname, Email = email };
            db.Add(newCustomer);
            db.SaveChanges();
            check = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            check = false;
        }
    }
    string output = check ? "Inserimento avvenuto correttamente" : "";
    Console.WriteLine(output);
}

void addNewEmployee()
{
    Console.WriteLine("Inserisci il nome");
    string? name = Console.ReadLine();
    Console.WriteLine("Inserisci il Cognome");
    string? surname = Console.ReadLine();
    Console.WriteLine("Inserisci il livello");
    string? level = Console.ReadLine();
    bool check = false;

    while (!check)
    {
        try
        {
            Employee newEmployee = new() { Name = name, Surname = surname, Level = level };
            db.Add(newEmployee);
            db.SaveChanges();
            check = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            check = false;
        }
    }
    string output = check ? "Inserimento avvenuto correttamente" : "";
    Console.WriteLine(output);
}

void addNewProduct()
{
    Console.WriteLine("Inserisci il nome prodotto");
    string? name = Console.ReadLine();
    Console.WriteLine("Inserisci il Cognome");
    string? description = Console.ReadLine();
    Console.WriteLine("Inserisci il livello");
    float? price = Convert.ToSingle(Console.ReadLine());
    bool check = false;

    while (!check)
    {
        try
        {
            Product newProduct = new() { Name = name, Description = description, Price = price , Quantity = 0};
            db.Add(newProduct);
            db.SaveChanges();
            check = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            check = false;
        }
    }
    string output = check ? "Inserimento avvenuto correttamente" : "";
    Console.WriteLine(output);
}








