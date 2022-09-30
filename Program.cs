// See https://aka.ms/new-console-template for more information
using csharp_ecommerce_db;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http.Headers;



ECommerceContext db = new();

void setNewOrder(List<Product> products, Customer customer, Employee employee)
{
    Order order = new();
    order.ProductList = products;
    order.Date = DateTime.UtcNow; 
    order.Ammount = getTotalPrice(products);
    order.Status = "in process";
    order.Customer = customer;
    order.Employee = employee;


}

List<Payment> setPayment(float ammount, Order order)
{
    List<Payment> result = new();
    Payment payment = new();
    payment.Date = DateTime.UtcNow;
    payment.Ammount = ammount;
    //creo un'azione randomica per creare o meno uno o piu tentativi di pagamento
    int random = new Random().Next(0, 1);
    switch (random)
    {
        case 0: payment.Status = "non processato";
            payment.Order = order;
            db.Add(payment);
            db.SaveChanges();
            result.Add(payment);
            Payment payment2 = new() { Date = DateTime.UtcNow, Ammount = ammount, Status = "a buon fine", Order = order };
            db.Add(payment2);
            db.SaveChanges();
            result.Add(payment2);

            break;
        case 1: payment.Status = "a buon fine";
            payment.Order = order;
            db.Add(payment);
            db.SaveChanges();
            result.Add(payment);
            break;
    }

    return result;
}

float getTotalPrice(List<Product> products)
{
    float total =0;
    foreach (Product product in products)
    {
        total += (float)product.Price;
    }
    return total;
}

Customer getCustomerId(string email)
{
    Customer customer = db.Customers.Where(customer => customer.Email == email).First();    
    return customer;
}
Employee getEmployeeId(string surname)
{
    Employee employee = db.Employees.Where(employee => employee.Surname == surname).First();
    return employee;
}



void printProductList()
{
    //method sintax
    //List<Product> products = db.Products.OrderBy(product => product.Name).ToList<Product>();
    //query sintax
    List<Product> products = (
        from p in db.Products
        orderby p.Name
        select p).ToList<Product>();
    foreach (Product product in products)
    {
        Console.WriteLine($"nome: {product.Name}, prezzo: {product.Price}, descrizione: {product.Description}");
    }
}


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








