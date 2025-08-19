using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281
{
    internal class LowStockNotifier

    {
        //Method to handle low stock notification
        public void HandleLowStock(Product product)
        {
            Console.WriteLine($"⚠ ALERT: Low stock for {product.ProductName} (Quantity: {product.Quantity})");
        }
    }
}

