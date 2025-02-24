using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emil.BookStore.Services
{
    public static class FeatureFlags
    {
        public static bool EnableDiscounts { get; set; } = true;

        public static void ToggleDiscounts()
        {
            if (EnableDiscounts)
            {
                EnableDiscounts = false;
                Console.WriteLine("Discounts are now disabled.");
            }
            else
            {
                EnableDiscounts = true;
                Console.WriteLine("Discounts are now enabled.");
            }
        }
    }
}