using ConsoleAppDB.Services;

namespace ConsoleAppDB;

internal class ConsoleMenu
{
    private readonly ProductService _productService;
    private readonly CustomerService _customerService;

    public ConsoleMenu(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    public void ConsoleMenuChoice()
    {
        while (true)

        {
            // allternativ för användaren att välja mellan
            Console.WriteLine("###### Welcome to you're console application ######\n");
            Console.WriteLine("### Option 1-4 is about products ###");
            Console.WriteLine("1. Press to create a product");
            Console.WriteLine("2. Show all products");
            Console.WriteLine("3. Update a Product");
            Console.WriteLine("4. Delete a product\n");
            Console.WriteLine("### Option 5-8 is about customer ###");
            Console.WriteLine("5. Press to create a customer");
            Console.WriteLine("6. Show all customers");
            Console.WriteLine("7. Update a customer");
            Console.WriteLine("8. Delete a customer");
            Console.WriteLine("9. Avsluta Programmet");
            Console.Write("Välj ett alternativ: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Product Title: ");
                    var title = Console.ReadLine();

                    Console.Write("Product Price: ");
                    var price = decimal.Parse(Console.ReadLine()!);

                    Console.Write("Product Category: ");
                    var categoryName = Console.ReadLine();

                    Console.Write("Product Manufacture: ");
                    var manufactureName = Console.ReadLine();

                    var resultCustomerOne = _productService.CreateProduct(title!, price, categoryName!, manufactureName!);
                    if (resultCustomerOne != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Product has been created\n");
                        Console.ReadKey();
                    }

                    break;

                case "2":

                    Console.Clear();
                    var products = _productService.GetProducts();
                    foreach(var product in products)
                    {
                        Console.WriteLine($"{product.Title} - {product.Category.CategoryName} - {product.Manufacture.ManufactureName} ({product.Price} SEK)");
                    }
                    Console.ReadKey();
                    break;
                    
                case "3":
                    Console.Clear();
                    Console.Write("Enter a product Title: ");
                    var titleName = Console.ReadLine();

                    var updateproduct = _productService.GetProductByTitle(titleName!);
                    if (updateproduct != null)
                    {
                        Console.WriteLine($"{updateproduct.Title} - {updateproduct.Category.CategoryName} - {updateproduct.Manufacture.ManufactureName} ({updateproduct.Price} SEK)");
                        Console.WriteLine();

                        Console.Write("New Product Title: ");
                        updateproduct.Title = Console.ReadLine()!;

                        var newProduct = _productService.UpdateProduct(updateproduct);
                        Console.WriteLine($"{updateproduct.Title} - {updateproduct.Category.CategoryName} - {updateproduct.Manufacture.ManufactureName} ({updateproduct.Price} SEK)");
                    }
                    else
                    {
                        Console.WriteLine("No product was found.");
                    }
                    Console.ReadKey ();
                    break;

                case "4":
                    Console.Clear();
                    Console.Write("Enter a product Id: ");
                    var id = int.Parse(Console.ReadLine()!);

                    var deleteproduct = _productService.GetProductById(id);
                    if (deleteproduct != null)
                    {
                        _productService.DeleteProduct(deleteproduct.Id);
                        Console.WriteLine("Product was deleted");
                    }
                    else
                    {
                        Console.WriteLine("No product was found.");
                    }
                    Console.ReadKey();
                    break;

                
            }
        }
    }
}
