using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PRG281
{
    internal class BackgroundStockChecker : LowStockNotifier
    {
        private Inventory inventory;
        private int interval; // in milliseconds
        private Thread checkerThread;

        public BackgroundStockChecker(Inventory inv, int checkIntervalSeconds)
        {
            inventory = inv;
            interval = checkIntervalSeconds * 1000; // convert to ms
            checkerThread = new Thread(new ThreadStart(Run));
            checkerThread.IsBackground = true; // runs in background
        }

        public void Start()
        {
            checkerThread.Start();
        }

        private void Run()
        {
            while (true)
            {
                Thread.Sleep(interval);

                foreach (var product in inventory.GetProducts())
                {
                    // Check if product is low on stock before notifying
                    if (product.Quantity <= product.LowStockThreshold)
                    {
                        inventory.NotifyLowStock(product);
                    }
                }
            }
        }
    }
}

