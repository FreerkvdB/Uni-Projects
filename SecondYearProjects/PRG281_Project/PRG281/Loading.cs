using System;

namespace PRG281
    {
    internal class Loading
    {
        public static void ShowLoading()
        {
            // Simulate loading with a progress bar
            Console.Write("Loading: [");
            for (int i = 0; i < 25; i++)
            {
                Console.Write("##");
                System.Threading.Thread.Sleep(150);
            }
            Console.WriteLine("] Done!");
            System.Threading.Thread.Sleep(500);
        }
    }
}
