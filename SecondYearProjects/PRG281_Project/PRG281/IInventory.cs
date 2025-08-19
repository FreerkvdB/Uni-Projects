using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281
{
    internal interface IInventory
    {
        //Method to add a product to the inventory
        void AddProduct(Product product);

        //Method to remove a product from the inventory
        void RemoveProduct(string productId);

        //Method to update the quantity of a product in the inventory
        void UpdateProductQuantity(string productId, int newQuantity);

        //Method to display a specific product in the inventory
        void DisplayProduct(string productId);

        //Method to display all products in the inventory
        void DisplayProducts();

        //Update Price of a product in the inventory
        void UpdateProductPrice(string productId, double newPrice);

        //Update Low Stock Threshold of a product in the inventory
        void UpdateProductLowStockThreshold(string productId, int newLowStockThreshold);
    }
}
