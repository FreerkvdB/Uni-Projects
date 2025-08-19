using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281
{
    internal class Program
    {
        public enum MenuOption
        {
            AddProduct = 1,
            RemoveProduct = 2,
            UpdateProductQuantity = 3,
            UpdateProductPrice = 4,
            UpdateProductLowStockThreshold = 5,
            DisplayProduct = 6,
            DisplayAllProducts = 7,
            Exit = 8
        }

        
            static void Main(string[] args)
            {
            LogIn.ShowLogin();
            Loading.ShowLoading();
            // Create an instance of Inventory
            Inventory inventory = new Inventory();
            LowStockNotifier notifier = new LowStockNotifier();

            inventory.OnLowStock += notifier.HandleLowStock;

            BackgroundStockChecker Checker = new BackgroundStockChecker(inventory, 10);
            Checker.Start();
            // Main menu loop
            bool running = true;
                while (running)
                {
                    Console.Clear();
                    Console.WriteLine("\n===== STOCK INVENTORY MENU =====");
                    Console.WriteLine("1 - Add Product");
                    Console.WriteLine("2 - Remove Product");
                    Console.WriteLine("3 - Update Product Quantity");
                    Console.WriteLine("4 - Update Product Price");
                    Console.WriteLine("5 - Update Product Low Stock Threshold");
                    Console.WriteLine("6 - Display Product");
                    Console.WriteLine("7 - Display All Products");
                    Console.WriteLine("8 - Exit");
                    Console.Write("Choose an option: ");

                    // Get user choice
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(MenuOption), choice))
                    {
                        MenuOption option = (MenuOption)choice;

                        switch (option)
                        {
                            case MenuOption.AddProduct:
                            try
                            {
                                Console.Write("Enter Product ID: ");
                                string id = Console.ReadLine();
                                Console.Write("Enter Product Name: ");
                                string name = Console.ReadLine();
                                Console.Write("Enter Quantity: ");
                                int qty = int.Parse(Console.ReadLine());
                                Console.Write("Enter Price: ");
                                double price = double.Parse(Console.ReadLine());
                                Console.Write("Enter Low Stock Threshold: ");
                                int threshold = int.Parse(Console.ReadLine());

                                Product newProduct = new Product(id, name, price, qty, threshold);
                                inventory.AddProduct(newProduct);

                                Console.WriteLine("press any key to continue...");
                                Console.ReadKey();
                            } catch (FormatException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}. Please enter valid data.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred: {ex.Message}");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            break;

                            case MenuOption.RemoveProduct:
                            try
                            {
                                Console.Write("Enter Product ID to remove: ");
                                string removeId = Console.ReadLine();
                                inventory.RemoveProduct(removeId);

                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            catch (KeyNotFoundException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}. Please enter a valid Product ID.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred: {ex.Message}");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            break;

                            case MenuOption.UpdateProductQuantity:
                            try
                            {
                                Console.Write("Enter Product ID: ");
                                string updateId = Console.ReadLine();
                                Console.Write("Enter New Quantity: ");
                                int newQty = int.Parse(Console.ReadLine());
                                inventory.UpdateProductQuantity(updateId, newQty);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            } catch (KeyNotFoundException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}. Please enter a valid quantity.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred: {ex.Message}");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            break;

                            case MenuOption.UpdateProductPrice:
                            try
                            {
                                Console.Write("Enter Product ID: ");
                                string priceId = Console.ReadLine();
                                Console.Write("Enter New Price: ");
                                double newPrice = double.Parse(Console.ReadLine());
                                inventory.UpdateProductPrice(priceId, newPrice);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            } catch (KeyNotFoundException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}. Please enter a valid quantity.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred: {ex.Message}");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                    
                            break;

                            case MenuOption.UpdateProductLowStockThreshold:
                            try
                            {
                                Console.Write("Enter Product ID: ");
                                string thresholdId = Console.ReadLine();
                                Console.Write("Enter New Low Stock Threshold: ");
                                int newThreshold = int.Parse(Console.ReadLine());
                                inventory.UpdateProductLowStockThreshold(thresholdId, newThreshold);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            catch (KeyNotFoundException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}. Please enter a valid quantity.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred: {ex.Message}");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            break;

                            case MenuOption.DisplayProduct:
                                Console.Write("Enter Product ID to display: ");
                                string displayId = Console.ReadLine();
                                inventory.DisplayProduct(displayId);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            break;

                            case MenuOption.DisplayAllProducts:

                                inventory.DisplayProducts();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            break;

                            case MenuOption.Exit:
                                Console.WriteLine("Exiting program...");
                                running = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
        
    }
}
