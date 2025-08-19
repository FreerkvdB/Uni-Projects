using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281
{
    internal class Inventory : Product, IInventory
    {
        // List to hold the products in the inventory
        private List<Product> products = new List<Product>();

        public delegate void LowStockHandler(Product product);
        public event LowStockHandler OnLowStock;


        // Method to add a product to the inventory
        public void AddProduct(Product product)
        {
            try
            {
                // Use Any() with a lambda to check for duplicates
                if (products.Exists(p => p.ProductId == product.ProductId)) // Duplicate check found a matching ID
                {
                    throw new InvalidOperationException($"Product with ID {product.ProductId} already exists in the inventory.");
                }

                products.Add(product);
                Console.WriteLine($"Product {product.ProductName} with ID: {product.ProductId} added to inventory");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the product: {ex.Message}");
            }
        }

        // Method to display all products in the inventory
        public void DisplayProducts()
        {
            Console.WriteLine("Inventory: ");
            string Output = "";
            Output += ("Product ID:\t Name:\t Price:\t Quantity: \n");
            string[] parts = Output.Split('\t');
            Console.WriteLine($"{parts[0],-15} {parts[1],-20} {parts[2],-10} {parts[3],-10}");
            foreach (var product in products)
            {
                Output = "";
                Output +=($" {product.ProductId}\t {product.ProductName}\t {product.Price}\t {product.Quantity}");
                parts = Output.Split('\t');
                Console.WriteLine($"{parts[0],-15} {parts[1],-20} {parts[2],-10} {parts[3],-10}");
            }
        }

        // Method to remove a product from the inventory
        public void RemoveProduct(string productId)
        {

            try
            {
                Product productToRemove = FindProduct(productId);
                if (productToRemove == null)
                {
                    throw new KeyNotFoundException($"Product {productId} not found in the inventory."); //input should be the name of variable of input
                }

                products.Remove(productToRemove);
                Console.WriteLine($"Product {productToRemove.ProductName} with ID: {productToRemove.ProductId} removed from inventory");

            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while removing the product: {ex.Message}");
            }
        }

        // Method to find a product by its ID or Name
        public Product FindProduct(string input)
        {

            //return products.FirstOrDefault(p => p.ProductId.Equals(input) || p.ProductName.Equals(input, StringComparison.OrdinalIgnoreCase)); 
            foreach (var p in products)
            {
                if (p.ProductId.Equals(input))
                {
                    return p; // Found by ID
                }
                if (p.ProductName.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    return p; // Found by Name
                }
            }
            return null; //Not found
        }

        // Method to update the quantity of a product in the inventory
        public void UpdateProductQuantity(string productId, int newQuantity)
        {
            try
            {
                Product productToUpdate = FindProduct(productId);

                if (productToUpdate == null)
                {
                    throw new KeyNotFoundException($"Product {productId} not found in the inventory.");
                }

                productToUpdate.Quantity = newQuantity;
                Console.WriteLine($"Inventory updated: {productToUpdate.ProductName}, {newQuantity}");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the product quantity: {ex.Message}");
            }

        }
        
        public void DisplayProduct(string productId)
        {
            Product product = FindProduct(productId);
            if (product != null)
            {
                Console.WriteLine($"Product ID: {product.ProductId}");
                Console.WriteLine($"Name: {product.ProductName}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Quantity: {product.Quantity}");
                Console.WriteLine($"Low Stock Threshold: {product.LowStockThreshold}");
            }
            else
            {
                Console.WriteLine($"Product with ID {productId} not found.");
            }
        }

        public List<Product> GetProducts()
        {
            return (List<Product>)products;
        }

        public void NotifyLowStock(Product product)
        {
            OnLowStock?.Invoke(product);
        }

        // Method to update the price of a product in the inventory
        public void UpdateProductPrice(string productId, double newPrice)
        {
            try
            {
                Product productToUpdate = FindProduct(productId);
                if (productToUpdate == null)
                {
                    throw new KeyNotFoundException($"Product {productId} not found in the inventory.");
                }
                productToUpdate.Price = newPrice;
                Console.WriteLine($"Inventory updated: {productToUpdate.ProductName}, {newPrice}");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the product price: {ex.Message}");
            }
        }

        // Method to update the low stock threshold of a product in the inventory
        public void UpdateProductLowStockThreshold(string productId, int newLowStockThreshold)
        {
            try
            {
                Product productToUpdate = FindProduct(productId);
                if (productToUpdate == null)
                {
                    throw new KeyNotFoundException($"Product {productId} not found in the inventory.");
                }
                productToUpdate.LowStockThreshold = newLowStockThreshold;
                Console.WriteLine($"Inventory updated: {productToUpdate.ProductName}, Low Stock Threshold: {newLowStockThreshold}");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the product low stock threshold: {ex.Message}");
            }
        }
    }
}
