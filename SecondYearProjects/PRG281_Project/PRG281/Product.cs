using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281
{
    internal class Product : IComparable<Product>
    {
        // Declaring all the fields for the Product class
        private string productName;
        private double price;
        private int quantity;
        private int lowStockThreshold;
        private string productId;

        // Default constructor to initialize the fields
        public Product()
        {
           
        }

        // Parameterized constructor to initialize the fields
        public Product(string productId, string productName, double price, int quantity, int lowStockThreshold)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
            this.Quantity = quantity;
            this.LowStockThreshold = lowStockThreshold;
        }

        //Properties to encapsulate the fields
        public string ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int LowStockThreshold { get => lowStockThreshold; set => lowStockThreshold = value; }

      
        // Method to get the details of the product
        public void GetProductDetails()
        {
            Console.WriteLine("Enter the product ID: ");
            ProductId = Console.ReadLine();
            Console.WriteLine("Enter the product Name: ");
            ProductName = Console.ReadLine();
            Console.WriteLine("Enter the product price: ");
            Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the quantity of the product: ");
            Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Set a low stock threshold for the product: ");
            LowStockThreshold = int.Parse(Console.ReadLine());
        }

        // Method to compare two products based on their ID
        public int CompareTo(Product other)
        {
            if (other == null) return 1; // Null check
            return this.ProductId.CompareTo(other.ProductId);
        }
    }
}
