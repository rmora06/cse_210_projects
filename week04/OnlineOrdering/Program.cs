using System;

class Program
{
    static void Main()
    {
        // Client 1 (USA)
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25.50, 2));

        // Client 2 (Internacional)
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Carlos Rivera", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Tablet", "P003", 450.00, 1));
        order2.AddProduct(new Product("Stylus Pen", "P004", 30.00, 3));

        // Show results
        DisplayOrder(order1);
        Console.WriteLine(new string('-', 40));
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
    }
}