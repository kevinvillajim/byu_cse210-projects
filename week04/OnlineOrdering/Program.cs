class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Av.", "Miami", "FL", "USA");
        Customer customer1 = new Customer("John Wick", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Business Suit", "L123", 1000, 3));
        order1.AddProduct(new Product("Bullets", "M456", 30, 4));

        Console.WriteLine(order1.GeneratePackingLabel());
        Console.WriteLine(order1.GenerateShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotal()}");
    }
}